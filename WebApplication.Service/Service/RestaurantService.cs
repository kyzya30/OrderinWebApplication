using System.Threading.Tasks;
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

            json.Find(text);
        }
    }
}
