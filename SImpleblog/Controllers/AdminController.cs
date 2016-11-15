using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;
using System.Web.Security;


namespace SimpleBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Manage");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(Membership.ValidateUser(model.UserName, model.Password))
                {                    
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    if(!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Manage");
                }

                ModelState.AddModelError("", "The user name of password provided is incorrect");
            }

            return View();

        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}