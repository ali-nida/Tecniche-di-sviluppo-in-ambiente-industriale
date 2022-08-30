using System.Collections.Generic;
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
            var result = wcf.register(user.username, user.email, user.password);
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
            if (page < 0) { page = 0; }
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
            Sito.ServiceReference2.Product prod = product.toInternalProduct();
            if (prod == null)
            {
                ModelState.AddModelError("", "Si è verificato un errore durante la creazione del prodotto.");
                return View();
            }

            var result = wcf.addProduct(prod);
            if (result.Item1 == -1)
            {
                ModelState.AddModelError("", result.Item2);
                return View();
            }

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
                return View();
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
            ProductDetails mdl = Sito.Models.ProductDetails.fromClassi(result.Item1);
            return View(mdl);
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}