using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class CustomerDAO
    {
        RestaurantManagementDbContext db = null;
        public CustomerDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.Customer_ID;
        }
        public IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Phone.Contains(searchString) || x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
        public bool Update(Customer entity)
        {
            try
            {
                var customer = db.Customers.Find(entity.Customer_ID);
                customer.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Phone))
                {
                    customer.Phone = entity.Phone;
                }
                customer.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Customer GetByUserID(string phone)
        {
            return db.Customers.SingleOrDefault(X => X.Phone == phone);
        }
        public Customer ViewDetail(long id)
        {
            return db.Customers.Find(id);
        }
    }
}
