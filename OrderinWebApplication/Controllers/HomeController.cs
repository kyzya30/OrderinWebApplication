using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderinWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.DB.Entities;
using WebApplication.Service;

namespace OrderinWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantService restaurantService;

        public HomeController(ILogger<HomeController> logger, RestaurantService restaurantService)
        {
            _logger = logger;
            this.restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("Home/Search")]
        public async Task<List<RestaurantInfo>> Search(string text)
        {
            var restaurants = await restaurantService.SearchRestaurants(text);
            return restaurants;
        }

        [HttpPost]
        [Route("Home/Order")]
        public async Task<bool> Order(int[] selectedMenuItemId)
        {
            Thread.Sleep(200);//Simulate action
            return true;
        }

    }
}
