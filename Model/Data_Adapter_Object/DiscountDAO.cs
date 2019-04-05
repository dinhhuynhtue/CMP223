using Model.Entity_Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data_Adapter_Object
{
    public class DiscountDAO
    {
        RestaurantManagementDbContext db = null;
        public DiscountDAO()
        {
            db = new RestaurantManagementDbContext();
        }
        public string Insert(Discount entity)
        {
            db.Discounts.Add(entity);
            db.SaveChanges();
            return entity.Discount_ID;
        }
        public IEnumerable<Discount> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Discount> model = db.Discounts;
            return model.OrderBy(x => x.Discount_ID).ToPagedList(page, pageSize);
        }
        public bool Update(Discount entity)
        {
            try
            {
                var discount = db.Discounts.Find(entity.Discount_ID);
                discount.Rate = entity.Rate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var discount = db.Discounts.Find(id);
                db.Discounts.Remove(discount);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Discount GetByDiscountID(string discount_ID)
        {
            return db.Discounts.SingleOrDefault(X => X.Discount_ID == discount_ID);
        }
        public Discount ViewDetail(string discount_ID)
        {
            return db.Discounts.Find(discount_ID);
        }
    }
}
