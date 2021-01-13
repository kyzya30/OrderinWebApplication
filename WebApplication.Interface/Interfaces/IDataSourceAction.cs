using System.Collections.Generic;
using WebApplication.DB.Entities;

namespace WebApplication.Interface
{
    public interface IDataSourceAction
    {
        public List<RestaurantInfo> GetData();
    }
}
