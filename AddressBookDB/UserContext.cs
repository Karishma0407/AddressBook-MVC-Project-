using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class UserContext
    {
        AddressBookDBEntities _Ctx;

        public UserContext()
        {
            _Ctx = new AddressBookDBEntities();
        }

        public AddressBookDBEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}
