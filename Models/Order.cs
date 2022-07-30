namespace E_Comm.Models
{
    public class Order
    {
        public int o_id { get; set; }
        public int p_Id { get; set; }
        public int userid { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }

    }
}
