using E_Comm.Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace E_Comm.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
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
                    p.Company_name= dr["Company_name"].ToString();
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select * from Product where p_Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                     p.p_Id = Convert.ToInt32(dr["p_id"]);
                     p.p_Name = dr["p_Name"].ToString();
                     p.Price = Convert.ToInt32(dr["Price"]);
                     p.Company_name = dr["Company_name"].ToString();
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@name,@price,@Company_name)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", prod.p_Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@Company_name", prod.Company_name);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set p_Name=@name , Price=@price ,Company_name = @Company_name where p_Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.p_Id);
            cmd.Parameters.AddWithValue("@name", prod.p_Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@Company_name", prod.@Company_name);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where p_Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}

