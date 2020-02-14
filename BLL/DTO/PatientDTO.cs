namespace BLL.DTO
{
    public class PatientDTO
    {
        public long PatientId { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string IIN { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
