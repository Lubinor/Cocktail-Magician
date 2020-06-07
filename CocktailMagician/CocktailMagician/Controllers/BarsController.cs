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
using CocktailMagician.Web.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CocktailMagician.Web.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarService barService;
        private readonly ICityService cityService;
        private readonly ICocktailService cocktailService;
        private readonly IBarDTOMapper barMapper;
        private readonly ICocktailDTOMapper cocktailMapper;
        private readonly ICityDTOMapper citymapper;

        public BarsController(IBarService barService, ICityService cityService, ICocktailService cocktailService,
            IBarDTOMapper barMapper, ICocktailDTOMapper cocktailMapper, ICityDTOMapper citymapper)
        {
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            this.cocktailService = cocktailService ?? throw new ArgumentNullException(nameof(cocktailService));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
            this.cocktailMapper = cocktailMapper ?? throw new ArgumentNullException(nameof(cocktailMapper));
            this.citymapper = citymapper ?? throw new ArgumentNullException(nameof(citymapper));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var barDTOs = await this.barService.GetAllBarsAsync();

            var bars = barDTOs
                .Select(b => barMapper.MapToVMFromDTO(b))
                .ToList();

            return View(bars);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var barDTO = await barService.GetBarAsync(id);

            if (barDTO == null)
            {
                return NotFound();
            }

            var bar = barMapper.MapToVMFromDTO(barDTO);

            return View(bar);
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Create()
        {
            var citiesDTO = await this.cityService.GetAllCitiesAsync();
            var citiesVM = citiesDTO.Select(c => citymapper.MapToVMFromDTO(c)).ToList();

            ViewData["CityId"] = new SelectList(citiesVM, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Create([Bind("Name", "CityName", "CityId", "Address", "City", "Phone")] BarViewModel barVM, List<IFormFile> ImageData)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in ImageData)
                {
                    if (file.Length > 0)
                    {
                    MemoryStream ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    barVM.ImageData = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                    }

                }

                var barDTO = barMapper.MapToDTOFromVM(barVM);
                var result = await this.barService.CreateBarAsync(barDTO);

                return RedirectToAction("Details", "Bars", new { id = result.Id });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id)
        {
            var barDTO = await barService.GetBarAsync(id);

            if (barDTO == null)
            {
                return NotFound();
            }

            var citiesDTO = await this.cityService.GetAllCitiesAsync();
            var citiesVM = citiesDTO.Select(c => citymapper.MapToVMFromDTO(c)).ToList();

            ViewData["CityId"] = new SelectList(citiesVM, "Id", "Name");

            var bar = barMapper.MapToVMFromDTO(barDTO);

            return View(bar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id, BarViewModel barVM)
        {
            if (id != barVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var barDTO = this.barMapper.MapToDTOFromVM(barVM);
                    await this.barService.UpdateBarAsync(id, barDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Details", "Bars", new { id });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Delete(int id)
        {
            var barDTO = await barService.GetBarAsync(id);

            if (barDTO == null)
            {
                return NotFound();
            }

            var bar = barMapper.MapToVMFromDTO(barDTO);

            return View(bar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.barService.DeleteBarAsync(id);
            return RedirectToAction("Index", "Bars", new { area = "" });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ListAllBars()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalBars = this.barService.GetAllBarsCount();
            int filteredBars = this.barService.GetAllFilteredBarsCount(searchValue);
            var bars = await this.barService.ListAllBarsAsync(skip, pageSize, searchValue,
                sortColumn, sortColumnDirection);

            var barVMs = bars.Select(bar => this.barMapper.MapToVMFromDTO(bar)).ToList();

            foreach (var bar in barVMs)
            {
                bar.Cocktails = (await this.cocktailService.GetAllCocktailssAsync())
                    .Where(c => c.Bars.Any(x => x.Name == bar.Name))
                    .Select(cdto => cocktailMapper.MapToVMFromDTO(cdto)).ToList();
                bar.CocktailNames = string.Join(", ", bar.Cocktails.Select(c => c.Name));
            }

            return Json(new { draw = draw, recordsFiltered = filteredBars, recordsTotal = totalBars, data = barVMs }); //data = model
        }
    }
}
