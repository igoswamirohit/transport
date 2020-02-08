using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportManagement.BLL;

namespace TransportManagement.DAL
{
    class BillingDAL
    {
        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public DataTable SelectFromBuyers()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select buyer_reg_no,buyer_name,contact,address from Customers_Buyers";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public DataTable SelectFromSellers()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select seller_reg_no, seller_name,contact,address from Customers_Sellers";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public DataTable SelectFromTripEntry()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select goods_details,weight,cost from Transport_Details";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public DataTable Select(BillingBLL c)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Billing_Table where bill_no=@bill_no";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bill_no", c.bill_no);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public bool Insert(BillingBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "insert into Billing_Table(bill_no,buyer_reg_no,buyer_name,buyer_contact,buyer_address,seller_reg_no,seller_name,seller_contact,seller_address,goods_details,weight,cost) values(@bill_no,@buyer_reg_no,@buyer_name,@buyer_contact,@buyer_address,@seller_reg_no,@seller_name,@seller_contact,@seller_address,@goods_details,@weight,@cost) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bill_no", c.bill_no);
                cmd.Parameters.AddWithValue("@buyer_reg_no", c.buyer_reg_no);
                cmd.Parameters.AddWithValue("@buyer_name", c.buyer_name);
                cmd.Parameters.AddWithValue("@buyer_contact", c.buyer_contact);
                cmd.Parameters.AddWithValue("@buyer_address", c.buyer_address);
                cmd.Parameters.AddWithValue("@seller_reg_no", c.seller_reg_no);
                cmd.Parameters.AddWithValue("@seller_name", c.seller_name);
                cmd.Parameters.AddWithValue("@seller_contact", c.seller_contact);
                cmd.Parameters.AddWithValue("@seller_address", c.seller_address);
                cmd.Parameters.AddWithValue("@goods_details", c.goods_details);
                cmd.Parameters.AddWithValue("@weight", c.weight);
                cmd.Parameters.AddWithValue("@cost", c.cost);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
