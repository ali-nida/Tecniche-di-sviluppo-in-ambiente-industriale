using System.Web.Mvc;
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
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register user)
        {
            var result = wcf.register(user.username, user.email, user.password);
            if (result.Item1 != null) {
                Session["active_user"] = result.Item1;
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
                Session["active_user"] = result.Item1;
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
            Session["active_user"] = null;
            return RedirectToAction("Index");
        }

    }
}