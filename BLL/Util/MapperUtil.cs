using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Util
{
    public static class MapperUtil
    {
        public static IEnumerable<AppointmentDTO> MapToAppointmentDTOList(IEnumerable<Appointment> appointments)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Appointment>, List<AppointmentDTO>>(appointments);
        }
        public static IEnumerable<AppointmentRecordDTO> MapToAppointmentRecordDTOList(IEnumerable<AppointmentRecord> appointmentRecords)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecord, AppointmentRecordDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AppointmentRecord>, List<AppointmentRecordDTO>>(appointmentRecords);
        }

        public static IEnumerable<DoctorDTO> MapToDoctorDTOList(IEnumerable<Doctor> doctors)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(doctors);
        }
        public static Doctor MapToDoctor(DoctorDTO doctorDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>()).CreateMapper()
             .Map<DoctorDTO, Doctor>(doctorDTO);
        }
        public static Doctor UpdateDoctorFieldsFromDTO(Doctor doctor, DoctorDTO doctorDTO)
        {
            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Patronymic = doctorDTO.Patronymic;
            doctor.PhoneNumber = doctorDTO.PhoneNumber;
            doctor.Speciality = doctorDTO.Speciality;
            return doctor;
        }

        public static Patient MapToPatient(PatientDTO patientDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>()).CreateMapper()
             .Map<PatientDTO, Patient>(patientDTO);
        }
        public static IEnumerable<PatientDTO> MapToPatientDTOList(IEnumerable<Patient> patients)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(patients);
        }
        public static Patient UpdatePatientFieldsFromDTO(Patient patient, PatientDTO patientDTO)
        {
            patient.FirstName = patientDTO.FirstName;
            patient.LastName = patientDTO.LastName;
            patient.Patronymic = patientDTO.Patronymic;
            patient.IIN = patientDTO.IIN;
            patient.PhoneNumber = patientDTO.PhoneNumber;
            patient.Address = patientDTO.Address;
            return patient;
        }

        public static RoleDTO MapToRoleDTO(Role role)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<Role, RoleDTO>(role);
        }
        public static IEnumerable<UserDTO> MapToUserDTOList(IEnumerable<User> users)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
        }
        public static User MapToUser(UserDTO userDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper()
             .Map<UserDTO, User>(userDTO);
        }
        public static UserDTO MapToUserDTO(User user)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper()
             .Map<User, UserDTO>(user);
        }

        public static Appointment MapToAppointment(AppointmentDTO appointmentDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, Appointment>()).CreateMapper()
                .Map<AppointmentDTO, Appointment>(appointmentDTO);
        }
        public static AppointmentDTO MapToAppointmentDTO(Appointment appointment)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentDTO>()).CreateMapper()
                .Map<Appointment, AppointmentDTO>(appointment);
        }
        public static Appointment UpdateAppointmentFieldsFromDTO(Appointment appointment, AppointmentDTO appointmentDTO)
        {
            appointment.DoctorId = appointmentDTO.DoctorId;
            appointment.PatientId = appointmentDTO.PatientId;
            appointment.Diagnosis = appointmentDTO.Diagnosis;
            return appointment;
        }
        public static AppointmentRecord UpdateAppointmentRecordFieldsFromDTO(AppointmentRecord appointmentRecord, AppointmentRecordDTO appointmentRecordDTO)
        {
            appointmentRecord.Symptom = appointmentRecordDTO.Symptom;
            appointmentRecord.Date = appointmentRecordDTO.Date;
            return appointmentRecord;
        }

        public static AppointmentRecord MapToAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecordDTO, AppointmentRecord>()).CreateMapper()
                .Map<AppointmentRecordDTO, AppointmentRecord>(appointmentRecordDTO);
        }


    }
}
