using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_MAnagement
{
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);

            SqlCommand cmd = new SqlCommand("select * from Employee where Id = @Id and mail = @mail and phone = @phone;", con);


            //select * from Employee where Id like @Id and password like @password;", con);
            
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@mail", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Record does not match");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void ForgetPass_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox4.Text == textBox5.Text)
            {
                String CS = @"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True";
                SqlConnection con = new SqlConnection(CS);

                SqlCommand cmd = new SqlCommand("update Employee set  password = @password  where Id = @Id;", con);
               

                //select * from Employee where Id like @Id and password like @password;", con);

                cmd.Parameters.AddWithValue("@password", textBox4.Text);
               // cmd.Parameters.AddWithValue("@confirmpass", textBox5.Text);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password updated Succesfully");
                con.Close();
            }
            else
            {
                MessageBox.Show("Password and Confirmpassword does not match");
                
            }

        }
    }
}
