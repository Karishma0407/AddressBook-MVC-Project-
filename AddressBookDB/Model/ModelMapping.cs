using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Model
{
    public class ModelMapping
    {
        public User LoadUser(AddressBookDB.user usr)
        {
            return new User
            {
                userId = usr.userId,
                firstName = usr.firstName,
                lastName = usr.lastName,

                fullName = usr.firstName.Trim() + " " + usr.lastName.Trim(),

                address = usr.address
            };
        }
        public User GetUser(AddressBookDB.user usr)
        {
            return new User
            {
                userId = usr.userId,
                fullName = usr.firstName.Trim() + " " + usr.lastName.Trim(),
                address = usr.address,
                userType = usr.userType
            };
        }
    }
}
