using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        public long UserId { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)]
        public string Login { get; set; }
        
        [DataType("NVARCHAR"), MaxLength(255)]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
