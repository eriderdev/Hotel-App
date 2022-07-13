using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Phase1
{
    public partial class FormHotelSelection : Form
    {
        //public
        Reservation res = new Reservation();
        public FormHotelSelection()
        {
            InitializeComponent();
            //dateTimePickerArrival.MinDate = DateTime.Today;
            //dateTimePickerDeparture.MinDate = DateTime.Today.AddDays(1);

            lstBxHotelLocation.SelectedIndex = 0;
            lstBxRoomType.SelectedIndex = 0;
            dateTimePickerArrival.Value =res.ArrivalDate;
            dateTimePickerDeparture.Value= res.DepartureDate;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();
        }

        public FormHotelSelection(Reservation r)
        {
            InitializeComponent();
            //dateTimePickerArrival.MinDate = DateTime.Today;
            //dateTimePickerDeparture.MinDate = DateTime.Today.AddDays(1);

            lstBxHotelLocation.Text = r.HotelLocation;
            lstBxRoomType.Text = r.RoomType;
            dateTimePickerArrival.Value = r.ArrivalDate;
            dateTimePickerDeparture.Value = r.DepartureDate;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormWelcome f2 = new FormWelcome();
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            this.Close();
        }

        private void lstBxHotelLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxHotelLocation.Text == "Miami")
            {
                lblInfo.Text = "Hotel C# Miami: includes amenties: pool, valet parking, room service";
                //picBxHotel.Image = Image.FromFile("hotelMiami.jpg");
                //add image as a resource to use in the project
                picBxHotel.Image = Properties.Resources.hotelMiami;
            }
            else if (lstBxHotelLocation.Text == "Fort Lauderdale")
            {
                lblInfo.Text = "Hotel C# Fort Lauderdale: includes amenties: pool, ocean front rooms";
                picBxHotel.Image = Properties.Resources.hotelFtLaud;
            }
            else if (lstBxHotelLocation.Text == "Orlando")
            {
                lblInfo.Text = "Hotel C# Orlando: minutes from amusement parks";
                picBxHotel.Image = Properties.Resources.hotelOrlando2;
            }
            //assign to hotelLocation
            res.HotelLocation = lstBxHotelLocation.Text;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();
        }

        private void lstBxRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstBxRoomType.Text == "1 King Bed")
            {
                //add image as a resource to use in the project
                picBxRoom.Image = Properties.Resources.roomKing;
                //update price per night  
            }
            else if (lstBxRoomType.Text == "2 Queen Beds")
            {
                picBxRoom.Image = Properties.Resources.roomQueen;
            }
            else if (lstBxRoomType.Text == "1 Bedroom Suite")
            {
                picBxRoom.Image = Properties.Resources.roomSuite;
            }
            //assign to roomtype
            res.RoomType = lstBxRoomType.Text;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();
        }

        private void dateTimePickerArrival_ValueChanged(object sender, EventArgs e)
        {
            ////assign to arrivaldate
            res.ArrivalDate = dateTimePickerArrival.Value;
            //change MinDate on departure to arrival date +1?
            dateTimePickerDeparture.MinDate = dateTimePickerArrival.Value.AddDays(1);
            lblReceipt.Text = receiptString();
        }

        private void dateTimePickerDeparture_ValueChanged(object sender, EventArgs e)
        {
            res.DepartureDate = dateTimePickerDeparture.Value;
            //dateTimePickerArrival.MaxDate = dateTimePickerDeparture.Value; //make sure you cant choose a arrival date after selected departure date
            lblReceipt.Text = receiptString();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            //pass res to next form
            FormNewReservation f2 = new FormNewReservation(res);
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            //this.Close();
        }

        public double calculateSubtotal()
        {
            double total = 0.0;
            double nights = (res.DepartureDate - res.ArrivalDate).Days;
            total = res.PricePerNight * nights;
            res.RoomTotal = total;
            return res.RoomTotal;
        }

        public string receiptString()
        {
            res.ReceiptString = "\n\nTotal Number of Nights: "+ (res.DepartureDate - res.ArrivalDate).Days.ToString()+
                "\nPrice Per Night: $"+res.PricePerNight.ToString("#0.00")
                +"\nSubtotal: $" + calculateSubtotal().ToString("#0.00")
                + "\nTaxes: $"+ (calculateSubtotal()*.065).ToString("#0.00")
                + "\nTOTAL: $" + (calculateSubtotal() * 1.065).ToString("#0.00");
            return res.ReceiptString;
        }

        public void updatePricePerNight()
        {
            if(lstBxHotelLocation.Text == "Miami")//costs for Miami hotel: 250,260,500
            {
                if (lstBxRoomType.Text == "1 King Bed")
                {
                    res.PricePerNight = 250.00;

                }
                else if (lstBxRoomType.Text == "2 Queen Beds")
                {
                    res.PricePerNight = 260.00;
                }
                else if (lstBxRoomType.Text == "1 Bedroom Suite")
                {
                    res.PricePerNight = 500.00;
                }
            }
            else if (lstBxHotelLocation.Text == "Fort Lauderdale")//costs for Fort Lauderdale hotel: 200,210,450
            {
                if (lstBxRoomType.Text == "1 King Bed")
                {
                    res.PricePerNight = 200.00;

                }
                else if (lstBxRoomType.Text == "2 Queen Beds")
                {
                    res.PricePerNight = 210.00;
                }
                else if (lstBxRoomType.Text == "1 Bedroom Suite")
                {
                    res.PricePerNight = 450.00;
                }
            }
            else if (lstBxHotelLocation.Text == "Orlando")//costs for Orlando hotel 150,160,300
            {
                if (lstBxRoomType.Text == "1 King Bed")
                {
                    res.PricePerNight = 150.00;

                }
                else if (lstBxRoomType.Text == "2 Queen Beds")
                {
                    res.PricePerNight = 160.00;
                }
                else if (lstBxRoomType.Text == "1 Bedroom Suite")
                {
                    res.PricePerNight = 300.00;
                }
            }
        }

       
    }
}
