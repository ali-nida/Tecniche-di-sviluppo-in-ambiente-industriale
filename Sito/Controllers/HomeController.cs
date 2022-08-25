using System;
using System.Web.Mvc;
using System.Windows.Forms;
using Sito.ServiceReference2;
using Sito.Models;

namespace Client.Controllers
{
    public class HomeController : Controller
    {

        public static ECommerceClient wcf = new ECommerceClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register user)
        {
            string l = "Registrazione completata!";
            var result = wcf.register(user.username, user.email, user.password);

            if (result.Item1 != null) {
                Session["utenteAttivo"] = result.Item1;
                MessageBox.Show(l);
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("LogOnError", result.Item2);
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login user)
        {
            string l = "Login avvenuto con successo!";
            var result = wcf.login(user.email, user.password);

            if (result.Item1 != null) {
                Session["utenteAttivo"] = result.Item1;
                MessageBox.Show(l);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("LogOnError", result.Item2);
                return View();
            }
        }
    }
}