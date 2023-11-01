using System.Collections.Generic;
using System.Data;

namespace Assignment6
{

    class planeControl
    {
        clsDataAccess db = new clsDataAccess();

        string sSQL;    //Holds an SQL statement
        int iRetPlane = 0;   //Number of return values
        DataSet dsPlane = new DataSet();
        int iRetPassenger = 0;   //Number of return values
        DataSet dsPassenger = new DataSet();
        List<PlaneDetail> planes = new();
        public planeControl()
        {
            string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
            dsPlane = db.ExecuteSQLStatement(sSQL, ref iRetPlane);


            int x = 0;
            string y;
            for (int plane = 0; plane < iRetPlane; plane++)
            {
                bool res;
                int id = (int)dsPlane.Tables[0].Rows[plane]["Flight_ID"];
                res = int.TryParse(dsPlane.Tables[0].Rows[plane]["Flight_Number"].ToString(), out int flightNumber);
                string flightName = (string)dsPlane.Tables[0].Rows[plane]["Aircraft_Type"];
                planes.Add(new PlaneDetail(id, flightNumber, flightName));
                sSQL = "SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
              "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
          "WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
          "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
          "FLIGHT.FLIGHT_ID =" + id;
                dsPassenger = db.ExecuteSQLStatement(sSQL, ref iRetPassenger);
                for(int passenger = 0;  passenger < iRetPassenger; passenger++)
                {
                    int passengerId = (int)dsPassenger.Tables[0].Rows[passenger]["Passenger_ID"];
                    string firstName = (string)dsPassenger.Tables[0].Rows[passenger]["First_Name"];
                    string lastName = (string)dsPassenger.Tables[0].Rows[passenger]["Last_Name"];
                    res = int.TryParse(dsPassenger.Tables[0].Rows[passenger]["Seat_Number"].ToString(), out int seatNumber);
                    planes[plane].addPassenger(seatNumber, new PassengerDetail(passengerId, firstName, lastName));
                }



            }


        }



    }
}
