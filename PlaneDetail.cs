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
        Dictionary<PassengerDetail, int> seatDetail = new();

        public PlaneDetail(int id, int flightNumber, string name)
        {
            this.id = id;
            this.flightNumber = flightNumber;
            this.name = name;
        }
        public bool addPassenger(int seatNumber, PassengerDetail passengerDetail)
        {
            seatDetail.Add(passengerDetail, seatNumber);
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
            string y = seatDetail.Values.ToList().ToString();
            foreach(PassengerDetail passangerName in seatDetail.Keys)
            {
                x.Add(passangerName.ToString());
            }
            return x;
        }

        public int getSeatNumber(string passengerName)
        {
            foreach (PassengerDetail passenger in seatDetail.Keys)
            {
                if (passenger.ToString() == passengerName)
                {
                    return seatDetail.GetValueOrDefault(passenger);
                }

            }
            return -1;
        }

        public string getSeatColor(string seat)
        {
            bool res = int.TryParse(seat, out int seatNum);

            if (!seatDetail.ContainsValue(seatNum))
            {
                return "blue";
            }

            return "red";
        }

    }
}
