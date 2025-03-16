using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Vehicle_Showroom_Management_System.Models;

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

        //===============================Customer login Work Ends=====================


        //===============================View Products Description Starts=====================

        public IActionResult viewSingleProduct(int? pro_id)
        {
            var product_id = pro_id;
            var pro_desc = db.Vehicles.Include(v => v.car_Brand).Include(b => b.car_branch).FirstOrDefault(v => v.vehicle_id == product_id);

            return View(pro_desc);
        }


        //===============================View Products Description Ends=====================



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
