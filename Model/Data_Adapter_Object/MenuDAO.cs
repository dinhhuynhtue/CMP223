﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity_Framework;
using System.Data.Entity;

namespace Model.Data_Adapter_Object
{
    public class MenuDAO
    {
        RestaurantManagementDbContext db = null;


        public MenuDAO()
        {
            db = new RestaurantManagementDbContext();
        }

        public List<FoodType> ListAll()
        {
            return db.FoodTypes.OrderBy(x=>x.Type_ID).ToList();
        }

        public List<Dish> ListDish()
        {
            return db.Dishes.ToList();
        }

        
        /// <summary>
        /// Get list Dish by Type ID
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
     


       
    }
}
