using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class PassengerDetail
    {
        private int id;
        private readonly string firstName;
        private readonly string lastName;
        private readonly int? seatNumber;

        public PassengerDetail(int id, string firstName, string lastName, int? seatNumber = null)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.seatNumber = seatNumber;
        }

        public int? SeatNumber
        {
            get
            {
                return seatNumber;
            }
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
        
    }
}
