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
    class LoginDAL
    {
        static String myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public bool loginCheck(LoginBLL l)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);
      

            try
            {
                string sql = "Select * from Login where UserID=@UserID and Password=@Password";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", l.userid);
                cmd.Parameters.AddWithValue("@Password", l.password);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
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
