using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
