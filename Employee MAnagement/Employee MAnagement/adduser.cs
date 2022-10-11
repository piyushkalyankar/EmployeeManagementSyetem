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
    public partial class adduser : Form
    {
        public adduser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = ""; 
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void adduser_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage Homeobj = new HomePage();
            Homeobj.Show();
            this.Hide();
        
           }

        private void btnAddRecord(object sender, EventArgs e)
        {
            String CS = @"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select distinct Id from Employee where Id = @Id;";
            cmd1.Parameters.AddWithValue("@Id", textBox1.Text);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if(dr.Read())
            {
                MessageBox.Show("User already exist , Please select another user id");
                dr.Close();
                con.Close();
            }
            else
            {
                dr.Close();
            //SqlCommand cmd = new SqlCommand("Insert into Employee values (@Id , @name , @address , @gender , @position , @birthdate , @education , @phone , @mail , @salary , @password  , @usertype) ;", con);
                cmd1.CommandText = @"Insert into Employee values (@Id1 , @name , @address , @gender , @position , @birthdate , @education , @phone , @mail , @salary , @password  , @usertype) ;";
                cmd1.Parameters.AddWithValue("@Id1", textBox1.Text);
                cmd1.Parameters.AddWithValue("@name", textBox2.Text);
                cmd1.Parameters.AddWithValue("@address", textBox3.Text);
                cmd1.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd1.Parameters.AddWithValue("@position", comboBox2.Text);
                cmd1.Parameters.AddWithValue("@birthdate", dateTimePicker1.Text.ToString());
                cmd1.Parameters.AddWithValue("@education", textBox7.Text);
                cmd1.Parameters.AddWithValue("@phone", textBox8.Text);
                cmd1.Parameters.AddWithValue("@mail", textBox9.Text);
                cmd1.Parameters.AddWithValue("@salary",  double.Parse(textBox6.Text));
                cmd1.Parameters.AddWithValue("@password", textBox4.Text);
                cmd1.Parameters.AddWithValue("@usertype", comboBox3.Text);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("User added Successfully");
            }

        }
    }
}
