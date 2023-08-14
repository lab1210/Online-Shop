using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface ILoginService
    {
        Login CheckUser(Login login);
        void Storemail(string mail);

        void StoreName(string name);
        void StoreRole(string role);
        void ClearStore();
    }
}
