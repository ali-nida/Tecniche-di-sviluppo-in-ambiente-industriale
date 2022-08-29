using System.Collections.Generic;
using System.Web.Mvc;
using Sito.ServiceReference2;
using Sito.Models;

namespace Client.Controllers
{
    public class HomeController : Controller
    {

        public static ECommerceClient wcf = new ECommerceClient();
        public static string active_user = "active_user";
        public static string error = "error";

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

        public ActionResult Products(int page=0)
        {

            User curr_user = (User)Session[active_user];
            bool is_admin = (curr_user != null && curr_user.admin);

            var result = wcf.viewProducts(is_admin, page*10);
            if (result.Item1.Length == 0)
            {
                ModelState.AddModelError("LogOnError", result.Item2);
            }

            // Convert from Classi to Model products
            List<Sito.Models.Product> prodlist = new List<Sito.Models.Product>();
            foreach (Sito.ServiceReference2.Product product in result.Item1) {
                prodlist.Add(Sito.Models.Product.fromClassi(product));
            }

            return View(prodlist);
        }

        public ActionResult AddProduct()
        {
            User curr_user = (User)Session[active_user];
            if (curr_user == null || curr_user.admin == false)
            {
                TempData[error] = "Accesso non autorizzato.";
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}