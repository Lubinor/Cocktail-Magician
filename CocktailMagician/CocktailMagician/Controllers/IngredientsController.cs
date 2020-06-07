using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;
using System.Linq.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace CocktailMagician.Web.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientService ingredientService;
        private readonly ICocktailService cocktailService;
        private readonly IIngredientDTOMapper ingredientDTOMapper;
        private readonly ICocktailDTOMapper cocktailDTOMapper;

        public IngredientsController(IIngredientService ingredientService, ICocktailService cocktailService,
            IIngredientDTOMapper ingredientDTOMapper, ICocktailDTOMapper cocktailDTOMapper)
        {
            this.ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
            this.cocktailService = cocktailService ?? throw new ArgumentNullException(nameof(cocktailService));
            this.ingredientDTOMapper = ingredientDTOMapper ?? throw new ArgumentNullException(nameof(ingredientDTOMapper));
            this.cocktailDTOMapper = cocktailDTOMapper ?? throw new ArgumentNullException(nameof(cocktailDTOMapper));
        }

        // GET: Ingredients
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var ingredientDTOs = await this.ingredientService.GetAllIngredientsAsync();
            var ingredientVMs = ingredientDTOs.Select(ingredientDTO =>
                ingredientDTOMapper.MapToVMFromDTO(ingredientDTO)).ToList();

            foreach (var ingredient in ingredientVMs)
            {
                ingredient.Cocktails = (await this.cocktailService.GetAllCocktailssAsync())
                    .Where(cocktail => cocktail.Ingredients.Any(x => x.Name == ingredient.Name))
                    .Select(cdto => cocktailDTOMapper.MapToVMFromDTO(cdto)).ToList();
            }

            return View(ingredientVMs);
        }

        // GET: Ingredients/Details/5
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var ingredientDTO = await this.ingredientService.GetIngredientAsync(id);

            if (ingredientDTO == null)
            {
                return NotFound();
            }

            var ingredientVM = this.ingredientDTOMapper.MapToVMFromDTO(ingredientDTO);

            return View(ingredientVM);
        }

        // GET: Ingredients/Create
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Create(IngredientViewModel ingredientVM)
        {
            //if (this.ingredientService.IsValid(ingredientDTO))
            //{
            //    return View(Error);
            //}
            if (ModelState.IsValid)
            {
                try
                {
                        if (ingredientVM.File.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            await ingredientVM.File.CopyToAsync(ms);
                            ingredientVM.ImageData = ms.ToArray();

                            ms.Close();
                            ms.Dispose();
                        }
                    var ingredientDTO = this.ingredientDTOMapper.MapToDTOFromVM(ingredientVM);
                    await this.ingredientService.CreateIngredientAsync(ingredientDTO);

                    return RedirectToAction(nameof(Index));
                }
                //catch (ArgumentNullException)
                //{
                //    return NotFound(); //status 404
                //}
                //catch (ArgumentException)
                //{
                //    return NotFound(); //status 404
                //}
                catch (Exception)
                {
                    return BadRequest(); //status 400
                }
            }
            return View(); //TODO: here must returns something - middleware maybe
        }

        // GET: Ingredients/Edit/5
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id)
        {
            var ingredientDTO = await this.ingredientService.GetIngredientAsync(id);

            if (ingredientDTO == null)
            {
                return NotFound();
            }

            var editIngredientVM = new EditIngredientViewModel
            {
                Id = ingredientDTO.Id,
                Name = ingredientDTO.Name
            };

            return View(editIngredientVM);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Edit(int id, EditIngredientViewModel editIngredientVM)
        {
            if (editIngredientVM.File.Length > 0)
            {
                MemoryStream ms = new MemoryStream();
                await editIngredientVM.File.CopyToAsync(ms);
                editIngredientVM.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            var ingredientDTO = this.ingredientDTOMapper.MapToDTOFromVM(editIngredientVM);

            if (id != ingredientDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.ingredientService.UpdateIngredientAsync(id, ingredientDTO);
                }
                catch (ArgumentNullException)
                {
                    return NotFound(); //status 404
                }
                catch (ArgumentException)
                {
                    return NotFound(); //status 404
                }
                catch (Exception)
                {
                    return BadRequest(); //status 400
                }
                return RedirectToAction("Details", "Ingredients", new { id });
            }

            return View(); //TODO: here must returns something - middleware maybe
        }

        // GET: Ingredients/Delete/5
        [HttpGet]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredientDTO = await this.ingredientService.GetIngredientAsync(id);

            if (ingredientDTO == null)
            {
                return NotFound();
            }

            var ingredientVM = this.ingredientDTOMapper.MapToVMFromDTO(ingredientDTO);

            return View(ingredientVM);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cocktail Magician")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.ingredientService.DeleteIngredientAsync(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ListAllIngredients()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalIngredients = this.ingredientService.GetAllIngredientsCount();
            int filteredIngredients = this.ingredientService.GetAllFilteredIngredientsCount(searchValue);
            var ingredients = await this.ingredientService.ListAllIngredientsAsync(skip, pageSize, searchValue,
                sortColumn, sortColumnDirection);

            var ingredientsVMs = ingredients.Select(ing => this.ingredientDTOMapper.MapToVMFromDTO(ing)).ToList();
            
            foreach (var item in ingredientsVMs)
            {
                item.Cocktails = (await this.cocktailService.GetAllCocktailssAsync())
                    .Where(cocktail => cocktail.Ingredients.Any(x => x.Name == item.Name))
                    .Select(cdto => cocktailDTOMapper.MapToVMFromDTO(cdto)).ToList();
                item.CocktailNames = string.Join(", ",item.Cocktails.Select(c => c.Name));
            }

            return Json(new {draw = draw, recordsFiltered = filteredIngredients, recordsTotal = totalIngredients, data = ingredientsVMs }); //data = model
        }
        private bool IngredientExists(int id)
        {
            return this.ingredientService.GetAllIngredientsAsync().Result.Any(e => e.Id == id);
        }
    }
}
