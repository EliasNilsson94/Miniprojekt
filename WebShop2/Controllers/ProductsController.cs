using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop2.BOL;
using WebShop2.DAL;
using WebShop2.Models;

namespace WebShop2.Controllers
{
    public class ProductsController : Controller
    {
        public ProductService ProductService { get; set; }
        public UserService UserService { get; set; }
        public CartService CartService { get; set; }
        private static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public ProductsController()
        {
            ProductService = new ProductService();
            UserService = new UserService();
            CartService = new CartService();
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(ProductService.getAllProducts());
        }
 
        public ActionResult addProductToCart(Product product)
        {
            int customerId = UserService.GetCurrentCustomer().Id;
            var customerCart = CartService.addProductToCart(product, customerId);

            return RedirectToAction("Index", "Cart", new { id = customerCart.Id});
        }
        
        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        /*POST: Products/Create
        To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         more details see https://go.microsoft.com/fwlink/?LinkId=317598.*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,price")] Product product)
        {
            try
            {
                ProductService.addProduct(product);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View(product);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductService.getProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = ProductService.getProduct(id);
            ProductService.removeProduct(product);
            return RedirectToAction("Index");
        }

    }
}
