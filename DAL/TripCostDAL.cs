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
    class TripCostDAL
    {
        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from Trip_Cost";
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

        public bool Insert(TripCostBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "insert into Trip_Cost(trip_id,diesel_cost,toll_cost,other_cost,total_cost) values(@trip_id,@diesel_cost,@toll_cost,@other_cost,@total_cost) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trip_id", c.trip_id);
                cmd.Parameters.AddWithValue("@diesel_cost", c.diesel_cost);
                cmd.Parameters.AddWithValue("@toll_cost", c.toll_cost);
                cmd.Parameters.AddWithValue("@other_cost", c.other_cost);
                cmd.Parameters.AddWithValue("@total_cost", c.total_cost);

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


        public bool Update(TripCostBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Update Trip_Cost set diesel_cost=@diesel_cost,toll_cost=@toll_cost,other_cost=@other_cost Where trip_id=@trip_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trip_id", c.trip_id);
                cmd.Parameters.AddWithValue("@diesel_cost", c.diesel_cost);
                cmd.Parameters.AddWithValue("@toll_cost", c.toll_cost);
                cmd.Parameters.AddWithValue("@other_cost", c.other_cost);

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


        public bool Delete(TripCostBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Delete from Trip_Cost where trip_id=@trip_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trip_id", c.trip_id);
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
