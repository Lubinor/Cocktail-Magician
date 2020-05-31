﻿using System;
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

namespace CocktailMagician.Web.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarService barService;
        private readonly ICityService cityService;
        private readonly IBarDTOMapper barMapper;
        private readonly ICocktailDTOMapper cocktailMapper;
        private readonly ICityDTOMapper citymapper;

        public BarsController(IBarService barService, ICityService cityService, IBarDTOMapper barMapper, 
            ICocktailDTOMapper cocktailMapper, ICityDTOMapper citymapper)
        {
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
            this.cocktailMapper = cocktailMapper ?? throw new ArgumentNullException(nameof(cocktailMapper));
            this.citymapper = citymapper ?? throw new ArgumentNullException(nameof(citymapper));
        }

        public async Task<IActionResult> Index()
        {
            var barDTOs = await this.barService.GetAllBarsAsync();

            var bars = barDTOs
                .Select(b => barMapper.MapToVMFromDTO(b))
                .ToList();

            return View(bars);
        }

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

        public async Task<IActionResult> Create()
        {
            var citiesDTO = await this.cityService.GetAllCitiesAsync();
            var citiesVM = citiesDTO.Select(c => citymapper.MapToVMFromDTO(c)).ToList();

            ViewData["CityId"] = new SelectList(citiesVM, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name","CityName", "CityId", "Address", "City", "Phone")] BarViewModel barVM)
        {
            if (ModelState.IsValid)
            {
                var barDTO = barMapper.MapToDTOFromVM(barVM);
                var result = await this.barService.CreateBarAsync(barDTO);

                return RedirectToAction("Details", "Bars", new { id = result.Id });
            }

            return NotFound();
        }

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.barService.DeleteBarAsync(id);
            return RedirectToAction("Index", "Bars", new { area = "" });
        }
    }
}