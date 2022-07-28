using System.ComponentModel.DataAnnotations;

namespace E_Comm.Models
{
    public class Users
    {
        [Key]
        public int userid { get; set; }
        public string u_Name { get; set; }
        public string u_emailid { get; set; }
        public string u_Password { get; set; }
        public int RoleId { get; set; }
    }
}
