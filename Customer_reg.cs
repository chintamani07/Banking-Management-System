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
    public partial class Customer_reg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Banking System Project\Banking System Project\Bank_Database.mdf;Integrated Security=True;User Instance=True");

        public Customer_reg()
        {
            InitializeComponent();
            ShowDatagrid();
        }

        private void Coustomer_reg_Load(object sender, EventArgs e)
        {
            ShowDatagrid();
        }
         private void button1_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (radioButton1.Checked)
            {
                gender = "Male";


            }
            if (radioButton2.Checked)
            {
                gender = "Female";


            }
            if (radioButton3.Checked)
            {
                gender = "other";


            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Account No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();

            }

            else
            {
                con.Close();
                con.Open();
                string st = "select * from  Customer where C_Account_No='" + textBox1.Text + "'";
                SqlCommand cmdd = new SqlCommand(st, con);
                SqlDataReader drr = cmdd.ExecuteReader();
                if (drr.HasRows)
                {

                    MessageBox.Show("Customer Already Saved");
                    drr.Close();
                }
                else
                {
                    con.Close();
                    con.Open();

                    string str1 = "insert into Customer(C_Account_No,C_Name,C_Address,C_Mobile_No,Gender,Balance,Date) VALUES (@C_Account_No,@C_Name,@C_Address,@C_Mobile_No,@Gender,@Balance,@Date)";
                    SqlCommand cmd = new SqlCommand(str1, con);
                    cmd.Parameters.AddWithValue("@C_Account_No", textBox1.Text);
                    cmd.Parameters.AddWithValue("@C_Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@C_Address", textBox3.Text);
                    cmd.Parameters.AddWithValue("@C_Mobile_No", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Balance", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);


                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Successfully saved", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            ShowDatagrid();
        }

      
        public void ShowDatagrid()
        {
            con.Close();
            con.Open();
            dataGridView2.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Customer ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Customer where C_Account_No='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted Successfully.");
            con.Close();
            ShowDatagrid();

        }

     
       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            string gender = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (gender.ToLower() == radioButton1.Text.ToLower())
            {
                radioButton1.Checked = true;
            }
            else if (gender.ToLower() == radioButton2.Text.ToLower())
            {
                radioButton2.Checked = true;
            }
            else {
                radioButton3.Checked = true;
            
            }

            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            string gender = "";
            if (radioButton1.Checked)
            {
                gender = "Male";


            }
            if (radioButton2.Checked)
            {
                gender = "Female";


            }
            if (radioButton3.Checked)
            {
                gender = "other";


            }
            string cb = "update Customer set C_Account_No=@C_Account_No,C_Name=@C_Name,C_Address=@C_Address,C_Mobile_No=@C_Mobile_No,Gender=@Gender,Balance=@Balance,Date=@Date where C_Account_No='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(cb, con);
            cmd.Parameters.AddWithValue("@C_Account_No", textBox1.Text);
            cmd.Parameters.AddWithValue("@C_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@C_Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@C_Mobile_No", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Balance", textBox5.Text);
            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowDatagrid();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
        }

       



    }
}
