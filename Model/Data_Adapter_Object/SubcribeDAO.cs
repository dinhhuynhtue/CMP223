using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class SubcribeDAO
    {
        RestaurantManagementDbContext db = null;
        public SubcribeDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public string Insert(Subcribe entity)
        {
            db.Subcribes.Add(entity);
            db.SaveChanges();
            return entity.Email;
        }
        public IEnumerable<Subcribe> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Subcribe> model = db.Subcribes;
            return model.OrderBy(x => x.Email).ToPagedList(page, pageSize);
        }
        public bool Delete(string id)
        {
            try
            {
                var subcribe = db.Subcribes.Find(id);
                db.Subcribes.Remove(subcribe);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
