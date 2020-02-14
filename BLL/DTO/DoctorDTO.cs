namespace BLL.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
    }
}
