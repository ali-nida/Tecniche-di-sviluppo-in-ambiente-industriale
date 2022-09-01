﻿using System.Collections.Generic;
using System.Web.Mvc;
using Sito.ServiceReference2;
using Sito.Models;
using System.IO;
using System;

namespace Client.Controllers
{
    public class HomeController : Controller
    {

        public static ECommerceClient wcf = new ECommerceClient();
        // Define the session variable names here once for all

        public static string active_user = "active_user";
        public static string error = "error";
        public static string has_prev_page = "has_prev_page";
        public static string has_next_page = "has_next_page";
        public static string current_page = "current_page";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register user)
        {
            // Call WCF
            var result = wcf.register(user.username, user.email, user.password);
            // If the result isn't null save the user correctly
            if (result.Item1 != null) {
                Session[active_user] = result.Item1;
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("", result.Item2);
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login user)
        {
            var result = wcf.login(user.email, user.password);
            if (result.Item1 != null) {
                Session[active_user] = result.Item1;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Item2);
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session[active_user] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Products(int page = 0)
        {
            // Page number fail safe
            if (page < 0) { page = 0; }
            // Check that the user is admin
            User curr_user = (User)Session[active_user];
            bool is_admin = (curr_user != null && curr_user.admin);

            var result = wcf.viewProducts(is_admin, page);
            if (result.Item1.Length == 0)
            {
                ModelState.AddModelError("LogOnError", result.Item2);
            }

            // Enable page indicators as required
            TempData[has_prev_page] = (page != 0);
            TempData[current_page] = page + 1;
            TempData[has_next_page] = (result.Item1.Length == 13);

            // Remove the last item used for page tracking
            if (result.Item1.Length == 13)
            {
                result.Item1[12] = null;
            }

            // Convert from Classi to Model products
            List<Sito.Models.Product> prodlist = new List<Sito.Models.Product>();
            foreach (Sito.ServiceReference2.Product product in result.Item1) {
                if (product != null)
                {
                    prodlist.Add(Sito.Models.Product.fromClassi(product));
                }
            }

            return View(prodlist);
        }

        public ActionResult AddProduct()
        {
            User curr_user = (User)Session[active_user];
            // Check that the user is admin
            if (curr_user == null || curr_user.admin == false)
            {
                TempData[error] = "Accesso non autorizzato.";
                return RedirectToAction("Error");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(AddProduct product)
        {
            User curr_user = (User)Session[active_user];
            // Check that the user is admin
            if (curr_user == null || curr_user.admin == false)
            {
                TempData[error] = "Accesso non autorizzato.";
                return RedirectToAction("Error");
            }
            // Convert the product into the format expected by WCF

            Sito.ServiceReference2.Product prod = product.toInternalProduct();
            if (prod == null)
            {
                ModelState.AddModelError("", "Si è verificato un errore durante la creazione del prodotto.");
                return View();
            }
            // Add the product to the Database

            var result = wcf.addProduct(prod);
            if (result.Item1 == -1)
            {
                ModelState.AddModelError("", result.Item2);
                return View();
            }

            // Save the uploaded img
            try
            {
                if (product.image_file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), result.Item1.ToString() + ".jpg");
                    product.image_file.SaveAs(path);
                }
                else
                {
                    throw new Exception("File vuoto!");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.ToString());
            }

            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            var result = wcf.viewProductDetails(id);
            if (result.Item1 == null)
            {
                TempData[error] = result.Item2;
                return RedirectToAction("Error");
            }
            // Convert the result into the format expected by the view
            ProductDetails mdl = Sito.Models.ProductDetails.fromClassi(result.Item1);
            return View(mdl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(QuantitySelector selector, bool checkout)
        {
            // Check if the user is logged in correctly
            User curr_user = (User)Session[active_user];
            if (curr_user == null)
            {
                ModelState.AddModelError("", "Devi effettuare l'accesso per compiere questa azione.");
                return RedirectToAction("Login");
            }
            // Check that the quantity isn't a null value
            if (selector.quantity < 1)
            {
                ModelState.AddModelError("", "Quantità selezionata non valida!");
            }
            else
            {
                var result = wcf.createCart(selector.prod_id, curr_user.user_id, selector.quantity);
                if (result.Item1 == false)
                {
                    ModelState.AddModelError("", result.Item2);
                }
            }
            // Return to a different page based on the previous one
            if (checkout)
            {
                return RedirectToAction("Checkout");
            }
            else
            {
                return RedirectToAction("Products");
            }
        }

        public ActionResult Cart()
        {
            User curr_user = (User)Session[active_user];
            if (curr_user == null)
            {
                ModelState.AddModelError("", "Devi effettuare l'accesso per compiere questa azione.");
                return RedirectToAction("Login");
            }

            var result = wcf.viewCarts(curr_user.user_id);
            if (result.Item1.Length == 0)
            {
                ModelState.AddModelError("", result.Item2);
            }

            // Convert results
            List<Sito.Models.Cart> carts = new List<Sito.Models.Cart>();
            foreach (Sito.ServiceReference2.Cart cart in result.Item1)
            {
                if (cart != null)
                {
                    carts.Add(Sito.Models.Cart.fromClassi(cart));
                }
            }

            return View(carts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult removeCart(Sito.Models.Cart cart)
        {
            User curr_user = (User)Session[active_user];
            if (curr_user == null)
            {
                ModelState.AddModelError("", "Devi effettuare l'accesso per compiere questa azione.");
                return RedirectToAction("Login");
            }

            var result = wcf.removeCart(cart.cart_id);
            if (result.Item1)
            {
                ModelState.AddModelError("", result.Item2);
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Checkout() {
            User curr_user = (User)Session[active_user];
            if (curr_user == null)
            {
                ModelState.AddModelError("", "Devi effettuare l'accesso per compiere questa azione.");
                return RedirectToAction("Login");
            }

            var result = wcf.viewCarts(curr_user.user_id);
            if (result.Item1.Length == 0)
            {
                TempData[error] = result.Item2;
                return RedirectToAction("Error");
            }
            // Calculate the total price 
            decimal totalprice = 0;
            foreach(Sito.ServiceReference2.Cart cart in result.Item1)
            {
                Sito.Models.Product product = Sito.Models.Product.fromClassi(cart.product);
                totalprice += product.price * cart.quantity;
            }
            // Pass it to a model
            Checkout checkout = new Checkout()
            {
                price = totalprice
            };

            return View(checkout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(Checkout data)
        {
            //var result = wcf.buy(data.address, data.zip_code, data.credit_card);
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}