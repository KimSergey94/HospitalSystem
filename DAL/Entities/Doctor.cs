using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }


        [DataType("NVARCHAR"), MaxLength(255)]
        public string FirstName { get; set; }

        [DataType("NVARCHAR"), MaxLength(255)]
        public string Speciality{ get; set; }

        [DataType("NVARCHAR"), MaxLength(255)] 
        public string LastName { get; set; }
        
        [DataType("NVARCHAR"), MaxLength(255)]
        public string Patronymic { get; set; }

        [DataType("NVARCHAR"), MaxLength(255)] 
        public string PhoneNumber { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
