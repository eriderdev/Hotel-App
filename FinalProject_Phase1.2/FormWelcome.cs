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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();

            /*int num = 2;
                fun1(ref num);
            MessageBox.Show(num.ToString());*/

            /*List<string> items = new List<string>();
            items.Add("Com");
            items.Add("Keyboards");
            items.Add("Mon");*/

            /*foreach (string item in items)
            {
                if (item == "Keyboards")
                {
                    continue;
                }
                MessageBox.Show(item);
            }*/
                    
                    
            
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            FormHotelSelection f2 = new FormHotelSelection();
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            this.Close();

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FormModify f2 = new FormModify(int.Parse(txtBxConfirmation.Text));
            this.Hide();
            f2.ShowDialog(); // Shows new reservation form
            this.Close();
        }

        static void fun1(ref int num)
        {
            num = num * num * num;
        }

       
    }
}
