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

namespace CocktailMagician.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICityDTOMapper cityMapper;
        private readonly IBarDTOMapper barMapper;

        public CitiesController(ICityService cityService, ICityDTOMapper cityMapper, IBarDTOMapper barMapper)
        {
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            this.cityMapper = cityMapper ?? throw new ArgumentNullException(nameof(cityMapper));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
        }

        public async Task<IActionResult> Index()
        {
            var cityDTOs = await this.cityService.GetAllCitiesAsync();

            var cities = cityDTOs
                .Select(c => cityMapper.MapToVMFromDTO(c))
                .ToList();

            return View(cities);
        }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.cityService.DeleteCityAsync(id);
            return RedirectToAction("Index", "Cities", new { area = "" });
        }
    }
}
