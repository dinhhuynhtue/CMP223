using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;

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
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(X => X.Username == userName);
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
