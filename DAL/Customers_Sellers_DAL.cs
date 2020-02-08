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
    class Customers_Sellers_DAL
    {

        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Customers_Sellers";
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

        public bool Insert(Customers_Sellers_BLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "insert into Customers_Sellers(seller_reg_no,seller_name,company_name,contact,address,city,state,pincode) values(@seller_reg_no,@seller_name,@company_name,@contact,@address,@city,@state,@pincode) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@seller_reg_no", c.seller_reg_no);
                cmd.Parameters.AddWithValue("@seller_name", c.seller_name);
                cmd.Parameters.AddWithValue("@company_name", c.company_name);
                cmd.Parameters.AddWithValue("@city", c.city);
                cmd.Parameters.AddWithValue("@state", c.state);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@pincode", c.pincode);
                cmd.Parameters.AddWithValue("@address", c.address);

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


        public bool Update(Customers_Sellers_BLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Update Customers_Sellers set seller_name=@seller_name,company_name=@company_name,pincode=@pincode,contact=@contact,address=@address,city=@city, state=@state Where seller_reg_no=@seller_reg_no";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@seller_reg_no", c.seller_reg_no);
                cmd.Parameters.AddWithValue("@seller_name", c.seller_name);
                cmd.Parameters.AddWithValue("@company_name", c.company_name);
                cmd.Parameters.AddWithValue("@city", c.city);
                cmd.Parameters.AddWithValue("@state", c.state);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@pincode", c.pincode);
                cmd.Parameters.AddWithValue("@address", c.address);

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


        public bool Delete(Customers_Sellers_BLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Delete from Customers_Sellers where seller_reg_no=@seller_reg_no";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@seller_reg_no", c.seller_reg_no);
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

        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Customers_Sellers where seller_reg_no LIKE '%"+keywords+"%' OR seller_name LIKE '%"+keywords+"%'";
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
    }
}
