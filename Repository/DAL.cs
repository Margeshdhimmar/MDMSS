using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MD.Models;
using MD.Models.New_Employee;
using System.Data;
namespace MD.Repository
{
    public class DAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<EmployeeModel> GetDataList()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("Sp_Select", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable(); 
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);   

            foreach (DataRow dr in dt.Rows)
            {
                
                lst.Add(new EmployeeModel
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Email = Convert.ToString(dr["Email"]),
                    Password = Convert.ToString(dr["Password"]),
                });
            }
            return lst;
        }

        public bool Insert(EmployeeModel Em)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Sp_Insert", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", Em.ID);
            cmd.Parameters.AddWithValue("Email", Em.Email);
            cmd.Parameters.AddWithValue("Password", Em.Password);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}