using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface IRegisterService
    {
        Register SaveUser(Register register);
        IEnumerable<Register> AdminList();

        IEnumerable<Register> DriverList();
    }
}
