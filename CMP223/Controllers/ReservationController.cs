using CMP223.Common;
using Model.Entity_Framework;
using Model.Data_Adapter_Object;
using CMP223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Controllers
{
    public class ReservationController : Controller
    {
        RestaurantManagementDbContext db = new RestaurantManagementDbContext();
        public List<Reservation> GetReservation()
        {
            List<Reservation> lstReservation = Session["Reservation"] as List<Reservation>;
            if (lstReservation == null)
            {
                lstReservation = new List<Reservation>();
                Session["Reservation"] = lstReservation;
            }
            return lstReservation;
        }

        public ActionResult AddDish(short dishID, string strURL)
        {
            List<Reservation> lstReservation = GetReservation();
            Reservation dish = lstReservation.Find(x => x.DishID == dishID);
            if (dish == null)
            {
                dish = new Reservation(dishID);
                lstReservation.Add(dish);
                return Redirect(strURL);
            }
            else
            {
                dish.Quantity++;
                return Redirect(strURL);
            }
        }
        private int TotalQuantity()
        {
            int totalquantity = 0;
            List<Reservation> lstReservation = Session["Reservation"] as List<Reservation>;
            if (lstReservation != null)
            {
                totalquantity = lstReservation.Sum(x => x.Quantity);

            }
            return totalquantity;
        }
        private decimal TotalPrice()
        {
            decimal total = 0;
            List<Reservation> lstReservation = Session["Reservation"] as List<Reservation>;
            if (lstReservation != null)
            {
                total = lstReservation.Sum(x => x.Total);

            }
            return total;
        }
        // GET: Reservation
        public ActionResult Reservation()
        {
            List<Reservation> lstReservation = GetReservation();
            if (lstReservation.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return View(lstReservation);
        }
        public ActionResult RemoveDish(short dishID)
        {
            List<Reservation> lstReservation = GetReservation();
            Reservation dish = lstReservation.SingleOrDefault(x => x.DishID == dishID);
            if (dish != null)
            {
                lstReservation.RemoveAll(x => x.DishID == dishID);
                return RedirectToAction("Reservation");
            }
            if (lstReservation.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Reservation");
        }
        [HttpPost]
        public ActionResult UpdateDish(short dishID, FormCollection f)
        {
            List<Reservation> lstReservation = GetReservation();
            Reservation dish = lstReservation.SingleOrDefault(x => x.DishID == dishID);
            if (dish != null)
            {
                dish.Quantity = int.Parse(f["txtQuantity"].ToString());
            }
            return RedirectToAction("Reservation");
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();
                long id = dao.Insert(customer);
                if (id > 0)
                {
                    return Redirect("Reservation");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessfully");
                }
            }
            return Redirect("Reservation");
        }
        public ActionResult Book()
        {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Session[CommonConstants.CUSTOMER_SESSION] == null || Session[CommonConstants.CUSTOMER_SESSION] == "")
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            {
                //return RedirectToAction("Index", "Home");
            }
            if (Session["Reservation"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Reservation> lstReservation = GetReservation();
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return View(lstReservation);
        }
    }
}