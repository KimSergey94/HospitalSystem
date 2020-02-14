using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Role
    {
        public int RoleId { get; set; }

        [DataType("NVARCHAR"), MaxLength(255)]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
