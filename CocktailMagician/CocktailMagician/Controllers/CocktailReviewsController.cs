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
using CocktailMagician.Services.Providers.Contracts;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CocktailMagician.Web.Mappers;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailReviewsController : Controller
    {
        private readonly ICocktailReviewService cocktailReviewService;
        private readonly ICocktailService cocktailService;
        private readonly IUserService userService;
        private readonly ICocktailDTOMapper cocktailMapper;
        private readonly ICocktailReviewDTOMapper cocktailReviewMapper;
        private readonly UserManager<User> userManager;

        public CocktailReviewsController(ICocktailReviewService cocktailReviewService, ICocktailService cocktailService,
            IUserService userService, ICocktailDTOMapper cocktailMapper, ICocktailReviewDTOMapper cocktailReviewMapper,
            UserManager<User> userManager)
        {
            this.cocktailReviewService = cocktailReviewService ?? throw new ArgumentNullException(nameof(cocktailReviewService));
            this.cocktailService = cocktailService ?? throw new ArgumentNullException(nameof(cocktailService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.cocktailMapper = cocktailMapper ?? throw new ArgumentNullException(nameof(cocktailMapper));
            this.cocktailReviewMapper = cocktailReviewMapper ?? throw new ArgumentNullException(nameof(cocktailReviewMapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CocktailReviews(int id)
        {
            var cocktailReviewDTOs = await this.cocktailReviewService.GetAllCocktailReviewsAsync(id);
            var cocktailReviewVMs = new ListCocktailReviewsViewModel
            {
                AllCocktailReviews = cocktailReviewDTOs
                .Select(c => cocktailReviewMapper.MapToVMFromDTO(c))
                .ToList()
            };

            return View(cocktailReviewVMs);
        }
        [HttpGet]
        public async Task<IActionResult> UserReviews(int id)
        {
            var userReviewDTOs = await this.cocktailReviewService.GetAllUserReviewsAsync(id);
            var userReviewVMs = new ListCocktailReviewsViewModel
            {
                AllCocktailReviews = userReviewDTOs
                .Select(c => cocktailReviewMapper.MapToVMFromDTO(c))
                .ToList()
            };

            return View(userReviewVMs);
        }
        [HttpGet]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Create(int id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailAsync(id);
            //var cocktailVM = cocktailMapper.MapToVMFromDTO(cocktailDTO);

            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            var reviewVM = new CreateCocktailReviewViewModel
            {
                CocktailId = cocktailDTO.Id,
                AuthorId = currentUserId
            };

            //ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(reviewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Create(CreateCocktailReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));
                var currentCocktailId = reviewVM.CocktailId;
                //var userDTO = await this.userService.GetUserAsync(currentUserId);
                //var barDTO = await this.barService.GetBarAsync(reviewVM.BarId);

                var reviewDTO = this.cocktailReviewMapper.MapToDTOFromVM(reviewVM);
                reviewDTO.AuthorId = currentUserId;

                var result = await this.cocktailReviewService.CreateCocktailReviewAsync(reviewDTO);

                return RedirectToAction("Details", "Cocktails", new { id = result.CocktailId });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Edit(int id)
        {
            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            var reviewDTO = await this.cocktailReviewService.GetCocktailReviewAsync(id, currentUserId);

            if (reviewDTO == null)
            {
                return NotFound();
            }

            var reviewVM = this.cocktailReviewMapper.MapToVMFromDTO(reviewDTO);
            return View(reviewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Edit(int id, CocktailReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

                    var reviewDTO = this.cocktailReviewMapper.MapToDTOFromVM(reviewVM);

                    var result = await this.cocktailReviewService.UpdateCocktailReviewAsync(id, currentUserId, reviewDTO);

                    return RedirectToAction("Details", "Cocktails", new { id });
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            var reviewDTO = await this.cocktailReviewService.GetCocktailReviewAsync(id, currentUserId);

            if (reviewDTO == null)
            {
                return NotFound();
            }

            var reviewVM = this.cocktailReviewMapper.MapToVMFromDTO(reviewDTO);

            return View(reviewVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            await this.cocktailReviewService.DeleteCocktailReviewAsync(id, currentUserId);

            return RedirectToAction("CocktailReviews", "CocktailReviews", new { id });
        }
    }
}
