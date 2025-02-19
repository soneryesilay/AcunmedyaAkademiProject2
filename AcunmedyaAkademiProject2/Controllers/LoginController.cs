using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
          var user = context.Admins.FirstOrDefault(x=> x.Username ==admin.Username && x.Password == admin.Password);
            if (user!= null) { 
               FormsAuthentication.SetAuthCookie(user.Username,true);
                Session["userInfo"]=user.Username;
                return RedirectToAction("CategoryList","AdminCategory");

            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); 
            Session.Abandon(); 
            return RedirectToAction("Index", "Login"); 
        }


    }
}