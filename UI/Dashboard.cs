using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransportManagement.UI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }


        private void buyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Customers_buyers cust = new frm_Customers_buyers();
            cust.Show();
        }

        private void sellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Customers_sellers cust = new frm_Customers_sellers();
            cust.Show();
        }

        private void tripInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Insurance ins = new frm_Insurance();
            ins.Show();
        }

        private void tripExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Trip_Entry entry = new frm_Trip_Entry();
            entry.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Trip_Cost cost = new frm_Trip_Cost();
            cost.Show();
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Billing billing = new frm_Billing();
            billing.Show();
        }
    }
}
