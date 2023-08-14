using Online_Shopping.Models;
using Online_Shopping.Service;
using System;
using System.Web.Mvc;

namespace Online_Shopping.Controllers
{
    public class AuthController : Controller
    {
        private readonly LoginService _login;
        private readonly RegisterService _register;
        public AuthController()
        {
            _login = new LoginService();
            _register = new RegisterService();
        }

        // GET: Auth
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   _login.CheckUser(login);
                    if (login.Role == "Admin")
                    {
                        return RedirectToAction("DashBoard", "Admin");

                    }
                    if (login.Role == "Driver")
                    {
                        return RedirectToAction("ChooseClient", "Admin");

                    }
                    return RedirectToAction("Index", "Home");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }
        public ActionResult RegistrationPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationPage(Register register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    register.Role = "User";
                    _register.SaveUser(register);
                    return RedirectToAction("LoginPage", "Auth");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult logout() 
        {
            _login.ClearStore();
            return RedirectToAction("Index", "Home");
        }
    }
}