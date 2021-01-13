using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DB.Entities;
using WebApplication.DB.Repository;
using WebApplication.Interface;

namespace WebApplication.Service
{
    public class RestaurantService
    {
        public RestaurantService()
        {
            
        }

        public async Task SearchRestaurants(string text)
        {
            IDataSourceAction json = new JsonSourceRepository();

            List<RestaurantInfo> restaurantInfos = json.GetData();

            FindData(restaurantInfos, text);

        }

        private void FindData(List<RestaurantInfo> data, string searchText)
        {
            var splitText = searchText.Split(' ');
            var cityList = data.Where(e => splitText.Any(z => e.City.Contains(z))).ToList();

            var directMenuItemsSearch = new List<RestaurantInfo>();
            var categoryNameItem = new List<RestaurantInfo>();


            foreach (var city in cityList)
            {
                foreach (var category in city.Categories)
                {
                    var directMenuItem = category.MenuItems.Where(e => splitText.Any(z => e.Name.Contains(z))).ToList();
                    if (directMenuItem.Count > 0)
                    {
                        directMenuItemsSearch.Add(city);

                        break;
                    }

                    var menuItem = splitText.Any(z => category.Name.Contains(z));
                    if (menuItem == true)
                    {
                        categoryNameItem.Add(city);
                    }
                }   
            }

        }
    }
}
