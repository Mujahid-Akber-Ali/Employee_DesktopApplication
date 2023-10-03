using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Project.Classes
{
    public class Class1 
    {
        public int SerialNumber { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int SearchNumber { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public bool Insert(Class1 c)
        {
            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Employee(Fullname,City,Contactnumber,Adress,Gender) VALUES(@Fullname,@City,@Contactnumber,@Adress,@Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Fullname", c.FullName);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@Contactnumber", c.ContactNo);
                cmd.Parameters.AddWithValue("@Adress", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSucess;
        }


        public bool Update(Class1 c)
        {
            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Employee SET Fullname=@FullName,City=@City,Contactnumber=@Contactnumber,Adress=@Adress,Gender=@Gender WHERE SerialNumber=@SerialNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Fullname", c.FullName);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@Contactnumber", c.ContactNo);
                cmd.Parameters.AddWithValue("@Adress", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@SerialNumber", c.SerialNumber);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSucess;
        }

        public bool Delete(Class1 c)
        {
            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Employee WHERE SerialNumber=@SerialNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SerialNumber", c.SerialNumber);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSucess;

        }
   
    }
}


