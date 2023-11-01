using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class PlaneDetail
    {
        int id;
        int flightNumber;
        string name;
        Dictionary<int, PassengerDetail> seatDetail = new();

        public PlaneDetail(int id, int flightNumber, string name)
        {
            this.id = id;
            this.flightNumber = flightNumber;
            this.name = name;
        }
        public bool addPassenger(int seatNumber, PassengerDetail passengerDetail)
        {
            seatDetail.Add(seatNumber, passengerDetail);
            return true;
        }
    }
}
