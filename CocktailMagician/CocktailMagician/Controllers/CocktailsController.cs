using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Services.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using CocktailMagician.Web.Models;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;
        private readonly IBarService barService;
        private readonly ICocktailDTOMapper cocktailDTOMapper;
        private readonly IIngredientDTOMapper ingredientDTOMapper;
        private readonly IBarDTOMapper barDTOMApper;

        public CocktailsController(ICocktailService cocktailService, IIngredientService ingredientService,
            IBarService barService, ICocktailDTOMapper cocktailDTOMapper, IIngredientDTOMapper ingredientDTOMapper,
            IBarDTOMapper barDTOMApper)
        {
            this.cocktailService = cocktailService ?? throw new ArgumentNullException(nameof(cocktailService));
            this.ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
            this.cocktailDTOMapper = cocktailDTOMapper ?? throw new ArgumentNullException(nameof(cocktailDTOMapper));
            this.ingredientDTOMapper = ingredientDTOMapper ?? throw new ArgumentNullException(nameof(ingredientDTOMapper));
            this.barDTOMApper = barDTOMApper ?? throw new ArgumentNullException(nameof(barDTOMApper));
        }

        // GET: Cocktails
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cocktailDTOs = await this.cocktailService.GetAllCocktailssAsync();
            var cocktailVMs = cocktailDTOs.Select(cocktailDTO =>
                cocktailDTOMapper.MapToVMFromDTO(cocktailDTO)).ToList();

            foreach (var cocktail in cocktailVMs)
            {
                cocktail.Ingredients = (await this.ingredientService.GetAllIngredientsAsync())
                    .Where(ingredient => ingredient.CocktailDTOs.Any(c => c.Name == cocktail.Name))
                    .Select(idto => ingredientDTOMapper.MapToVMFromDTO(idto)).ToList();
                cocktail.Bars = (await this.barService.GetAllBarsAsync())
                    .Where(bar => bar.Cocktails.Any(c => c.Name == cocktail.Name))
                    .Select(bdto => barDTOMApper.MapToVMFromDTO(bdto)).ToList();
            }

            return View(cocktailVMs);
        }

        // GET: Cocktails/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id);

            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO);

            return View(cocktailVM);
        }

        // GET: Cocktails/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ingredients = await this.ingredientService.GetAllIngredientsAsync();
            var ingredientVMs = ingredients.Select(ingredient => ingredientDTOMapper.MapToVMFromDTO(ingredient));

            ViewData["Ingredients"] = new MultiSelectList(ingredientVMs,"Id","Name");
            return View();
        }

        // POST: Cocktails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Ingredients")] CocktailDTO cocktailDTO)
        public async Task<IActionResult> Create(CreateCocktailViewModel createCocktailViewModel )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cocktailDTO = this.cocktailDTOMapper.MapToDTOFromVM(createCocktailViewModel);
                    await this.cocktailService.CreateCocktailAsync(cocktailDTO);

                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentNullException)
                {
                    return NotFound();
                }
                catch (ArgumentException)
                {
                    return BadRequest();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return View();
        }

        // GET: Cocktails/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ingredients = await this.ingredientService.GetAllIngredientsAsync();
            var ingredientVMs = ingredients.Select(ingredient => ingredientDTOMapper.MapToVMFromDTO(ingredient));
            var bars = await this.barService.GetAllBarsAsync();
            var barVMs = bars.Select(bar => barDTOMApper.MapToVMFromDTO(bar));

            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id); ;
            
            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var editCocktailVM = new EditCocktailViewModel
            {
                Id = cocktailDTO.Id,
                Name = cocktailDTO.Name,
                ContainedBars = cocktailDTO.Bars.Select(b => b.Id).ToList(),
                ContainedIngredients = cocktailDTO.Ingredients.Select(i => i.Id).ToList(),
            };

            ViewData["Ingredients"] = new MultiSelectList(ingredientVMs, "Id", "Name"); 
            ViewData["Bars"] = new MultiSelectList(barVMs, "Id", "Name");
            
            return View(editCocktailVM);
        }

        // POST: Cocktails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCocktailViewModel newEditCocktailVM)
        {
            if (id != newEditCocktailVM.Id)
            {
                return NotFound();
            }

            var cocktailDTO = cocktailDTOMapper.MapToDTOFromVM(newEditCocktailVM);

            if (ModelState.IsValid)
            {
                try
                {
                    await this.cocktailService.UpdateCocktailAsync(id, cocktailDTO);
                }
                catch (ArgumentNullException)
                {
                    return NotFound();
                }
                catch (ArgumentException)
                {
                    return BadRequest();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(newEditCocktailVM);
        }

        // GET: Cocktails/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id);

            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO);

            return View(cocktailVM);
        }

        // POST: Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.cocktailService.DeleteCocktailAsync(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> ListAllCocktails()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalCocktails = this.cocktailService.GetAllCocktailsCount();
            int filteredCocktails = this.cocktailService.GetAllFilteredCocktailsCount(searchValue);
            var cocktails = await this.cocktailService.ListAllCocktailsAsync(skip, pageSize, searchValue,
                sortColumn, sortColumnDirection);

            var cocktailVMs = cocktails.Select(cocktail => this.cocktailDTOMapper.MapToVMFromDTO(cocktail)).ToList();

            foreach (var item in cocktailVMs)
            {
                item.Ingredients = (await this.ingredientService.GetAllIngredientsAsync())
                    .Where(ingredient => ingredient.CocktailDTOs.Any(x => x.Name == item.Name))
                    .Select(idto => ingredientDTOMapper.MapToVMFromDTO(idto)).ToList();
                item.Bars = (await this.barService.GetAllBarsAsync())
                    .Where(bar => bar.Cocktails.Any(x => x.Name == item.Name))
                    .Select(bdto => barDTOMApper.MapToVMFromDTO(bdto)).ToList();
                item.IngredientNames = string.Join(", ", item.Ingredients.Select(i => i.Name));
                item.BarNames = string.Join(", ", item.Bars.Select(b => b.Name));
                //item.CocktailNames = string.Join(", ", item.Cocktails.Select(c => c.Name)); ingredientNames i BarNames
            }

            //return Json(new { draw = draw, recordsFiltered = filteredCocktails, recordsTotal = totalCocktails, data = cocktailVMs }); //data = model

            var json = Json(new { draw = draw, recordsFiltered = filteredCocktails, recordsTotal = totalCocktails, data = cocktailVMs });
            return json;
        }
        [HttpGet]
        public async Task<IActionResult> Comments(int id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id);

            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO);

            return View(cocktailVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Comment(int id, CocktailViewModel cocktailVM)
        //{

        //}
        private bool CocktailExists(int id)
        {
            return this.cocktailService.GetAllCocktailssAsync().Result.Any(e => e.Id == id);
        }
    }
}
