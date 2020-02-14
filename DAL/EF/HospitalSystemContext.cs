using DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.EF
{
    public class HospitalSystemContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentRecord> AppointmentRecord { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        static HospitalSystemContext()
        {
            Database.SetInitializer<HospitalSystemContext>(new HospitalSystemDbInitializer());
        }
        public HospitalSystemContext(string connectionString) : base(connectionString)
        { }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            dbModelBuilder.Entity<Patient>().HasIndex(u => u.IIN).IsUnique();

            //dbModelBuilder.Entity<User>().HasRequired(c => c.Patients).WithMany().WillCascadeOnDelete(false);
            //dbModelBuilder.Entity<User>().HasRequired(c => c.Doctors).WithMany().WillCascadeOnDelete(false);
            dbModelBuilder.Entity<Patient>().HasRequired(s => s.User).WithMany().WillCascadeOnDelete(false); 
            dbModelBuilder.Entity<Doctor>().HasRequired(s => s.User).WithMany().WillCascadeOnDelete(false); 
        }
    }

    public class HospitalSystemDbInitializer : DropCreateDatabaseAlways<HospitalSystemContext>
    {
        protected override void Seed(HospitalSystemContext db)
        {
            db.Role.Add(new Role { Name = "Doctor" });
            db.Role.Add(new Role { Name = "Patient" });
            db.User.Add(new User { Login = "yevgSv", Password = "yevgSv", RoleId = 2 });
            db.User.Add(new User { Login = "alexBer", Password = "alexBer", RoleId = 2 });
            db.User.Add(new User { Login = "alexKur", Password = "alexKur", RoleId = 2 });
            db.User.Add(new User { Login = "petrKr", Password = "petrKr", RoleId = 2 });

            db.User.Add(new User { Login = "grigVes", Password = "grigVes", RoleId = 1 });
            db.User.Add(new User { Login = "svetSkor", Password = "svetSkor", RoleId = 1 });
            db.User.Add(new User { Login = "romanLob", Password = "romanLob", RoleId = 1 });
            db.SaveChanges();
            db.Patient.Add(new Patient { UserId = 1, FirstName = "Евгений", LastName = "Светлаков", IIN = "810708468789", PhoneNumber = "+77765813476", Address = "Карла Маркса 36, кв. 9"}); 
            db.Patient.Add(new Patient { UserId = 2, FirstName = "Александр", LastName = "Березовский", IIN = "860504666431", PhoneNumber = "+77777777777", Address = "Проспект Мира 33, кв. 6" }); 
            db.Patient.Add(new Patient { UserId = 3, FirstName = "Алексей", LastName = "Курлов", IIN = "860504666143", PhoneNumber = "+77777777677", Address = "Степной 4, кв. 4" }); 
            db.Patient.Add(new Patient { UserId = 4, FirstName = "Петр", LastName = "Круглый", IIN = "930203431645", PhoneNumber = "+77777777776", Address = "ул. Лободы 30, кв. 76" });
            db.Doctor.Add(new Doctor { UserId = 5, FirstName = "Григорий", LastName = "Веселый", PhoneNumber = "+77074548521" });
            db.Doctor.Add(new Doctor { UserId = 6, FirstName = "Светлана", LastName = "Скороходова", PhoneNumber = "+77765532561" });
            db.Doctor.Add(new Doctor { UserId = 7, FirstName = "Роман", LastName = "Лобаненко", PhoneNumber = "+77771584976" });
            db.SaveChanges();
            db.Appointment.Add(new Appointment { DoctorId = 1, PatientId = 1, Diagnosis = "Шизофрения" });
            db.Appointment.Add(new Appointment { DoctorId = 2, PatientId = 2, Diagnosis = "Простуда" });
            db.Appointment.Add(new Appointment { DoctorId = 3, PatientId = 3, Diagnosis = "Ушиб руки" });
            db.AppointmentRecord.Add(new AppointmentRecord { AppointmentId = 1, Symptom = "Иллюзии, галлюцинации, бред, недостаточность речи и мыслей", Date = new System.DateTime(2018, 06, 18, 10, 34, 09)});
            db.AppointmentRecord.Add(new AppointmentRecord { AppointmentId = 1, Symptom = "Смешанное и неструктурированное мышление, странное поведение, галлюцинации", Date = new System.DateTime(2018, 06, 21, 11, 24, 09)});
            db.AppointmentRecord.Add(new AppointmentRecord { AppointmentId = 2, Symptom = "Кашель, боль в горле, осиплость, насморк, чихание, слабость, температура", Date = new System.DateTime(2018, 09, 18, 15, 33, 32)});
            db.AppointmentRecord.Add(new AppointmentRecord { AppointmentId = 3, Symptom = "Формирование гематомы в районе верхней части предплечья, местное повышение температура и болезненное ощущения при прикосновении. Гиперемия, болезненность при движении ", Date = new System.DateTime(2019, 02, 14, 16, 21, 09)});
            db.SaveChanges();
        }
    }
}