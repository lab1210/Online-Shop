using Online_Shopping.IService;
using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly ShoppingContext _shop;
        public RegisterService()
        {
            _shop = new ShoppingContext();
        }

        public Register SaveUser(Register register)
        {
            if(register.ConfirmPassword != register.Password)
            {
                throw new Exception("Confirm Password should be the same as password");
            }
            if (_shop.Registers.Any(c => c.Email == register.Email ))
            {
                throw new Exception("User already exists");
            }
            _shop.Registers.Add(register);
            _shop.SaveChanges();
            return register;
        }

        public IEnumerable<Register> AdminList()
        {
            var list = _shop.Registers.Where(c => c.Role == "Admin");
            return list;
        }
        public IEnumerable<Register> DriverList()
        {
            var list = _shop.Registers.Where(c => c.Role == "Driver");
            return list;
        }
    }
}