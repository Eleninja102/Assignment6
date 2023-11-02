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
        List<PassengerDetail> seatDetail = new();

        public PlaneDetail(int id, int flightNumber, string name)
        {
            this.id = id;
            this.flightNumber = flightNumber;
            this.name = name;
        }
        public bool addPassenger(PassengerDetail passengerDetail)
        {
            seatDetail.Add(passengerDetail);
            return true;
        }
        public string getPlaneInfo()
        {
            return flightNumber + " - " + name;
        }
        public string getPlaneName()
        {
            return name;
        }
        public List<string> getPassangerName()
        {
            List<string> x = new List<string>();
            foreach(PassengerDetail passangerName in seatDetail)
            {
                x.Add(passangerName.ToString());
            }
            return x;
        }

        public int? getSeatNumber(string passengerName)
        {
            foreach (PassengerDetail passenger in seatDetail)
            {
                if (passenger.ToString() == passengerName)
                {
                    return passenger.SeatNumber;
                }

            }
            return -1;
        }

        public string getSeatColor(string seat)
        {
            bool res = int.TryParse(seat, out int seatNum);
            foreach (PassengerDetail passenger in seatDetail)
            {
                if(passenger.SeatNumber == seatNum)
                {
                    return "red";
                }

            }

            return "blue";
        }

    }
}
