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
    public partial class Deposit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Banking System Project\Banking System Project\Bank_Database.mdf;Integrated Security=True;User Instance=True");

        public Deposit()
        {
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            dataclere();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select C_Name,Balance from Customer where C_Account_No ='" + textBox1.Text + "'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("User Not Found");
                }
                else {
                    textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                con.Close();
                con.Open();
                double old=double.Parse(textBox3.Text);
                 double amt=double.Parse(textBox5.Text);
                 double ans = old + amt;
                SqlCommand cmd = new SqlCommand("update Customer set Balance='" + ans.ToString() + "'  where C_Account_No ='" + textBox1.Text + " ' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Balance Deposit Sucessfully");
                con.Close();
            
            }
            catch { }
            dataclere();

        }

        public void dataclere()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataclere();
        }


    }
}
