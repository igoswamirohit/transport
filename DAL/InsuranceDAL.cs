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
    class InsuranceDAL
    {
        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Insurance";
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

        public bool Insert(InsuranceBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "insert into Insurance(id,truck_model,truck_no,expiry_date,company_name,amount) values(@id,@truck_model,@truck_no,@expiry_date,@company_name,@amount) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@truck_model", c.truck_model);
                cmd.Parameters.AddWithValue("@truck_no", c.truck_no);
                cmd.Parameters.AddWithValue("@expiry_date", c.expiry_date);
                cmd.Parameters.AddWithValue("@amount", c.amount);
                cmd.Parameters.AddWithValue("@company_name", c.company_name);

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


        public bool Update(InsuranceBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Update Insurance set truck_model=@truck_model,truck_no=@truck_no,expiry_date=@expiry_date,company_name=@company_name,amount=@amount Where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@truck_model", c.truck_model);
                cmd.Parameters.AddWithValue("@truck_no", c.truck_no);
                cmd.Parameters.AddWithValue("@expiry_date", c.expiry_date);
                cmd.Parameters.AddWithValue("@amount", c.amount);
                cmd.Parameters.AddWithValue("@company_name", c.company_name);

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


        public bool Delete(InsuranceBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Delete from Insurance where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
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
