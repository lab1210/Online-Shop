using Online_Shopping.IService;
using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Online_Shopping.Service
{
    public class LoginService : ILoginService
    {
        private readonly ShoppingContext _context;
        public LoginService()
        {
            _context = new ShoppingContext();
        }

        public Login CheckUser(Login login)
        {
            var registered=_context.Registers.FirstOrDefault(c=>c.Email == login.Email&&c.Password==login.Password);
            if(registered==null)
            {
                throw new Exception("Invalid Email or Password");
            }
            LoginMemo loginMemo = new LoginMemo
            {
                Name=registered.LastName + " "+ registered.FirstName,
                Role=registered.Role,
                Email = registered.Email,

            };
            StoreName(loginMemo.Name);
            StoreRole(loginMemo.Role);
            Storemail(loginMemo.Email);
            login.Role=registered.Role;
            _context.Logins.Add(login);
            
            _context.SaveChanges();
            return login;

        }
        public void StoreName(string name)
        {
            HttpContext.Current.Session["Name"] = name;
        }
        public void Storemail(string mail)
        {
            HttpContext.Current.Session["mail"] = mail;
        }
        public void StoreRole(string role)
        {
            HttpContext.Current.Session["Role"] = role;

        }
        public void ClearStore()
        {
            StoreName(null);
            StoreRole(null);
            Storemail(null);
        }
       

    }
}