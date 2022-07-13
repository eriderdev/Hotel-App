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
    public partial class FormNewReservation : Form
    {
        //global res object
        Reservation finalRes = new Reservation();

        public FormNewReservation(Reservation res)
        {
            InitializeComponent();
            finalRes = res; //assign values to the global finalRes so you can use later

            lblHotelLocation.Text = res.HotelLocation;
            lblRoomType.Text = res.RoomType;
            lblArrivalDate.Text = res.ArrivalDate.ToLongDateString();
            lblDepartureDate.Text = res.DepartureDate.ToLongDateString();
            lblBill.Text = "Summary of Charges\n"+res.ReceiptString;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormHotelSelection f2 = new FormHotelSelection();
            this.Hide();
            f2.ShowDialog(); // Shows form hotel selection
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ////////////********insert to customer table***************/////////////
                insertCustomer();
                

                /////////////get customer id///////////////////////
                    int customerid = getCustomerID();
                ///MessageBox.Show(customerid.ToString());


                ////////////********insert to payment table***************/////////////
                insertPayment(customerid);
                

                /////////////get payment id///////////////////////
                int paymentid = getPaymentID();
                ///MessageBox.Show(paymentid.ToString());


                ////////////********insert to reservation table***************/////////////
                insertReservation(customerid,paymentid);
                

                //move to confirmation page
                //pass finalRes to next form
                FormConfirmation f2 = new FormConfirmation(finalRes);
                this.Hide();
                f2.ShowDialog(); // Shows confirmation form
                this.Close();


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkBxFillBilling_CheckedChanged(object sender, EventArgs e)
        {
            txBxBillingFirst.Text = txtBxFirstName.Text;
            txBxBillingLast.Text = txtBxLastName.Text;
            txBxBillingAddress.Text = txtBxAddress.Text;
        }

        //method to get customer id
        private int getCustomerID()
        {
            int customerID=0;
            //this is my connection string
            string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MyConn2.Open();

            //This is my insert query in which i am taking input from the user through windows forms  
            string Query = "Select * from customer where idCustomer=(SELECT max(idCustomer) FROM customer);"; //should select the last record

            //This is command class which will handle the query and connection object.  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
            MyReader2.Read();

            string idcus = MyReader2[0].ToString();
            customerID = int.Parse(idcus);
            MyConn2.Close();

            return customerID;
        }

        //method to get payment id
        private int getPaymentID()
        {
            int ID = 0;
            //this is my connection string
            string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MyConn2.Open();

            //This is my insert query in which i am taking input from the user through windows forms  
            string Query = "Select * from payment where idPayment=(SELECT max(idPayment) FROM payment);"; //should select the last record

            //This is command class which will handle the query and connection object.  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
            MyReader2.Read();

            string id = MyReader2[0].ToString();
            ID = int.Parse(id);
            MyConn2.Close();

            return ID;
        }

        private void insertCustomer()
        {
            //This is my connection string i have assigned the database file address path  
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";

            //insert query for customer info
            string Query2 = "insert into hoteldb.customer(firstname,lastname,address,phoneNumber,email) values('" + txtBxFirstName.Text + "','" + txtBxLastName.Text + "','" + txtBxAddress.Text + "','" + txtBxPhoneNumber.Text + "','" + txtBxEmail.Text + "');";

            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn3 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand3 = new MySqlCommand(Query2, MyConn3);
            MySqlDataReader MyReader3;
            MyConn3.Open();
            MyReader3 = MyCommand3.ExecuteReader();
            MyConn3.Close();
        }

        private void insertPayment(int customerid)
        {

            //This is my connection string i have assigned the database file address path  
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
            
            //insert query for payment
            string Query3 = "insert into hoteldb.payment(creditCardNum,exDate,CVV,billingFirstName,BillingLastName,billingAddress,customer_idCustomer) values('" + txtBxCreditCard.Text + "','" + txBxExDate.Text + "','" + txtBxCVV.Text + "','" + txBxBillingFirst.Text + "','" + txBxBillingLast.Text + "','" + txBxBillingAddress.Text +
                "','" + customerid + "');";

            //////"(Select idCustomer from customer where idCustomer=(SELECT max(idCustomer) FROM customer)"

            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn4 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand4 = new MySqlCommand(Query3, MyConn4);
            MySqlDataReader MyReader4;
            MyConn4.Open();
            MyReader4 = MyCommand4.ExecuteReader();
            MyConn4.Close();
        }

        private void insertReservation(int customerid, int paymentid)
        {
            //This is my connection string i have assigned the database file address path  
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";

            //This is my insert query 
            string Query = "insert into hoteldb.reservationinfo(hotelLocation,roomType,arrivalDate,departureDate,customer_idCustomer,payment_idPayment) values('" + finalRes.HotelLocation + "','" + finalRes.RoomType + "','" + finalRes.ArrivalDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + finalRes.DepartureDate.ToString("yyyy-MM-dd HH:mm:ss")
                + "','" + customerid + "','" + paymentid + "');";

            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            //This is command class which will handle the query and connection object.  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database. 
            MyConn2.Close();
        }
        
    }
}
