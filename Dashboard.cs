using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banking_System_Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

       

        private void newAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee m = new Employee();
            m.Show();
        }

        private void updateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_reg cr = new Customer_reg();
            cr.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit cr1 = new Deposit();
            cr1.Show();
        }

        private void widthdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw cr2 = new Withdraw();
            cr2.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //Form1 cr3 = new Form1();
            //cr3.Show();
        }

        private void fdViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Employee cr3 = new View_Employee();
            cr3.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Customer cr3 = new View_Customer();
            cr3.Show();
        }
    }
}
