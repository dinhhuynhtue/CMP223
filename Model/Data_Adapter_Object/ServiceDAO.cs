using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class ServiceDAO
    {
        RestaurantManagementDbContext db = null;
        public ServiceDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public short Insert(Service entity)
        {
            db.Services.Add(entity);
            db.SaveChanges();
            return entity.Service_ID;
        }
        public bool Update(Service entity)
        {
            try
            {
                var service = db.Services.Find(entity.Service_ID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    service.Name = entity.Name;
                }
                if (!string.IsNullOrEmpty(entity.Detail))
                {
                    service.Detail = entity.Detail;
                }
                if (!string.IsNullOrEmpty(entity.Images))
                {
                    service.Images = entity.Images;
                }
                service.ModifiedDate = DateTime.Now;
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
                var service = db.Services.Find(id);
                db.Services.Remove(service);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Service GetByServiceID(string name)
        {
            return db.Services.SingleOrDefault(X => X.Name == name);
        }
        public Service ViewDetail(short id)
        {
            return db.Services.Find(id);
        }
        public IEnumerable<Service> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Service> model = db.Services;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
