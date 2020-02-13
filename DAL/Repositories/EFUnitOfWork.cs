using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private HospitalSystemContext db;
        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        private AppointmentRepository appointmentRepository;
        private AppointmentRecordRepository appointmentRecordRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new HospitalSystemContext(connectionString);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepositoryLong<Patient> Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }

        public IRepository<Doctor> Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public IRepositoryLong<Appointment> Appointments
        {
            get
            {
                if (appointmentRepository == null)
                    appointmentRepository = new AppointmentRepository(db);
                return appointmentRepository;
            }
        }

        public IRepositoryLong<AppointmentRecord> AppointmentRecords
        {
            get
            {
                if (appointmentRecordRepository == null)
                    appointmentRecordRepository = new AppointmentRecordRepository(db);
                return appointmentRecordRepository;
            }
        }
    }
}