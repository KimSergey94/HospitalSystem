using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : System.IDisposable
    {
        IRepositoryLong<Patient> Patients { get; }
        IRepository<Doctor> Doctors { get; }
        IRepositoryLong<Appointment> Appointments { get; }
        IRepositoryLong<AppointmentRecord> AppointmentRecords { get; }
        IRepositoryLong<User> Users { get; }
        IRepository<Role> Roles { get; }
        void Save();
    }
}
