using AddressBookDB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class UserRepository: IUserRepository
    {
        UserContext _Ctx;

        public UserRepository(UserContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        //Start Method Development
        public IQueryable<userType> GetUserType()
        {
            return _Ctx.Context.userTypes;
        }

        public IQueryable<user> GetUsers()
        {
            return _Ctx.Context.users;
        }
        public bool IsUserExist(string fName, string lName)
        {
            return true;
        }
        public bool AddUser(string fName, string lName, string Address)
        {
            return true;
        }
        //End Method Development


        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}
