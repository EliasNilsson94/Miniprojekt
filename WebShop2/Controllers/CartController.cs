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
    public class CartController : Controller
    {

        public CartService CartService { get; set; }

        public CartController()
        {
            CartService = new CartService();
        }
        public ActionResult Index(int id)
        {
            if (TempData["Init8Error"] != null)
            {
                ViewBag.PayexError = TempData["Init8Error"].ToString();
            }
            
            var cart = CartService.GetCartById(id);
            return View(cart);
        }
        
        public ActionResult GetCart(int customerId)
        {

            
            var cart = CartService.GetCartByCustomerId(customerId);
            if (cart == null)
            {
                return Content("You dont have a cart please add a product");
            } else
            {
                return RedirectToAction("Index", new { id = cart.Id });
            }
            
        }
        
        public ActionResult DeleteCartItem(int cartId, int itemId)
        {
            CartService.DeleteCartItem(itemId);
            return RedirectToAction("Index", new { id = cartId });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteCart(int id)
        {
            CartService.DeleteCart(id);
            return RedirectToAction("Index", "Products");
        }
                
    }

}       