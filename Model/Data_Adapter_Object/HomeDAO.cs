using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;
namespace Model.Data_Adapter_Object
{
    public class HomeDAO
    {
        RestaurantManagementDbContext db = null;
        public HomeDAO()
        {
            db = new RestaurantManagementDbContext();
        }

        public List<Dish> DishesList(int top)
        {
            return db.Dishes.Where(x => x.TopHot == true).OrderByDescending(x => x.TopHot).Take(top).ToList();
        }
    }
}
