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
            try
            {
                //pagina nella quale l' utente inserisce i dati per la registrazione
                string l = "Signup successful!";
                User ut = new User();
                ut.username = user.username;
                ut.password = user.password;
                ut.email = user.email;
                var risultato = wcf.register(ut);
                if (risultato == null) throw new Exception("Registration failed");
                Session["utenteAttivo"] = risultato;
                MessageBox.Show(l);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("LogOnError", e.Message);
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}