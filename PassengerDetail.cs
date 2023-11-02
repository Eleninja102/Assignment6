using System;
using System.Reflection;

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

            try
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
                this.seatNumber = seatNumber;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        public int? SeatNumber
        {
            get
            {

                try
                {
                    return seatNumber;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

                }
            }
        }

        public override string ToString()
        {

            try
            {
                return firstName + " " + lastName;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

    }
}
