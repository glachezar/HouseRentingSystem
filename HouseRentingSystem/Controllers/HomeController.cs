﻿namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Data.Services.Interfaces;

    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService houseService)
        {
            this.houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel =
                await this.houseService.LastThreeHousesAsync();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}