using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class DishTypeDAO
    {
        RestaurantManagementDbContext db = null;
        public DishTypeDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public short Insert(DishType entity)
        {
            db.DishTypes.Add(entity);
            db.SaveChanges();
            return entity.Type_ID;
        }
        public bool Update(DishType entity)
        {
            try
            {
                var dishType = db.DishTypes.Find(entity.Type_ID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    dishType.Name = entity.Name;
                }
                if (!string.IsNullOrEmpty(entity.Detail))
                {
                    dishType.Detail = entity.Detail;
                }
                if (!string.IsNullOrEmpty(entity.Images))
                {
                    dishType.Images = entity.Images;
                }
                dishType.ModifiedDate = DateTime.Now;
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
                var dishType = db.DishTypes.Find(id);
                db.DishTypes.Remove(dishType);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DishType GetByTypeID(string name)
        {
            return db.DishTypes.SingleOrDefault(X => X.Name == name);
        }
        public DishType ViewDetail(short id)
        {
            return db.DishTypes.Find(id);
        }
        public IEnumerable<DishType> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DishType> model = db.DishTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) );
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
        public List<DishType> ListAll()
        {
            return db.DishTypes.ToList();
        }
    }
}
