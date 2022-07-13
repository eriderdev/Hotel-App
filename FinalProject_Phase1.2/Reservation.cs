using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Phase1
{
    public class Reservation
    {
        private string _hotelLocation;
        private string _roomType;
        private DateTime _arrivalDate=DateTime.Today;
        private DateTime _departureDate = DateTime.Today.AddDays(1);
        private double _pricePerNight;
        private double _roomTotal;
        private int _resID;
        private string _receipt;

        //constructor
        public Reservation()
        {
        }

        public Reservation(string hotelLocation, string roomType, DateTime arrivalDate, DateTime departureDate, double pricePerNight, double roomTotal, int resID)
        {
            _hotelLocation=hotelLocation;
            _roomType = roomType;
            _arrivalDate = arrivalDate;
            _departureDate = departureDate;
            _pricePerNight = pricePerNight;
            _roomTotal = roomTotal;
            _resID = resID;
        }

        //properties
        public string HotelLocation
        {
            get { return _hotelLocation; }
            set { _hotelLocation = value; }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        public DateTime ArrivalDate
        {
            get { return _arrivalDate; }//return in date format to take out time?
            set { _arrivalDate = value; }
        }

        public DateTime DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        public double PricePerNight
        {
            get { return _pricePerNight; }
            set { _pricePerNight = value; }
        }
        public double RoomTotal
        {
            get { return _roomTotal; }
            set { _roomTotal = value; }
        }

        public int ResID
        {
            get { return _resID; }
            set { _resID = value; }
        }

        public String ReceiptString
        {
            get { return _receipt; }
            set { _receipt = value; }
        }


    }
}
