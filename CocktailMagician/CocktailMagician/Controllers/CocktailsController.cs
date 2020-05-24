using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;
        private readonly IBarService barService;
        private readonly ICocktailDTOMapper cocktailDTOMapper;
        private readonly IIngredientDTOMapper ingredientDTOMapper;
        private readonly IBarDTOMApper barDTOMApper;

        public CocktailsController(ICocktailService cocktailService, IIngredientService ingredientService,
            IBarService barService, ICocktailDTOMapper cocktailDTOMapper, IIngredientDTOMapper ingredientDTOMapper,
            IBarDTOMApper barDTOMApper)
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
                    .Where(ingredient => ingredient.Name == cocktail.Name)
                    .Select(idto => ingredientDTOMapper.MapToVMFromDTO(idto)).ToList();
                cocktail.Bars = (await this.barService.GetAllBarsAsync())
                    .Where(bar => bar.Name == cocktail.Name)
                    .Select(bdto => barDTOMApper.MapToVMFromDTO(bdto)).ToList();
            }

            return View(cocktailVMs);
        }

        // GET: Cocktails/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id);

            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO);
            cocktailVM.Ingredients = (await this.ingredientService.GetAllIngredientsAsync())
                .Where(ingredient => ingredient.Name == cocktailVM.Name)
                .Select(idto => ingredientDTOMapper.MapToVMFromDTO(idto)).ToList();
            cocktailVM.Bars = (await this.barService.GetAllBarsAsync())
                .Where(bar => bar.Name == cocktailVM.Name)
                .Select(bdto => barDTOMApper.MapToVMFromDTO(bdto)).ToList();

            return View(cocktailVM);
        }

        // GET: Cocktails/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] CocktailDTO cocktailDTO)
        {
            if (ModelState.IsValid)
            {
                await this.cocktailService.CreateCocktailAsync(cocktailDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Cocktails/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id); ;
            
            if (cocktailDTO == null)
            {
                return NotFound();
            }

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO);

            return View(cocktailVM);
        }

        // POST: Cocktails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] CocktailDTO cocktailDTO)
        {
            if (id != cocktailDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.cocktailService.UpdateCocktailAsync(id, cocktailDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailExists(cocktailDTO.Id))
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

            var cocktailVM = this.cocktailDTOMapper.MapToVMFromDTO(cocktailDTO); // To be fixed also in ingredients

            return View(cocktailVM);
        }

        // GET: Cocktails/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

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

        private bool CocktailExists(int id)
        {
            return this.cocktailService.GetAllCocktailssAsync().Result.Any(e => e.Id == id);
        }
    }
}
