using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Model
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string fullName { get; set; }

        public string address { get; set; }
        public Nullable<int> typeId { get; set; }

    }
}
