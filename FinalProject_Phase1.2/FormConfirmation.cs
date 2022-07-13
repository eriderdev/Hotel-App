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
    public partial class FormConfirmation : Form
    {
        public FormConfirmation(Reservation res)
        {
            InitializeComponent();
            //this is my connection string
            string connStr = "datasource=localhost;port=3306;username=root;password=root;database=hoteldb";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MyConn2.Open();

            //This is my insert query in which i am taking input from the user through windows forms  
            string Query = "Select * from reservationinfo where idReservationInfo=(SELECT max(idReservationInfo) FROM reservationinfo);"; //should select the last record

            //This is command class which will handle the query and connection object.  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
            MyReader2.Read();
            
                lblConfirmationNum.Text = MyReader2[0].ToString();
                lblRoomType.Text = MyReader2[1].ToString();
                lblHotelLocation.Text = MyReader2[2].ToString();
                lblArrivalDate.Text = MyReader2[3].ToString();
                

                lblDepartureDate.Text = MyReader2[4].ToString();
                //lblHotelLocation.Text = MyReader2[0] + "-" + MyReader2[1] + "-" + MyReader2[2];

            
            lblBill.Text = "Summary of Charges\n" + res.ReceiptString;
            MyConn2.Close();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            FormWelcome f2 = new FormWelcome();
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            this.Close();

            
        }

        
    }
}
