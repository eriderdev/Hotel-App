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
    public partial class FormChangeConfirmation : Form
    {
        public FormChangeConfirmation()
        {
            InitializeComponent();
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
