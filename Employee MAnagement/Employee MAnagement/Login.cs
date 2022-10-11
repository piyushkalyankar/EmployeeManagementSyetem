using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Employee_MAnagement
{
    public partial class Login : Form 
    {
        public string usertype = null;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (maskedTextBox1.Text != "" || maskedTextBox1.Text != " ")
            {
                if (maskedTextBox2.Text != "" || maskedTextBox2.Text != " ")
                {
                    String CS = @"Data Source=JAYESH-PC\WINCCPLUSMIG2014;Initial Catalog=EmployeeDatabase;Integrated Security=True";
                    SqlConnection con = new SqlConnection(CS);

                    SqlCommand cmd = new SqlCommand("select * from Employee where Id = @Id and password = @password and usertype = @user;", con);
                    
                    
                    //select * from Employee where Id like @Id and password like @password;", con);




                    cmd.Parameters.AddWithValue("@Id", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", maskedTextBox2.Text);
                    cmd.Parameters.AddWithValue("@user", comboBox1.SelectedItem);
                    try
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        
                        if (dr.Read())
                        {
                            usertype = dr[11].ToString();
                           ClassLibrary.userid = maskedTextBox1.Text;
                            ClassLibrary.usertype = comboBox1.Text;
                            if (usertype == "User" )
                            {
                               
                                HomePage h = new HomePage();
                                h.Show();
                                this.Hide();
                            }
                            else
                            {
                                EmployeeHome a = new EmployeeHome();
                                this.Hide();
                                a.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("User does Not Exit");
                        }
                        dr.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }



                }
            }
}

                   

        private void button2_Click(object sender, EventArgs e)
        {
            ForgetPass fgpass = new ForgetPass();
            fgpass.Show();
            this.Hide();
        }

                    
         
                   
               
            
         

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            comboBox1.Text = "";
        }

       
    }
}
