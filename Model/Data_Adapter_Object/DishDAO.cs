using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class DishDAO
    {
        RestaurantManagementDbContext db = null;
        public DishDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public short Insert(Dish entity)
        {
            db.Dishes.Add(entity);
            db.SaveChanges();
            return entity.Dish_ID;
        }
        public bool Update(Dish entity)
        {
            try
            {
                var dish = db.Dishes.Find(entity.Dish_ID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    dish.Name = entity.Name;
                }
                if (!string.IsNullOrEmpty(entity.Detail))
                {
                    dish.Detail = entity.Detail;
                }
                dish.Type_ID = entity.Type_ID;
                if (!string.IsNullOrEmpty(entity.Description))
                {
                    dish.Description = entity.Description;
                }
                dish.Images = entity.Images;
                dish.Price = entity.Price;
                dish.TopHot = entity.TopHot;
                dish.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(short id)
        {
            try
            {
                var dish = db.Dishes.Find(id);
                db.Dishes.Remove(dish);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Dish GetByDishID(string name)
        {
            return db.Dishes.SingleOrDefault(X => X.Name == name);
        }
        public Dish ViewDetail(short id)
        {
            return db.Dishes.Find(id);
        }
        public IEnumerable<Dish> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Dish> model = db.Dishes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.Type_ID).ToPagedList(page, pageSize);
        }
    }
}
