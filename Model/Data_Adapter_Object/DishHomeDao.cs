using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;
namespace Model.Data_Adapter_Object
{
    public class DishHomeDao
    {
        RestaurantManagementDbContext db = null;
        public DishHomeDao()
        {
            db = new RestaurantManagementDbContext();
        }

        public List<Dish>ListHotDish(int top)
        {
            return db.Dishes.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x=>x.TopHot).Take(top).ToList();
        }
    }
}
