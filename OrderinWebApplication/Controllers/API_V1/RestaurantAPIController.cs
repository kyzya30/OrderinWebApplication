using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DB.Entities;
using WebApplication.Service;

namespace OrderinWebApplication.Controllers.API_V1
{
    
    [Route("api/v1/Restaurant")]
    [ApiController]
    public class RestaurantAPIController : ControllerBase
    {
        private readonly RestaurantService restaurantService;

        public RestaurantAPIController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
       

        [HttpGet]
        public async Task<ActionResult<List<RestaurantInfo>>> Get(string text)
        {
            try
            {
               var items = await restaurantService.SearchRestaurants(text);
               return items;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpPut]
        //[Route("api/v1/Restaurant/{id}")]
        //Here we can implement PUT to update DB values

        //[HttpPOST]
        //[Route("api/v1/Restaurant")]
        //Here we can implement POST to insert new menu items in DB

        //[HttpDelete]
        //[Route("api/v1/Restaurant/{id}")]
        //Here we can implement DELETE to delete restaurant or menu items new menu items in DB
    }
}
