using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class ContactDao
    {
        RestaurantManagementDbContext db = null;

        public ContactDao()
        {
            db = new RestaurantManagementDbContext();
        }

        public long InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.Feedback_ID;
        }
    }
}
