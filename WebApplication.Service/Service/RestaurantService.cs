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

        public async Task<List<RestaurantInfo>> SearchRestaurants(string text)
        {
            IDataSourceAction json = new JsonSourceRepository();

            List<RestaurantInfo> restaurantInfos = json.GetData();

            return FindData(restaurantInfos, text);

        }

        private List<RestaurantInfo> FindData(List<RestaurantInfo> data, string searchText)
        {
            var splitText = searchText.ToLower().Split("in");
            var keyword = splitText[0].Trim();
            var location = splitText[1].Trim();

            var cityList = data.Where(e => e.City.ToLower().Contains(location)).ToList();

            var searchedItems = new List<RestaurantInfo>();


            foreach (var city in cityList)
            {
                if (city.Id == 1874)
                {
                    var z = 0;
                }

                foreach (var category in city.Categories)
                {
                    bool outerFlagBreak = false;


                    //Category Name Search
                    
                    if (category.Name.ToLower().Contains(keyword))
                    {
                        var copyOfCity = city;

                        copyOfCity.Categories = new List<Category>{ category };

                        searchedItems.Add(copyOfCity);

                        break;
                    }

                    //Menu Items Search

                    foreach (var menuItem in category.MenuItems)
                    {
                        if (menuItem.Name.ToLower().Contains(keyword))
                        {
                            var copyOfCity = city;
                            var copyOfCategory = category;

                            copyOfCategory.Name = "";
                            copyOfCategory.MenuItems = category.MenuItems;

                            copyOfCity.Categories = new List<Category> { copyOfCategory };

                            searchedItems.Add(copyOfCity);

                            outerFlagBreak = true;

                            break;

                        }
                    }

                    if (outerFlagBreak == true)
                    {
                        break; //Exit from search category because we find value in  //Menu Items Search
                    }

                }
            }

            return searchedItems.OrderBy(e => e.Name).ThenBy(e => e.Suburb).ThenBy(e =>  e.Rank).ToList();
        }
    }
}
