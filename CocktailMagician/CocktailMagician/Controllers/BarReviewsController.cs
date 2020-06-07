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

namespace CocktailMagician.Web.Controllers
{
    public class BarReviewsController : Controller
    {
        private readonly IBarReviewService barReviewService;
        private readonly IBarService barService;
        private readonly IUserService userService;
        private readonly IBarDTOMapper barMapper;
        private readonly IBarReviewDTOMapper barReviewMapper;
        private readonly UserManager<User> userManager;

        public BarReviewsController(IBarReviewService barReviewService, IBarService barService,
            IUserService userService, IBarDTOMapper barMapper, IBarReviewDTOMapper barReviewMapper, UserManager<User> userManager)
        {
            this.barReviewService = barReviewService ?? throw new ArgumentNullException(nameof(barReviewService));
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
            this.barReviewMapper = barReviewMapper ?? throw new ArgumentNullException(nameof(barReviewMapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> BarReviews(int id)
        {
            var barReviewDTOs = await this.barReviewService.GetAllBarReviewsAsync(id);
            var barReviewVMs = new ListBarReviewsViewModel
            {
                AllBarReviews = barReviewDTOs
                .Select(br => barReviewMapper.MapToVMFromDTO(br))
                .ToList()
            };

            return View(barReviewVMs);
        }
        [HttpGet]
        public async Task<IActionResult> UserReviews(int id)
        {
            var userReviewDTOs = await this.barReviewService.GetAllUserReviewsAsync(id);
            var userReviewVMs = new ListBarReviewsViewModel
            {
                AllBarReviews = userReviewDTOs
                .Select(br => barReviewMapper.MapToVMFromDTO(br))
                .ToList()
            };

            return View(userReviewVMs);
        }
        [HttpGet]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Create(int id)
        {
            var barDTO = await this.barService.GetBarAsync(id);
            var barVM = barMapper.MapToVMFromDTO(barDTO);

            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            var reviewVM = new BarReviewViewModel
            {
                BarName = barVM.Name,
                BarId = barDTO.Id,
                AuthorId = currentUserId
            };

            //ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(reviewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Create(BarReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

                //var userDTO = await this.userService.GetUserAsync(currentUserId);
                //var barDTO = await this.barService.GetBarAsync(reviewVM.BarId);

                var reviewDTO = this.barReviewMapper.MapToDTOFromVM(reviewVM);
                reviewDTO.AuthorId = currentUserId;

                var result = await this.barReviewService.CreateBarReviewAsync(reviewDTO);

                return RedirectToAction("BarReviews", "BarReviews", new { id = result.BarId });
            }

            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Edit(int id)
        {
            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            var reviewDTO = await this.barReviewService.GetBarReviewAsync(id, currentUserId);

            if (reviewDTO == null)
            {
                return NotFound();
            }

            var reviewVM = this.barReviewMapper.MapToVMFromDTO(reviewDTO);
            return View(reviewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> Edit(int id, BarReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

                    var reviewDTO = this.barReviewMapper.MapToDTOFromVM(reviewVM);

                    var result = await this.barReviewService.UpdateBarReviewAsync(id, currentUserId, reviewDTO);

                    return RedirectToAction("BarReviews", "BarReviews", new { id });
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

            var reviewDTO = await this.barReviewService.GetBarReviewAsync(id, currentUserId);

            if (reviewDTO == null)
            {
                return NotFound();
            }

            var reviewVM = this.barReviewMapper.MapToVMFromDTO(reviewDTO);

            return View(reviewVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Bar Crawler")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUserId = int.Parse(userManager.GetUserId(HttpContext.User));

            await this.barReviewService.DeleteBarReviewAsync(id, currentUserId);

            return RedirectToAction("BarReviews", "BarReviews", new { id });
        }
    }
}
