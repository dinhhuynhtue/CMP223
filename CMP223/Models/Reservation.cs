using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP223.Models
{
    public class Reservation
    {
        RestaurantManagementDbContext db = new RestaurantManagementDbContext();
        public short DishID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }

        public Reservation(short dishID)
        {
            DishID = dishID;
            Dish dish = db.Dishes.Single(x => x.Dish_ID == DishID);
            Name = dish.Name;
            Image = dish.Images;
            Price = dish.Price;
            Quantity = 1;

        }

    }
}