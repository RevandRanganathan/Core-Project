using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Models;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace MyApp.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index(string search)
        {
            return View();
        }
        private IConfiguration Configuration;

        public SellerController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public ActionResult GetAllSellers()
        {

            SellerRepository ProRepo = new SellerRepository();
            ModelState.Clear();
            return View(ProRepo.GetAllSellers(this.Configuration.GetConnectionString("DefaultConnection")));
        }

        public ActionResult AddSeller()
        {
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public ActionResult AddSeller(Seller Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SellerRepository ProRepo = new SellerRepository();

                    if (ProRepo.AddSeller(Emp, this.Configuration.GetConnectionString("DefaultConnection")))
                    {
                        ViewBag.Message = "Seller added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult ViewSell(int? id)
        //{
        //    SellerRepository ProRepo = new SellerRepository();
        //    ModelState.Clear();
        //    return View(ProRepo.GetData(id));
        //}

        public IActionResult Details(int id)
        {
            SellerProductRepository ProRepo = new SellerProductRepository();
            ModelState.Clear();
            //Session["SellerId"] = id;
            HttpContext.Session.SetInt32("SellerId", id);

            var SellerProd = ProRepo.SellersProduct(id, this.Configuration.GetConnectionString("DefaultConnection"));
            return View(SellerProd);
        }


        public ActionResult AddSellersproduct()
        {
            SellerRepository sr = new SellerRepository();
            ProductRepository pr = new ProductRepository();
            var add = sr.GetAllSellers(this.Configuration.GetConnectionString("DefaultConnection")).Select(i => new { i.SellerId, i.Name });
            ViewBag.SList = add;
            var PList = pr.GetAllProducts(this.Configuration.GetConnectionString("DefaultConnection"));
            List<SelectListItem> FProduct = new List<SelectListItem>();

            foreach (var item in PList)
            {
                FProduct.Add
                    (new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ProductId.ToString()
                    });
            }
            ViewBag.ProList = FProduct;
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public ActionResult AddSellersproduct(SellerProduct Emp)
        {
            try
            {
                Emp.SellerId = (int)HttpContext.Session.GetInt32("SellerId");
                if (ModelState.IsValid)
                {
                    SellerProductRepository ProRepo = new SellerProductRepository();

                    if (ProRepo.AddSellersproduct(Emp, this.Configuration.GetConnectionString("DefaultConnection")))
                    {
                        ViewBag.Message = "Sellers Product added successfully";
                    }
                }

                return RedirectToAction("Details", new { id = Emp.SellerId });
            }
            catch
            {
                return View();
            }
        }


        //public ActionResult DeleteSellerProduct(int id, int SellerId)
        //{
        //    try
        //    {
        //        SellerProductRepository ProRepo = new SellerProductRepository();
        //        if (ProRepo.DeleteSellerProduct(id))
        //        {
        //            ViewBag.AlertMsg = "Seller details deleted successfully";

        //        }
        //        return RedirectToAction("Details", new { id = SellerId });

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // GET: Product/EditProduct   
        public ActionResult EditSeller(int id)
        {
            SellerRepository ProRepo = new SellerRepository();
            var Seller = ProRepo.GetAllSellers(this.Configuration.GetConnectionString("DefaultConnection")).Find(Emp => Emp.SellerId == id);
            return View(Seller);

        }

        // POST: Product/EditProduct   
        [HttpPost]

        public ActionResult EditSeller(int id, Seller obj)
        {
            try
            {
                SellerRepository EmpRepo = new SellerRepository();

                EmpRepo.UpdateSeller(obj, this.Configuration.GetConnectionString("DefaultConnection"));
                return RedirectToAction("GetAllSellers");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/DeleteProduct   
        public ActionResult DeleteSeller(int id)
        {
            try
            {
                SellerRepository ProRepo = new SellerRepository();
                if (ProRepo.DeleteSeller(id, this.Configuration.GetConnectionString("DefaultConnection")))
                {
                    ViewBag.AlertMsg = "Seller details deleted successfully";

                }
                return RedirectToAction("GetAllSellers");

            }
            catch
            {
                return View();
            }
        }
    }
}
