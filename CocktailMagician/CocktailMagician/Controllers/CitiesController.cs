using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using System.Linq.Dynamic;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CocktailMagician.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        private readonly IBarService barService;
        private readonly ICityDTOMapper cityMapper;
        private readonly IBarDTOMapper barMapper;

        public CitiesController(ICityService cityService, IBarService barService, ICityDTOMapper cityMapper, IBarDTOMapper barMapper)
        {
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
            this.cityMapper = cityMapper ?? throw new ArgumentNullException(nameof(cityMapper));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cityDTOs = await this.cityService.GetAllCitiesAsync();

            var cities = cityDTOs
                .Select(c => cityMapper.MapToVMFromDTO(c))
                .ToList();

            return View(cities);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            var cityDTO = await cityService.GetCityAsync(id);

            if (cityDTO == null)
            {
                return NotFound();
            }

            var city = cityMapper.MapToVMFromDTO(cityDTO);

            return View(city);
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Create([Bind("Name")] CityViewModel cityVM)
        {
            if (ModelState.IsValid)
            {
                var cityDTO = cityMapper.MapToDTOFromVM(cityVM);
                var result = await this.cityService.CreateCityAsync(cityDTO);
                return RedirectToAction("Details", "Cities", new { id = result.Id });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id)
        {
            var cityDTO = await cityService.GetCityAsync(id);

            if (cityDTO == null)
            {
                return NotFound();
            }

            var city = cityMapper.MapToVMFromDTO(cityDTO);

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id, CityViewModel cityVM)
        {
            if (id != cityVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cityDTO = this.cityMapper.MapToDTOFromVM(cityVM);
                    await this.cityService.UpdateCityAsync(id, cityDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Details", "Cities", new { id });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Delete(int id)
        {
            var cityDTO = await cityService.GetCityAsync(id);

            if (cityDTO == null)
            {
                return NotFound();
            }

            var city = cityMapper.MapToVMFromDTO(cityDTO);

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.cityService.DeleteCityAsync(id);
            return RedirectToAction("Index", "Cities", new { area = "" });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ListAllCities()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalCities = this.cityService.GetAllCitiesCount();
            int filteredCities = this.cityService.GetAllFilteredCitiesCount(searchValue);
            var cities = await this.cityService.ListAllCitiesAsync(skip, pageSize, searchValue,
                sortColumn, sortColumnDirection);

            var cityVMs = cities.Select(city => this.cityMapper.MapToVMFromDTO(city)).ToList();

            foreach (var city in cityVMs)
            {
                city.Bars = (await this.barService.GetAllBarsAsync())
                    .Where(b => b.CityName.Contains(city.Name))
                    .Select(b => barMapper.MapToVMFromDTO(b)).ToList();

                city.BarNames = string.Join(", ", city.Bars.Select(b => b.Name));
            }

            return Json(new { draw = draw, recordsFiltered = filteredCities, recordsTotal = totalCities, data = cityVMs }); //data = model
        }
    }
}
