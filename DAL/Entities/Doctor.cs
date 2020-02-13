using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string FirstName { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string LastName { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string PhoneNumber { get; set; }
    }
}
