using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportManagement.BLL;
using TransportManagement.DAL;
using TransportManagement.Properties;

namespace TransportManagement.UI
{
    public partial class frm_Billing : Form
    {
        public frm_Billing()
        {
            InitializeComponent();
        }

        BillingBLL c = new BillingBLL();
        BillingDAL dal = new BillingDAL();

        private void frm_Billing_Load(object sender, EventArgs e)
        {
            DataTable dtb = dal.SelectFromBuyers();
            dgvBuyer.DataSource = dtb;
            DataTable dts = dal.SelectFromSellers();
            dgvSeller.DataSource = dts;
            DataTable dtd = dal.SelectFromTripEntry();
            dgvDetails.DataSource = dtd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.bill_no = Int32.Parse(tbBillNo.Text);
            c.buyer_reg_no = Int32.Parse(tbBregNo.Text);
            c.buyer_name = tbBuyerName.Text;
            c.buyer_contact = tbbuyercontact.Text;
            c.buyer_address = tbbuyeraddress.Text;
            c.seller_reg_no = Int32.Parse(tbSRegNo.Text);
            c.seller_name = tbSellerName.Text;
            c.seller_contact = tbSellerContact.Text;
            c.seller_address = tbSellerAddress.Text;
            c.goods_details = tbGoodsDetails.Text;
            c.weight = Int32.Parse(tbWeight.Text);
            c.cost = Int32.Parse(tbCost.Text);

            bool success = dal.Insert(c);

            if (success == true)
            {
                MessageBox.Show("Data Succesfully Added");
                try
                {
                    Report report = new Report(tbBillNo.Text);
                    report.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed to add new Customer");
            }

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();

            //beforePrint bp = new beforePrint();
            //bp.Show();
        }

        private void dgvBuyer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            tbBregNo.Text = dgvBuyer.Rows[rowIndex].Cells[0].Value.ToString();
            tbBuyerName.Text = dgvBuyer.Rows[rowIndex].Cells[1].Value.ToString();
            tbbuyercontact.Text = dgvBuyer.Rows[rowIndex].Cells[2].Value.ToString();
            tbbuyeraddress.Text = dgvBuyer.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void dgvSeller_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            tbSRegNo.Text = dgvSeller.Rows[rowIndex].Cells[0].Value.ToString();
            tbSellerName.Text = dgvSeller.Rows[rowIndex].Cells[1].Value.ToString();
            tbSellerContact.Text = dgvBuyer.Rows[rowIndex].Cells[2].Value.ToString();
            tbSellerAddress.Text = dgvBuyer.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void dgvDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            tbGoodsDetails.Text = dgvDetails.Rows[rowIndex].Cells[0].Value.ToString();
            tbWeight.Text = dgvDetails.Rows[rowIndex].Cells[1].Value.ToString();
            tbCost.Text = dgvDetails.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Transport Management", new Font("Segoe UI", 25, FontStyle.Bold), Brushes.Black, new Point(245, 35));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------", new Font("Segoe UI", 14, FontStyle.Regular), Brushes.Black, new Point(0, 95));
            e.Graphics.DrawString("Date : ", new Font("Segoe UI", 14, FontStyle.Regular), Brushes.Black, new Point(40, 130));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, new Point(120, 130));
            e.Graphics.DrawString("Buyer Reg. no. : ", new Font("Segoe UI", 14, FontStyle.Regular), Brushes.Black, new Point(40, 250));
            e.Graphics.DrawString("Buyer Name : ", new Font("Segoe UI", 14, FontStyle.Regular), Brushes.Black, new Point(40, 280));
            e.Graphics.DrawString(tbBregNo.Text, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, new Point(185, 250));
            e.Graphics.DrawString(tbBuyerName.Text.ToUpper(), new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, new Point(160, 280));
        }

        private void tbGoodsDetails_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
