using Online_Shopping.Models;
using Online_Shopping.Service;
using System;
using System.Text;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;

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
                    string to = register.Email;
                    string from = "oladejiomolabake14@gmail.com";
                    MailMessage mailMessage = new MailMessage(from, to);

                    string viewPath = "~/Views/Admin/welcome.cshtml";
                    string mailbody = RenderViewToString(viewPath, register.LastName + " " + register.FirstName);


                    mailMessage.Subject = "Welcome to Vivi";
                    mailMessage.Body = mailbody;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525);
                    System.Net.NetworkCredential basiccred = new
                        System.Net.NetworkCredential("30e9235dd1ff14", "f6f5991abd4ce8");
                    client.EnableSsl = true;
                    client.Credentials = basiccred;
                    client.Send(mailMessage);
                    return RedirectToAction("LoginPage", "Auth");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        private string RenderViewToString(string viewName,string name)
        {
            ViewData["UserName"] = name;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        [HttpGet]
        public ActionResult logout() 
        {
            _login.ClearStore();
            return RedirectToAction("Index", "Home");
        }
    }
}