using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;

namespace Model.Data_Adapter_Object
{
    public class MenuDAO
    {
        RestaurantManagementDbContext db = null;
       public MenuDAO()
        {
            db = new RestaurantManagementDbContext();
        }

        public List<FoodType> ListAll()
        {
            return db.FoodTypes.OrderBy(x=>x.Type_ID).ToList();
        }
    }
}
