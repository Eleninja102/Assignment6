using System;
using System.Collections.Generic;
using System.Reflection;

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

            try
            {
                this.id = id;
                this.flightNumber = flightNumber;
                this.name = name;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        public bool addPassenger(PassengerDetail passengerDetail)
        {
            try
            {
                seatDetail.Add(passengerDetail);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        public string getPlaneInfo()
        {
            try
            {
                return flightNumber + " - " + name;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        public string getPlaneName()
        {
            try
            {
                return name;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        public List<string> getPassangerName()
        {

            try
            {
                List<string> x = new List<string>();
                foreach (PassengerDetail passangerName in seatDetail)
                {
                    x.Add(passangerName.ToString());
                }
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        public int? getSeatNumber(string passengerName)
        {

            try
            {
                foreach (PassengerDetail passenger in seatDetail)
                {
                    if (passenger.ToString() == passengerName)
                    {
                        return passenger.SeatNumber;
                    }

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        public string getSeatColor(string seat)
        {

            try
            {
                bool res = int.TryParse(seat, out int seatNum);
                foreach (PassengerDetail passenger in seatDetail)
                {
                    if (passenger.SeatNumber == seatNum)
                    {
                        return "red";
                    }

                }

                return "blue";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

    }
}
