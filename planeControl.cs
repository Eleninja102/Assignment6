using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Assignment6
{

    /// <summary>
    /// A static method that holds the lists and helps control everything
    /// </summary>
    static class planeControl
    {

        /// <summary>
        /// The list of planes as a PlaneDetail
        /// </summary>
        private static List<PlaneDetail> planes = new();
        /// <summary>
        /// The active plane if a plane has been selected
        /// </summary>
        private static PlaneDetail? activePlane;
        /// <summary>
        /// Adds the sql info to the planes list and adds all the passengers to the list.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void setDatabase()
        {

            try
            {
                DataSet dsPlane = new();
                DataSet dsPassenger = new();
                int iRetPlane = 0;   //Number of return values
                int iRetPassenger = 0;   //Number of return values
                string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
                dsPlane = clsDataAccess.ExecuteSQLStatement(sSQL, ref iRetPlane);

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
                    dsPassenger = clsDataAccess.ExecuteSQLStatement(sSQL, ref iRetPassenger);
                    for (int passenger = 0; passenger < iRetPassenger; passenger++)
                    {
                        int passengerId = (int)dsPassenger.Tables[0].Rows[passenger]["Passenger_ID"];
                        string firstName = (string)dsPassenger.Tables[0].Rows[passenger]["First_Name"];
                        string lastName = (string)dsPassenger.Tables[0].Rows[passenger]["Last_Name"];
                        res = int.TryParse(dsPassenger.Tables[0].Rows[passenger]["Seat_Number"].ToString(), out int seatNumber);
                        planes[plane].addPassenger(new PassengerDetail(passengerId, firstName, lastName, seatNumber));
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// Returns the list of planes
        /// </summary>
        /// <returns>The list of planes and there details</returns>
        /// <exception cref="Exception"></exception>
        public static List<PlaneDetail> getPlaneDetails()
        {

            try
            {
                return planes;  
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// Gets the list of the passengers for a given plane.
        /// </summary>
        /// <param name="stPlaneName">The name of in "flightNumber - name" format</param>
        /// <returns>A list of passengers will be null if no passengers exist</returns>
        /// <exception cref="Exception"></exception>
        public static List<PassengerDetail>? getPassengerName(string stPlaneName)
        {

            try
            {
                foreach (PlaneDetail plane in planes)
                {
                    if (stPlaneName == plane.ToString())
                    {
                        activePlane = plane;
                        return plane.getPassengerName();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        /// <summary>
        /// Given a passengers name it will check if they have a seat number
        /// </summary>
        /// <param name="passengerName">The name of the passenger in "FirstName LastName" format</param>
        /// <returns>The seat number if it exists</returns>
        /// <exception cref="Exception"></exception>
        public static int? getPassengerSeat(string passengerName)
        {
            try
            {
                return activePlane?.getSeatNumber(passengerName);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// The name of the plane if it exist (it always should)
        /// </summary>
        /// <returns>The name of the plane</returns>
        /// <exception cref="Exception"></exception>
        public static string? getPlaneName()
        {
            try
            {
                return activePlane?.getPlaneName();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// Will get the color of the seat given an active plane (can be null but in practice never will be)
        /// </summary>
        /// <param name="seatLabelContent">The content of the seat should be an int as it will get parsed 1,2,3</param>
        /// <returns>The color the seat should be red, blue, green</returns>
        /// <exception cref="Exception"></exception>
        public static string? getSeatColor(string seatLabelContent)
        {
            try
            {
                return activePlane?.getSeatColor(seatLabelContent);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

    }
}
