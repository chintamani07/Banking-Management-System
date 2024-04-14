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
    public partial class Employee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Banking System Project\Banking System Project\Bank_Database.mdf;Integrated Security=True;User Instance=True");

        public Employee()
        {
            InitializeComponent();
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
            if (txtSalary.Text == "")
            {
                MessageBox.Show("Please enter Basic Salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalary.Focus();

            }
      
            else
            {
                con.Close();
                con.Open();
                string st = "select * from  Employee where Employee_ID='" + txtEmpID.Text + "'";
                SqlCommand cmdd = new SqlCommand(st, con);
                SqlDataReader drr = cmdd.ExecuteReader();
                if (drr.HasRows)
                {

                    MessageBox.Show("Employee Already Saved");
                    drr.Close();
                }
                else
                {
                    con.Close();
                    con.Open();

                    string str1 = "insert into Employee(Employee_id,E_Name,E_Address,E_Mobile_No,Gender,Salary,Date) VALUES (@Employee_ID,@E_Name,@E_Address,@E_Mobile_No,@Gender,@Salary,@Date)";
                    SqlCommand cmd = new SqlCommand(str1, con);
                    cmd.Parameters.AddWithValue("@Employee_ID", txtEmpID.Text);
                    cmd.Parameters.AddWithValue("@E_Name", txtEmpName.Text);
                    cmd.Parameters.AddWithValue("@E_Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@E_Mobile_No", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);

                  
                    cmd.ExecuteNonQuery();
                    con.Close();
          
                    MessageBox.Show("Successfully saved", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
            }
            ShowDatagrid();

        }

   
      
        private void button2_Click(object sender, EventArgs e)
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
            string cb = "update Employee set Employee_ID=@Employee_id,E_Name=@E_Name,E_Address=@E_Address,E_Mobile_No=@E_Mobile_No,Gender=@Gender,Salary=@Salary,Date=@Date where Employee_id='" + txtEmpID.Text + "'";
            SqlCommand cmd = new SqlCommand(cb, con);
            cmd.Parameters.AddWithValue("@Employee_ID", txtEmpID.Text);
            cmd.Parameters.AddWithValue("@E_Name", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@E_Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@E_Mobile_No", txtMobileNo.Text);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
 
            MessageBox.Show("Successfully Updated", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowDatagrid();
        }

        public void ShowDatagrid()
        {
            con.Close();
            con.Open();
            dataGridView2.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employee ", con);
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
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Employee where Employee_id='" + txtEmpID.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted Successfully.");
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtMobileNo.Text = "";
            txtAddress.Text = "";
            radioButton1.Text = "";
            txtSalary.Text = "";
            dateTimePicker1.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtEmpName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMobileNo.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            string gender = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (gender.ToLower() == radioButton1.Text.ToLower())
            {
                radioButton1.Checked = true;
            }
            else if (gender.ToLower() == radioButton2.Text.ToLower())
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;

            }

            txtSalary.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            ShowDatagrid();
        }     
    }
}
