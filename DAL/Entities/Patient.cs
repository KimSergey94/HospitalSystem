
namespace DAL.Entities
{
    public class Patient
    {
        public long PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IIN { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
