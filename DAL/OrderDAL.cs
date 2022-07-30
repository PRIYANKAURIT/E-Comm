using E_Comm.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Comm.DAL
{
    public class OrderDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public OrderDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }

        public int AddOrder(Order order)
        {
            string qry = "insert into Order_table values(@o_id,@p_Id,@userid,@Price,@quantity)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@o_id", order.o_id);
            cmd.Parameters.AddWithValue("@userid", order.userid);
            cmd.Parameters.AddWithValue("@p_Id", order.p_Id);
            cmd.Parameters.AddWithValue("@Price", order.Price);
            cmd.Parameters.AddWithValue("@quantity", order.quantity);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public List<Product> ViewOrder(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.p_Id,p.Price, o.o_id,o.userid from Product p " +
                        " inner join Order o on o.p_Id = p.p_Id " +
                        " where o.userid = @userid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.p_Id = Convert.ToInt32(dr["p_Id"]);
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.c_id = Convert.ToInt32(dr["c_id"]);
                    p.userid = Convert.ToInt32(dr["userid"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }              
        public int DeleteOrder(int id)
            {
                string qry = "delete from Order_table where o_id=@o_id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@o_id",id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }

    }



