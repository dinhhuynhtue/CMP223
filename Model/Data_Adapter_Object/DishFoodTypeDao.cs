using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;

namespace Model.Data_Adapter_Object
{
    public class DishFoodTypeDao
    {
        RestaurantManagementDbContext db = null;

        public DishFoodTypeDao()
        {
            db = new RestaurantManagementDbContext();
        }

        public FoodType ViewDetail(int id)
        {
            return db.FoodTypes.Find(id);
        }

        public object ListByFoodTypeId()
        {
            throw new NotImplementedException();
        }

        public List<Dish> ListByFoodTypeId(int typeID)
        {
            return db.Dishes.Where(x => x.Type_ID == typeID).ToList();
        }
    }

}
