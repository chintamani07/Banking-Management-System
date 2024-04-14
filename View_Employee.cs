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
    public partial class View_Employee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Banking System Project\Banking System Project\Bank_Database.mdf;Integrated Security=True;User Instance=True");

        public View_Employee()
        {
            InitializeComponent();
        }

      
       

        private void View_Employee_Load(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6].ToString();

                }
            }
        }
    }
}
