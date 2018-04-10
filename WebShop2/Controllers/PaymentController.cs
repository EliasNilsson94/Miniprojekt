using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop2.BOL;
using WebShop2.Extensions;
using WebShop2.Models;

namespace WebShop2.Controllers
{
    public class PaymentController : Controller
    {
        public OrderService OrderService { get; set; }
        public CartService CartService { get; set; }

        public UserService UserService { get; set; }

        public PayexService PayexService { get; set; }

        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public PaymentController()
        { 
            OrderService = new OrderService();
            CartService = new CartService();
            PayexService = new PayexService();
            UserService = new UserService();
        }

        // GET: Payment
        public ActionResult Index(int id)
        {
            var model = OrderService.getOrderFromId(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(int id, Cart customerCart)
        {
            var cart = CartService.GetCartById(id);
            //comment
            cart.Customer = customerCart.Customer;

            var dbOrder = OrderService.addOrder(cart.ToOrder());
            CartService.DeleteCart(id);

            return RedirectToAction("Order", dbOrder);
        }

        public ActionResult Order([Bind(Include = "Id,Customer,CustomerID,OrderParts")] Order order)
        {
            var model = OrderService.getOrderFromId(order.Id);
            return View(model);
        }

        public ActionResult PayexPurchase(int id)
        {
            var cart = CartService.GetCartById(id);

            var payexRespone = PayexService.initialize8(cart);

            if (!PayexService.Initialize8Successfull(payexRespone))
            {
                log.Debug("Initialize8 Errorcode: " + payexRespone.ErrorCode + " Description: " + payexRespone.Description);
                //TODO: visa cartsidan med en felmedelande

                TempData["Init8Error"] = "Det gick inte att slutföra köpet";
                return RedirectToAction("Index", "Cart", new { id = cart.Id });
            } else
            {
                return Redirect(payexRespone.RedirectURL);
            }
            
        }

        public ActionResult PayexComplete(string orderRef)
        {
            var completeResponse = PayexService.Complete(orderRef);

            if (PayexService.IsTrasactionSuccessfull(completeResponse))
            {
                var cart = CartService.GetCartByCustomerId(UserService.GetCurrentCustomer().Id);
                var dbOrder = OrderService.addOrder(cart.ToOrder());
                CartService.DeleteCart(cart.Id);

                log.Debug("Transaction successfull - TransactionRef:" + completeResponse.TransactionRef + " TransactionStatus: " + completeResponse.TransactionStatus);

                return RedirectToAction("Order", dbOrder);
                
            } else
            {
                var userId = UserService.GetCurrentCustomer().Id;
                ViewBag.PayexError = "Purchase failed please try again. Description: " + completeResponse.Description;

                log.Debug("Transaction failed - ErrorCode: " + completeResponse.ErrorCode + " Description: " + completeResponse.Description);

                return RedirectToAction("Index", "Cart", new { id = CartService.GetCartByCustomerId(userId).Id });  

            }
            
        }
    }
}