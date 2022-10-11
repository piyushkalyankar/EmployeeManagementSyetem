using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employee_MAnagement
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adduser adus = new adduser();
            adus.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateRecord upd = new updateRecord();
            upd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewRecord rec = new ViewRecord();
            rec.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
