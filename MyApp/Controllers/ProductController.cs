using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration Configuration;

        public ProductController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index(string search)
        {
            
            ProductRepository ProRepo = new ProductRepository();
            if (search == null)
            {
                return View(ProRepo.GetAllProducts(this.Configuration.GetConnectionString("DefaultConnection")));

            }
            //else
            //{
            //    var products = from product in prorepo.products select product;
            //    products = products.Where(product => product.Name.ToUpper().Contains(search.ToUpper()));
            //    return View(products.ToList());
            //}
            return View();
        }
        public ActionResult GetAllProducts()
        {

            ProductRepository ProRepo = new ProductRepository();
            ModelState.Clear();
            return View(ProRepo.GetAllProducts(this.Configuration.GetConnectionString("DefaultConnection")));
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public IActionResult AddProduct(Product Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRepository ProRepo = new ProductRepository();

                    if (ProRepo.AddProduct(Emp, this.Configuration.GetConnectionString("DefaultConnection")))
                    {
                        ViewBag.Message = "Product added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewPro(int? id)
        {
            ProductRepository ProRepo = new ProductRepository();
            ModelState.Clear();
            return View(ProRepo.GetData(id, this.Configuration.GetConnectionString("DefaultConnection")));
        }

        // GET: Product/EditProduct   
        public ActionResult EditProduct(int id)
        {
            ProductRepository ProRepo = new ProductRepository();
            var Product = ProRepo.GetAllProducts(this.Configuration.GetConnectionString("DefaultConnection")).Find(Emp => Emp.ProductId == id);
            return View(Product);

        }

        // POST: Product/EditProduct   
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditProduct(int id, Product obj)
        {
            try
            {
                ProductRepository EmpRepo = new ProductRepository();

                EmpRepo.UpdateProduct(obj, this.Configuration.GetConnectionString("DefaultConnection"));
                return RedirectToAction("GetAllProducts");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/DeleteProduct   
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                ProductRepository ProRepo = new ProductRepository();
                if (ProRepo.DeleteProduct(id, this.Configuration.GetConnectionString("DefaultConnection")))
                {
                    ViewBag.AlertMsg = "Product details deleted successfully";

                }
                return RedirectToAction("GetAllProducts");

            }
            catch
            {
                return View();
            }
        }
    }
}
