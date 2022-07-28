using E_Comm.Models;
using System;
using System.Data.SqlClient;

namespace E_Comm.DAL
{
    public class UsersDAL
    {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            public UsersDAL()
            {
                con = new SqlConnection(Startup.ConnectionStrings);
            }

        public int UsersRegister(Users u)
        {
            string qry = "insert into User_table values(@u_Name,@u_emailid,@u_password,@RoleId)";
            cmd = new SqlCommand(qry, con);

            
            cmd.Parameters.AddWithValue("@u_Name", u.u_Name);
            cmd.Parameters.AddWithValue("@u_emailid", u.u_emailid);
            cmd.Parameters.AddWithValue("@u_password", u.u_Password);
            cmd.Parameters.AddWithValue("@RoleId", u.RoleId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public Users UsersLogin(Users u)
        {
            Users use = new Users();
            string qry = "select * from User_table where u_emailid=@emailid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emailid" , u.u_emailid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    u.userid = Convert.ToInt32(dr["userid"]);
                    u.u_Name = dr["u_Name"].ToString();
                    u.u_emailid = dr["u_emailid"].ToString();
                    u.u_Password = dr["u_Password"].ToString();
                    u.RoleId= Convert.ToInt32(dr["RoleId"]);
                }
            }
            con.Close();
            return u;
        }
    }
}
