using System.Collections.Generic;
using WebApplication.DB.Entities;

namespace WebApplication.Interface
{
    public interface IDataSourceAction
    {
        public List<RestaurantInfo> Find(string text);
    }
}
