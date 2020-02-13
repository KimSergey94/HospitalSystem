using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Patient
    {
        public long PatientId { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)]
        public string FirstName { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string LastName { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string IIN { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string PhoneNumber { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string Address { get; set; }
    }
}
