using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    public class HospitalSystemContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentRecord> AppointmentRecords { get; set; }
        static HospitalSystemContext()
        {
            Database.SetInitializer<HospitalSystemContext>(new HospitalSystemDbInitializer());
        }
        public HospitalSystemContext(string connectionString) : base(connectionString)
        { }
    }

    public class HospitalSystemDbInitializer : DropCreateDatabaseIfModelChanges<HospitalSystemContext>
    {
        protected override void Seed(HospitalSystemContext db)
        {
            db.Patients.Add(new Patient { FirstName = "Евгений", LastName = "Светлаков", IIN = "810708468789", PhoneNumber = "+75813476", Address = "Карла Маркса 36, кв. 9"}); db.Goods.Add(new Good { Name = "iPhone", Company = "Apple", Price = 220000 }); db.Goods.Add(new Good { Name = "LG G", Company = "lG", Price = 100000 }); db.Goods.Add(new Good { Name = "Samsung Galaxy", Company = "Samsung", Price = 80000 });
            db.SaveChanges();
        }
    }
}