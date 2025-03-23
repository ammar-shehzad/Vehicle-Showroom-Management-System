using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Vehicle_Showroom_Management_System.Models;
using Microsoft.AspNetCore.Http;
using System.Xml.Schema;
using NuGet.Versioning;

namespace Vehicle_Showroom_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Vehicle_Showroom_Management_System_Context db;

        public HomeController(ILogger<HomeController> logger, Vehicle_Showroom_Management_System_Context context)
        {
            _logger = logger;
            this.db = context;
        }

        public IActionResult Index()
        {
            ;

            var showproducts =  db.Vehicles.Where(v => v.Status == "Available").ToList();


            return View(showproducts);
        }
        //===============================Customer Registration Work Starts=====================

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customers signup)
{
            if (ModelState.IsValid)
            {
                db.customers.Add(signup);
                db.SaveChanges();
                ViewBag.success = "Registered Successfully";
                return RedirectToAction("login");
            }

            return View();
        }

        //===============================Customer Registration Work Ends=====================


        //===============================Customer Login Work Starts=====================

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string? email,string?password)
        {

            if (ModelState.IsValid)
            {
                var loginData = db.customers.Where(c => c.Customer_email == email && c.Customer_password == password).FirstOrDefault();
                //     var loginData = db.customers
                //.FirstOrDefault(c => c.Customer_email == c1.Customer_email && c.Customer_password == c1.Customer_password);

                

                if (loginData != null)
                {
                    HttpContext.Session.SetInt32("user_id", loginData.Customer_id);
                    HttpContext.Session.SetString("user_name", loginData.Customer_name);

                    ViewBag.username=HttpContext.Session.GetString("user_name");

                    return RedirectToAction("Index");
                }

            }

            ViewBag.error = "Invalid User Or Password";

            return View();
        }

        //===============================Customer login Work Ends=====================


        //===============================Customer log out Work Starts=====================
        public IActionResult logout()
        {
            HttpContext.Session.Remove("user_name");
            return RedirectToAction("login");
        }


        //===============================Customer login Out Work Ends=====================


        //===============================View Products Description Starts=====================

        public IActionResult viewSingleProduct(int? pro_id)
        {
            if (HttpContext.Session.GetString("user_name") != null)
            {


            var product_id = pro_id;
            var pro_desc = db.Vehicles.Include(v => v.car_Brand).Include(b => b.car_branch).FirstOrDefault(v => v.vehicle_id == product_id);

            return View(pro_desc);
            }

            return RedirectToAction("login");
        }


        //===============================View Products Description Ends=====================


        //===============================Add Cart Item Work Starts=====================

        public IActionResult MyCart()
        {

            if (HttpContext.Session.GetString("user_name") != null)

            {

                var cid = HttpContext.Session.GetInt32("user_id");
                var showCart = db.cart_Items.Where(c => c.customer_id == cid && c.order_id == null).Include(v => v.cart_vehicle).ToList();

                if (showCart.Any())
                {



                    var total = 0;
                    total += db.cart_Items.Where(v => v.cart_vehicle != null).Sum((c => c.product_quantity * c.cart_vehicle.vehicle_price ?? 0));
                    var shipment = (total * 5) / 100;
                    var grandtotal = total + shipment;
                    HttpContext.Session.SetInt32("total", total);
                    HttpContext.Session.SetInt32("shipment", shipment);
                    HttpContext.Session.SetInt32("grandtotal", grandtotal);


                    return View(showCart);

                }
                if (showCart == null || !showCart.Any())
                {
                    ViewBag.emptyCart = "Your Cart Is Empty";
                    showCart = new List<cart_item>();
                    return View(showCart);
                }

            }


                return RedirectToAction("login");

            
        }

        [HttpPost]
        public IActionResult MyCart(int? pro_id,int? pro_qty)
        {

            var cid = HttpContext.Session.GetInt32("user_id");
            var RecentCart = db.cart_Items.Where(c => c.vehicle_id == pro_id && c.order_id == null).FirstOrDefault();


            if (RecentCart != null)
            {

              RecentCart.product_quantity += pro_qty;

                db.cart_Items.Update(RecentCart);
                db.SaveChanges();

            }
            else
            {

                cart_item cart_Item = new cart_item
                {
                    customer_id = cid,
                    vehicle_id = pro_id,
                    product_quantity = pro_qty,
                    order_id = null

                };

                db.cart_Items.Add(cart_Item);
                db.SaveChanges();
            }

            
            return RedirectToAction("MyCart");

        }

        //===============================Add Cart Item Work Ends=====================



        //===============================Checkout Work starts=====================

        public IActionResult checkout(int? cust_id)
        {
            var FindForCheckout = db.customers.Find(cust_id);
            ViewBag.FindForCheckout = FindForCheckout;

            //var update_cart_item = db.cart_Items.Find(cust_id);

            //ViewBag.cart=update_cart_item;


            return View();


        }


        [HttpPost]
        public IActionResult checkout(order o1)
        {
            var cid = HttpContext.Session.GetInt32("user_id");

            if (ModelState.IsValid)
            {

                order o2 = new order
                {
                    cust_id = o1.cust_id,
                    firstname = o1.firstname,
                    address = o1.address,
                    city = o1.city,
                    state = o1.state,
                    zip_code = o1.zip_code,
                    phone = o1.phone,
                    email = o1.email,
                    payment_method = o1.payment_method,
                    order_amount = o1.order_amount,
                    order_note = o1.order_note,
                    order_status = "pending",
                    country = o1.country


                };

                db.orders.Add(o2);
                db.SaveChanges();




                var cartitems = db.cart_Items.Where(c => c.customer_id == cid && c.order_id == null).ToList();
                foreach (var items in cartitems)
                {
                    items.order_id = o2.order_id;
                    db.cart_Items.Update(items);

                }
                    db.SaveChanges(true);

                 

                return RedirectToAction("MyOrders");
            }
            return View();
        }














        //===============================Checkout Work Ends=====================


        public IActionResult MyOrders()
        {
            var showOrders = db.cart_Items.Where(o=>o.cart_order.order_status== "pending").Include(co=>co.cart_order).Include(cus=>cus.cart_customers).Include(cv=>cv.cart_vehicle).ToList();


            return View(showOrders);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
