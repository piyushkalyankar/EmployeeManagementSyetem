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
    public partial class updateRecord : Form
    {
        string value = string.Empty;
        int a;
        public updateRecord()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        //private void BindComboBox_Load(object sender, EventArgs e)
        //{
        //    cn = new SqlConnection(@"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True");
        //    cn.Open();

        //    BindData();
        //}
        public void BindData()
        {
            cmd = new SqlCommand("select Id from Employee", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }  
      


        private void updateRecord_Load(object sender, EventArgs e)
        {
           flowLayoutPanel1.Visible  = false;
           panel1.Visible = false;
           panel2.Visible = false;
           panel3.Visible = false;
           panel4.Visible = false;
           cn = new SqlConnection(@"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True");
           cn.Open();

           BindData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(a==1)
            {
                value = comboBox2.Text;
            }
             if(a==2)
            {
                value = comboBox3.Text;
            }
             if (a == 3)
             {
                 value = dateTimePicker1.Text;
             }
             if (a == 4)
             {
                 value = textBox2.Text;
             }


            String CS = @"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select distinct Id from Employee where Id = @Id;";
            cmd1.Parameters.AddWithValue("@Id", comboBox1.Text);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cmd1.CommandText = @"update Employee set "+comboBox1.SelectedItem+" = @value where Id = @Id1;";
                //cmd1.Parameters.AddWithValue("@col_name", );
                cmd1.Parameters.AddWithValue("@Id1", comboBox1.Text);
                cmd1.Parameters.AddWithValue("@value", value);

                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record updated Succesfully");
            }
            else
            {
                MessageBox.Show("User not exist");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePage HP = new HomePage();
            HP.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox4.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            if (comboBox1.Text == "gender")
            {
                panel2.Visible = true; a = 1;
                //value = comboBox2.Text;
            }
            else
            {
                if (comboBox1.Text == "position")
                {
                    panel3.Visible = true; a = 2;
                   // value = comboBox3.Text;
                }
                else
                {

                    if (comboBox1.Text == "birthdate")
                    {
                        panel4.Visible = true; a = 3;
                      //  value = dateTimePicker1.Text;
                    }
                    else
                    {
                        panel1.Visible = true; a = 4;
                       // value = textBox2.Text;
                    }
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
