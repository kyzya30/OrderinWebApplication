using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebApplication.DB.Entities;

namespace WebApplication.DB.DataSource
{
    public static class JsonData
    {
        public static List<RestaurantInfo> GetJsonRestaurantInfo()
        {
            List<RestaurantInfo> items = new List<RestaurantInfo>();
            using (StreamReader r = new StreamReader("../WebApplication.DB/Data/SampleData.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<RestaurantInfo>>(json);
            }


            return items;

        }
    }
}
