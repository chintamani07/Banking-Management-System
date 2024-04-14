using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Banking_System_Project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\users\sofsyst\documents\visual studio 2010\Projects\Banking System Project\Banking System Project\Bank_Database.mdf;Integrated Security=True;User Instance=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill Missing Values");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Login where Username = @Username and Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                con.Close();

                int count = dt.Tables[0].Rows.Count;



                if (count == 1)
                {
                    MessageBox.Show("Login Successfully");
                    // Login();

                    Dashboard d1 = new Dashboard();
                    d1.Show();


                }
                else
                {
                    MessageBox.Show("Username and Password is not Valid");
                }
            }
        }

     }
 }
 

