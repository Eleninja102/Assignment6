using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class PassengerDetail
    {
        int id;
        string firstname;
        string lastname;

        public PassengerDetail(int id, string firstname, string lastname)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }
}
