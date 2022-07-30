using E_Comm.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Comm.DAL
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }
        private bool CheckCartData(Cart cart)
        {
            return true;
        }

        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@c_id,@userid,@p_Id)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@userid", cart.userid);
                cmd.Parameters.AddWithValue("@p_Id", cart.p_Id);
                cmd.Parameters.AddWithValue("@c_id", cart.c_id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.p_Id,p.p_Name,p.Price, c.c_id,c.userid from Product p " +
                        " inner join Cart c on c.p_Id = p.p_Id " +
                        " where c.userid = @userid";
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
                    p.p_Name = dr["p_Name"].ToString();
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
        public int RemoveFromCart(int id)
        {

            string qry = "delete from Cart where c_id = @c_id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@c_id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        /*public int BuyNow(int id)
        {
            string qry = "select * from Cart "
        }*/

    }
}
    