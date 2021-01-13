using System.Collections.Generic;

namespace WebApplication.DB.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
