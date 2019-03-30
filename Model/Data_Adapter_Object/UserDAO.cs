using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;
using PagedList;

namespace Model.Data_Adapter_Object
{
    public class UserDAO
    {
        RestaurantManagementDbContext db = null;
        public UserDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.User_ID;
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.User_ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Email = entity.Email;
                user.Administrator = entity.Administrator;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User GetByUserID(string userName)
        {
            return db.Users.SingleOrDefault(X => X.Username == userName);
        }
        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Administrator == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
