using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FinalProject_Phase1
{
    public partial class FormModify : Form
    {
        //global res object
        Reservation res = new Reservation();

        int resID;
        int customerID;
        int paymentID;


        public FormModify(int resNum)
        {
            InitializeComponent();
            resID = resNum;
            try
            {
                //////////////Retrieve from reservation table////////////////////

                /////this is my connection string
                string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(connStr);
                MyConn2.Open();

                string Query = "Select * from reservationinfo where idReservationInfo=" + resID + ";"; //select from reservation table

                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Read();

                ////////////assign values to boxes
                lblConfirmationNum.Text = MyReader2[0].ToString();

                res.HotelLocation = MyReader2[1].ToString();
                lblHotelLocation.Text = res.HotelLocation;

                res.RoomType = MyReader2[2].ToString();
                lblRoomType.Text = res.RoomType;

                lblArrivalDate.Text = MyReader2[3].ToString();
                lblDepartureDate.Text = MyReader2[4].ToString();

                res.PricePerNight = double.Parse(MyReader2[5].ToString());
                lblReceipt.Text = receiptString();

                /////get customerid and paymentid from reservation table
                customerID = int.Parse(MyReader2[6].ToString());
                paymentID = int.Parse(MyReader2[7].ToString());

                lblReceipt.Text = receiptString();

                MyConn2.Close();

                //////////////Retrieve from customer table////////////////////
                retrieveFromCustomer();

                //////////////Retrieve from payment table////////////////////
                retrieveFromPayment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btnBack_Click_1(object sender, EventArgs e)
        {
            FormWelcome f2 = new FormWelcome();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

      

        private void btnModifyReservation_Click(object sender, EventArgs e)
        {
            //make modify button go away and submit button appear
            btnModify.Enabled = false;
            btnModify.Visible = false;
            btnSubmit.Visible = true;
            btnSubmit.Enabled = true;

            ///modify reservation
            modifyReservation();

            ///modify personal
            modifyPersonal();

            ///modify payment
            modifyPayment();


        }

        private void lstBxHotelLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

            //assign to hotelLocation
            res.HotelLocation = lstBxHotelLocation.Text;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();
        }

        private void lstBxRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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




        public void updatePricePerNight()
        {
            if (lstBxHotelLocation.Text == "Miami")//costs for Miami hotel: 250,260,500
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
        }///end of update price method

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
            res.ReceiptString = "\n\nTotal Number of Nights: " + (res.DepartureDate - res.ArrivalDate).Days.ToString() +
                "\nPrice Per Night: $" + res.PricePerNight.ToString("#0.00")
                + "\nSubtotal: $" + calculateSubtotal().ToString("#0.00")
                + "\nTaxes: $" + (calculateSubtotal() * .065).ToString("#0.00")
                + "\nTOTAL: $" + (calculateSubtotal() * 1.065).ToString("#0.00");
            return res.ReceiptString;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from hoteldb.reservationinfo where idReservationInfo=" + resID + ";"; ;
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                //MessageBox.Show("Data Deleted");

                MyConn2.Close();


                //move to delete confirmation page/////////////////
                FormDeleteConfirmation f2 = new FormDeleteConfirmation();
                this.Hide();
                f2.ShowDialog(); // Shows new reservation form
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void retrieveFromCustomer()
        {
            try
            {

                /////this is my connection string
                string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(connStr);
                MyConn2.Open();

                //////////////Retrieve from customer table////////////////////

                string Query = "Select * from customer where idCustomer=" + customerID + ";"; //select from customer table

                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Read();

                /////assign values to boxes
                customerID = int.Parse(MyReader2[0].ToString());
                txtBxFirstName.Text = MyReader2[1].ToString();
                txtBxLastName.Text = MyReader2[2].ToString();
                txtBxAddress.Text = MyReader2[3].ToString();
                txtBxPhoneNumber.Text = MyReader2[4].ToString();
                txtBxEmail.Text = MyReader2[5].ToString();


                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }///end of retrievefromcustomer method


        private void retrieveFromPayment()
        {
            try
            {

                /////this is my connection string
                string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(connStr);
                MyConn2.Open();

                //////////////Retrieve from payment table////////////////////

                string Query = "Select * from payment where idPayment=" + paymentID + ";"; //select from payment table

                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Read();

                /////assign values to boxes
                paymentID = int.Parse(MyReader2[0].ToString());
                txtBxCreditCard.Text = MyReader2[1].ToString();
                txtBxExDate.Text = MyReader2[2].ToString();
                txtBxCVV.Text = MyReader2[3].ToString();
                txtBxBillingFirst.Text = MyReader2[4].ToString();
                txtBxBillingLast.Text = MyReader2[5].ToString();
                txtBxBillingAddress.Text = MyReader2[6].ToString();

                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end of retrievefrompayment method

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //////update customer table
            updateCustomer();

            //////update payment table
            updatePayment();

            //////update reservation table
            updateReservation();

            /////move to confirmation page
            FormChangeConfirmation f2 = new FormChangeConfirmation();
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            this.Close();
        }

        private void updateCustomer()
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "UPDATE hoteldb.customer SET firstname = '" + txtBxFirstName.Text + "' , lastName='" + txtBxLastName.Text +
                    "' , address='" + txtBxAddress.Text + "' , phoneNumber='" + txtBxPhoneNumber.Text + "' , email='" + txtBxEmail.Text + "' WHERE idCustomer =" + customerID;

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();


                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void updatePayment()
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "UPDATE hoteldb.payment SET creditCardNum = '" + txtBxCreditCard.Text + "' , exDate='" + txtBxExDate.Text + "' , CVV='" + txtBxCVV.Text +
                    "' , billingFirstName='" + txtBxBillingFirst.Text + "' , billingLastName='" + txtBxBillingLast.Text + "' , billingAddress='" + txtBxBillingAddress.Text + "' WHERE idPayment =" + paymentID;

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();


                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end of updatepayment method

        private void updateReservation()
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "UPDATE hoteldb.reservationinfo SET roomType = '" + res.RoomType + "' , hotelLocation='" + res.HotelLocation + "' , arrivalDate='" + res.ArrivalDate.ToString("yyyy-MM-dd HH:mm:ss") +
                    "' , departureDate='" + res.DepartureDate.ToString("yyyy-MM-dd HH:mm:ss") + "' , pricePerNight='" + res.PricePerNight + "' WHERE idReservationInfo =" + resID;

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();


                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end of updatereservation method

        private void modifyReservation()
        {
            //make modify button disappear and submit button appear
            btnModify.Visible = false;
            btnModify.Enabled = false;
            btnSubmit.Visible = true;
            btnSubmit.Enabled = true;

            //make list boxes editable and label not visible
            lblHotelLocation.Visible = false;
            lblRoomType.Visible = false;
            lstBxHotelLocation.Visible = true;

            lstBxRoomType.Visible = true;
            lstBxHotelLocation.Enabled = true;

            lstBxRoomType.Enabled = true;
            lstBxRoomType.SelectedItem = res.RoomType;

            //set date time picker to today
            dateTimePickerArrival.Value = res.ArrivalDate;
            dateTimePickerDeparture.Value = res.DepartureDate;
            updatePricePerNight(); //update price per night to reflect selection
            lblReceipt.Text = receiptString();

            //make label not visible and date time picker available
            lblArrivalDate.Visible = false;
            dateTimePickerArrival.Visible = true;
            lblDepartureDate.Visible = false;
            dateTimePickerDeparture.Visible = true;


            dateTimePickerArrival.Enabled = true;
            dateTimePickerDeparture.Enabled = true;

            /*edit on different screen*/
            //set values to res class object to pass to form
            //res.RoomType=txtBxRoomType.Text;
            //res.HotelLocation=txtBxHotelLocation.Text;
            //res.ArrivalDate=txtBxArrivalDate.Text;
            //res.DepartureDate=txtBxDepartureDate.Text;

            /*FormHotelSelection f2 = new FormHotelSelection(res);
            this.Hide();
            f2.ShowDialog();
            this.Close();*/
        }//end of modify reservation


        private void modifyPersonal()
        {
            

            //make text boxes editable
            txtBxFirstName.Enabled = true;
            txtBxLastName.Enabled = true;
            txtBxAddress.Enabled = true;
            txtBxPhoneNumber.Enabled = true;
            txtBxEmail.Enabled = true;
        }

        private void modifyPayment()
        {
            

            //make text boxes editable
            txtBxCreditCard.Enabled = true;
            txtBxExDate.Enabled = true;
            txtBxCVV.Enabled = true;
            txtBxBillingFirst.Enabled = true;
            txtBxBillingLast.Enabled = true;
            txtBxBillingAddress.Enabled = true;
        }
    }
}
