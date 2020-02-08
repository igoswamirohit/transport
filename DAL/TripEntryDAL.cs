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
    class TripEntryDAL
    {
        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Transport_Details";
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

        public bool Insert(TripEntryBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "insert into Transport_Details(id,driver_id,truck_no,starting_date,starting_place,ending_date,ending_place,goods_details,weight,status,cost) values(@id,@driver_id,@truck_no,@starting_date,@starting_place,@ending_date,@ending_place,@goods_details,@weight,@status,@cost) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@driver_id", c.driver_id);
                cmd.Parameters.AddWithValue("@truck_no", c.truck_no);
                cmd.Parameters.AddWithValue("@starting_date", c.starting_date);
                cmd.Parameters.AddWithValue("@starting_place", c.starting_place);
                cmd.Parameters.AddWithValue("@ending_date", c.ending_date);
                cmd.Parameters.AddWithValue("@ending_place", c.ending_place);
                cmd.Parameters.AddWithValue("@goods_details", c.goods_details);
                cmd.Parameters.AddWithValue("@weight", c.weight);
                cmd.Parameters.AddWithValue("@status", c.status);
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


        public bool Update(TripEntryBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Update Transport_Details set driver_id=@driver_id,truck_no=@truck_no,starting_date=@starting_date,starting_place=@starting_place,ending_date=@ending_date,ending_place=@ending_place,goods_details=@goods_details," +
                    "weight=@weight," +
                    "status=@status, " +
                    "cost=@cost " +
                    "Where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@driver_id", c.driver_id);
                cmd.Parameters.AddWithValue("@truck_no", c.truck_no);
                cmd.Parameters.AddWithValue("@starting_date", c.starting_date);
                cmd.Parameters.AddWithValue("@starting_place", c.starting_place);
                cmd.Parameters.AddWithValue("@ending_date", c.ending_date);
                cmd.Parameters.AddWithValue("@ending_place", c.ending_place);
                cmd.Parameters.AddWithValue("@goods_details", c.goods_details);
                cmd.Parameters.AddWithValue("@weight", c.weight);
                cmd.Parameters.AddWithValue("@status", c.status);
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


        public bool Delete(TripEntryBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Delete from Transport_Details where id=@id";
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
