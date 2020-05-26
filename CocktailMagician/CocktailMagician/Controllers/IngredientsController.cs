using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;

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
            ingredientVM.Cocktails = (await this.cocktailService.GetAllCocktailssAsync())
                .Where(cocktail => cocktail.Ingredients.Any(x => x.Name == ingredientVM.Name))
                .Select(cdto => cocktailDTOMapper.MapToVMFromDTO(cdto)).ToList();

            return View(ingredientVM);
        }

        // GET: Ingredients/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] IngredientDTO ingredientDTO)
        {
            if (ModelState.IsValid)
            {
                await this.ingredientService.CreateIngredientAsync(ingredientDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(); //TODO: here must returns something - middleware maybe
        }

        // GET: Ingredients/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ingredientDTO = await this.ingredientService.GetIngredientAsync(id);

            if (ingredientDTO == null)
            {
                return NotFound();
            }

            var ingredientVM = this.ingredientDTOMapper.MapToVMFromDTO(ingredientDTO);

            return View(ingredientVM);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] IngredientViewModel ingredientVM)
        {
            var ingredientDTO = this.ingredientDTOMapper.MapToDTOFromVM(ingredientVM);

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
                catch (DbUpdateConcurrencyException) // Catch to be improved
                {
                    if (!IngredientExists(ingredientDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(); //TODO: here must returns something - middleware maybe
        }

        // GET: Ingredients/Delete/5
        [HttpGet]
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.ingredientService.DeleteIngredientAsync(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> ListAllIngredients()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalIngredients = this.ingredientService.GetAllCocktailsCount();
            var ingredients = await this.ingredientService.ListAllIngredientsAsync(skip, pageSize, searchValue);

            var model = ingredients.Select(ingredient => this.ingredientDTOMapper.MapToVMFromDTO(ingredient));

            var json = Json(new { draw = draw, recordsFiltered = totalIngredients, recordsTotal = totalIngredients, data = model });

            return json;
            //return Json(new {draw = draw, recordsFiltered = totalIngredients, recordsTotal = totalIngredients, data = model });
        }
        private bool IngredientExists(int id)
        {
            return this.ingredientService.GetAllIngredientsAsync().Result.Any(e => e.Id == id);
        }
    }
}
