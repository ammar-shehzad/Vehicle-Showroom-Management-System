using Microsoft.AspNetCore.Mvc;
using Vehicle_Showroom_Management_System.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using System.Runtime.ExceptionServices;

namespace Vehicle_Showroom_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly Vehicle_Showroom_Management_System_Context db;
        IWebHostEnvironment env;

        public AdminController(Vehicle_Showroom_Management_System_Context context, IWebHostEnvironment env)
        {
            this.db = context;
            this.env = env;
        }

        //===================================================================

        //==========================================Admin Index(Dashboard)==============================
        public IActionResult Index()
        {
            //=================================First we will check the user is Login?====================

            //if (HttpContext.Session.GetString("username") != null)
            //{

            //}
            //return RedirectToAction("Login");

            HttpContext.Session.SetString("username", "ammar");
            

            return View();

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(admin_register adms)
        {
            var admin = db.admin_Registers.Where(r => r.admin_email == adms.admin_email && r.admin_password == adms.admin_password).FirstOrDefault();





            if (admin != null)
            {
                HttpContext.Session.SetString("username", admin.admin_name);
                HttpContext.Session.SetString("useremail", admin.admin_email);
                HttpContext.Session.SetString("userimage", admin.admin_image);
                return RedirectToAction("Index");
            }
            ViewBag.error = "Invalid User Or Password";

            return View();
        }


        //==========================================Admin Update==============================

        public IActionResult UpdateAdmin()
        {
            return View();
        }


        //==========================================Add Car Brand Starts==============================

        public IActionResult AddBrand()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddBrand(car_brand_view_model cbvm)
        {



            if (ModelState.IsValid)
            {
                var filename = "";

                if (cbvm.Brand_Image != null)
                {
                    var folderpath = Path.Combine(env.WebRootPath, "assetsAdmin","imgs");
                    filename = Guid.NewGuid().ToString() + cbvm.Brand_Image.FileName;
                    var fullpath = Path.Combine(folderpath, filename);
                    cbvm.Brand_Image.CopyTo(new FileStream(fullpath, FileMode.Create));
                }

                Car_Brand cb = new Car_Brand
                {
                    Brand_Name = cbvm.Brand_Name,
                    Brand_Image = filename
                };

                db.car_Brands.Add(cb);
                db.SaveChanges();
                return RedirectToAction("ViewBrand");


            }



            return View();

        }






        //==========================================Add Car Brand Ends==============================


        //==========================================View Car Brand Starts==============================


        public IActionResult ViewBrand()
        {

            //=================================First we will check the user is Login?====================

            if (HttpContext.Session.GetString("username") != null)
            {
                var showBrands = db.car_Brands.ToList();

                return View(showBrands);

            }

            return RedirectToAction("Login");
        }



        //==========================================View Car Brand Ends==============================


        //==========================================Delete Car Brand Starts==============================
        public IActionResult DeleteBrand(int? Brand_Id)
{
            var delid = db.car_Brands.Find(Brand_Id);
            db.car_Brands.Remove(delid);
            db.SaveChanges();

            return RedirectToAction("ViewBrand");
        }

        //==========================================Delete Car Brand Ends==============================


        //=================================================Add Vehicle Branch Starts =============================

        public IActionResult AddBranch()
        {

            //=================================First we will check the user is Login?====================

            if (HttpContext.Session.GetString("username") != null)
            {
                return View();

            }

            return RedirectToAction("Login");
        


            
        }

        [HttpPost]
        public IActionResult AddBranch(branch branch)
        {
            db.Branches.Add(branch);
            db.SaveChanges();


            return View();
        }

        //=================================================Add Vehicle Branch Ends =============================

        //=================================================View Vehicle Branch Ends =============================



        public IActionResult ViewBranch()
        {


            if (HttpContext.Session.GetString("username") != null)
            {
            

            var branches = db.Branches.ToList();

            return View(branches);

            }

            return RedirectToAction("Login");


        }

        //=================================================View Vehicle Branch Ends =============================


        //=================================================Delete Vehicle Branch Starts =============================

        public IActionResult deletebranch(int branch_id)
        {

            var branch_delid=db.Branches.Find(branch_id);

            db.Branches.Remove(branch_delid);
            db.SaveChanges();


            return RedirectToAction("ViewBranch");
        }


        //=================================================Delete Vehicle Branch Ends =============================

        //==========================================Purchase Vehicle  From Company Starts================================
        //work later
        public IActionResult CompanyPurchase()
        {
            return View();
        }

        //==========================================Purchase Vehicle  From Company Ends================================




        //==========================================Add Vehicle start================================

        //----------------------This Is For View------------------------

        public IActionResult AddVehicle()
        {

            if (HttpContext.Session.GetString("username") != null)
            {

                // selectlist for carbrand

                var brandlist = db.car_Brands.ToList();
                var brandsli = new List<SelectListItem>();

                foreach (var brand in brandlist)
                {
                    brandsli.Add(

                        new SelectListItem
                        {
                            Text = brand.Brand_Name,
                            Value = brand.Brand_Id.ToString()
                        }

                        );

                }

                 ViewBag.brandsli=brandsli;

                // seectlist for car branch

                var branchlist = db.Branches.ToList();
                var branchsli = new List<SelectListItem>();

                foreach (var branch in branchlist)
                {
                    branchsli.Add(

                        new SelectListItem
                        {
                            Text = branch.branch_name,
                            Value = branch.branch_id.ToString()
                        }

                        );

                }

                ViewBag.branchsli = branchsli;




                return View();

            }

            return RedirectToAction("Login");


        }


        //----------------------This Is For Form Submit------------------------
        [HttpPost]
        public IActionResult AddVehicle(vehicle_view_model v1)
        {

            if (ModelState.IsValid)
            {



                var filename = "";

                //---------------------------Image Upload Work starts---------------

                if (v1.vehicle_image != null)
                {

                    var folderpath = Path.Combine(env.WebRootPath,"assetsAdmin","imgs");

                    var extension =Path.GetExtension(v1.vehicle_image.FileName);

                    filename = Guid.NewGuid().ToString() + extension;

                    var fullpath=Path.Combine(folderpath,filename);

                    v1.vehicle_image.CopyTo(new FileStream(fullpath, FileMode.Create)); 
                }

                //---------------------------Image Upload Work Ends---------------


//---------------------------------------Add Vehicle Work Start----------------------------

                Vehicle v2= new Vehicle
                {
                    vehicle_name = v1.vehicle_name,
                    car_brand_id= v1.car_brand_id,
                    vehicle_model_number = v1.vehicle_model_number,
                    vehicle_price = v1.vehicle_price,
                    Color=v1.Color,
                    FuelType=v1.FuelType,
                    QuantityAvailable=v1.QuantityAvailable,
                    EngineCapacity=v1.EngineCapacity,
                    Status=v1.Status,
                    branch_id=v1.branch_id,
                    vehicle_image=filename


                };



                 HttpContext.Session.SetString("vehicle_Img", v2.vehicle_image);
                ViewBag.vehicle_img = HttpContext.Session.GetString("vehicle_Img");

                db.Vehicles.Add(v2);
                db.SaveChanges();

                //======================================After adding the vehicle it will also registered in Vehicle registration  table(starts)=======================


                Random random = new Random();
                for (var i=0; i<v1.QuantityAvailable;i++)
                {

                    Vehicle_registration vehicle_Registration = new Vehicle_registration
                    {
                        registration_vehicle_id = v2.vehicle_id,
                        registration_branch_id = v2.branch_id,
                        registration_brand_id=v2.car_brand_id,

                        registration_chassis_Number = "chas" + random.Next(10000000, 99999999).ToString(),                       
                        Registration_Number = "Car" + random.Next(100, 5000).ToString(),

                    };

                    db.vehicle_Registrations.Add(vehicle_Registration);
                    db.SaveChanges();

                }

                //======================================After adding the vehicle it will also registered in Vehicle registration  table (ends)=====================







                //---------------------------------------Add Vehicle Work Ends----------------------------


            }

            return RedirectToAction("ShowVehicle");
            
        }


        //==========================================Add Vehicle  ends================================



        //==========================================Show  Vehicle  Starts================================
        //----------------------This Is For View------------------------
        public IActionResult ShowVehicle()
        {
            if (HttpContext.Session.GetString("username") != null)
            {

                //------------------------------List work starts----------------------


                var showVehicleList = db.Vehicles.Include(v => v.car_Brand).Include(b => b.car_branch).ToList();
                    ;




                //------------------------------List work Ends----------------------


                return View(showVehicleList);


            }

            return RedirectToAction("Login");
        }





        //==========================================Show Vehicle  ends================================



        //==========================================Update  Vehicle  Starts================================

        public IActionResult UpdateVehicle (int? Vehicle_id)
        {
           

            if (Vehicle_id != null)
            {
                var UpVehicleData = db.Vehicles.Find(Vehicle_id);

                vehicle_view_model v1 = new vehicle_view_model
                {
                    vehicle_id = UpVehicleData.vehicle_id,
                    vehicle_name = UpVehicleData.vehicle_name,
                    vehicle_model_number = UpVehicleData.vehicle_model_number,
                    vehicle_price = UpVehicleData.vehicle_price,
                    car_brand_id=UpVehicleData.car_brand_id,
                    Color=UpVehicleData.Color,
                    FuelType=UpVehicleData.FuelType,
                    EngineCapacity=UpVehicleData.EngineCapacity,
                    QuantityAvailable=UpVehicleData.QuantityAvailable,
                    Status=UpVehicleData.Status
                  
                };


                //SelectList work starts

                var brandlist = db.car_Brands.ToList();
                var brandsli = new List<SelectListItem>();

                foreach (var brand in brandlist)
                {
                    brandsli.Add(

                        new SelectListItem
                        {
                            Text = brand.Brand_Name,
                            Value = brand.Brand_Id.ToString()
                        }

                        );

                }

                ViewBag.brandsli = brandsli;

                //SelectList work Ends

                HttpContext.Session.SetString("vehicle_Img", UpVehicleData.vehicle_image);

                ViewBag.vehicle_img = HttpContext.Session.GetString("vehicle_Img");


            return View(v1);


            }


            return NotFound();

        }


        //==========================================Update Vehicle  ends================================
        
        //==========================================Delete Vehicle  Starts================================

        public IActionResult DeleteVehicle(int? Vehicle_id)
        {
            var deldata = db.Vehicles.Find(Vehicle_id);
            db.Vehicles.Remove(deldata);
            db.SaveChanges();


            return RedirectToAction( "ShowVehicle");
        }


        //==========================================Delete Vehicle  ends================================
        
        
        //==========================================Show Vehicle  registration starts================================
        
        public IActionResult ShowRegisteredVehicles()
        {
            var vehicleregistrations = db.vehicle_Registrations.Include(v => v.Vehicle).Include(b => b.branch).Include(cb => cb.car_Brand).ToList();


            return View(vehicleregistrations);
        }
        
        //==========================================Show Vehicle  registration ends================================
        
        //==========================================Search Vehicle work starts================================
        


        public IActionResult vehicleSearch()
        {

            //first check if the admin is logged in?
  if (HttpContext.Session.GetString("username") != null)
            {

                //Vehicle list starts            

                var vehicleList = db.Vehicles.ToList();
                var vehicleSli = new List<SelectListItem>();

                foreach (var vehiList in vehicleList)
                {
                    vehicleSli.Add(

                        new SelectListItem
                        {
                            Text = vehiList.vehicle_name,
                            Value = vehiList.vehicle_id.ToString(),
                        }

                    );



                }

                ViewBag.vehiicleList = vehicleSli;


                //Vehicle list starts

                //branch list starts

                var branchlist = db.Branches.ToList();
                var branchSli = new List<SelectListItem>();


                foreach (var branch in branchlist)
                {
                    branchSli.Add(
                        new SelectListItem
                        {
                            Text = branch.branch_name,
                            Value = branch.branch_id.ToString(),
                        }

                        );

                }

                ViewBag.branchList = branchSli;

                //branch list ends



                return View();
            }
            return RedirectToAction("Login");



        }




        [HttpPost]
        public IActionResult vehicleSearch(searchVehicle sv)
        {

            if (ModelState.IsValid)
            {


                var showVehicleList = db.Vehicles.Where(search => search.vehicle_id == sv.Search_vehicle_Name && search.branch_id == sv.Search_vehicle_Branch).Include(v => v.car_Brand).Include(b => b.car_branch).ToList();


                if (showVehicleList.Any())
                {
                    return View("ShowVehicle", showVehicleList);
                }


            }


                return NotFound("Vehicle Not Found");


        }


        //==========================================Search Vehicle work Ends================================




        //================================================================
    }
}

