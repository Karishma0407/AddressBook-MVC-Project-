using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Interface
{
    public interface IUserRepository: IDisposable
    {
        IQueryable<user> GetUsers();
        bool IsUserExist(string fName, string lName);
        bool AddUser(string fName, string lName, string Address);
    }
}
