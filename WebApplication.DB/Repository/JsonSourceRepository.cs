using System;
using System.Collections.Generic;
using WebApplication.DB.DataSource;
using WebApplication.DB.Entities;
using WebApplication.Interface;

namespace WebApplication.DB.Repository
{
    public class JsonSourceRepository : IDataSourceAction
    {
        public List<RestaurantInfo> Find(string text)
        {
            try
            {
                var restaurantInfo = JsonData.GetJsonRestaurantInfo();


                return restaurantInfo;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
