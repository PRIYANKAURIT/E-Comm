namespace E_Comm.Models
{
    public class Product
    {
        public int p_Id { get; set; }
        public string p_Name { get; set; }
        public decimal Price { get; set; }
        public string Company_name { get; set; }
        public int c_id { get; set; }       
        public int userid { get; set; }
        public int o_id { get; set; }

    }
}
