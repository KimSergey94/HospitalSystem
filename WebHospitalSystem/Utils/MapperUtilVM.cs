using AutoMapper;
using BLL.DTO;
using System.Collections.Generic;
using WebHospitalSystem.Models;

namespace WebHospitalSystem.Utils
{
    public static class MapperUtilVM
    {
        public static PatientDTO MapToPatientDTO(PatientVM patient)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<PatientVM, PatientDTO>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.IIN, opt => opt.MapFrom(src => src.IIN))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                ).CreateMapper().Map<PatientVM, PatientDTO>(patient);
        }
        public static List<PatientVM> MapToPatientVMList(IEnumerable<PatientDTO> patientDTOs)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, PatientVM>()).CreateMapper()
                .Map<IEnumerable<PatientDTO>, List<PatientVM>>(patientDTOs);
        }

        public static DoctorVM MapToDoctorVM(DoctorDTO doctorDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Speciality))
                ).CreateMapper().Map<DoctorDTO, DoctorVM>(doctorDTO);
        }

        public static UserVM MapToUserVM(UserDTO userDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper()
                    .Map<UserDTO, UserVM>(userDTO);
        }
        public static UserDTO MapToUserDTO(RegisterDoctorVM doctorVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<RegisterDoctorVM, UserDTO>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                ).CreateMapper().Map<RegisterDoctorVM, UserDTO>(doctorVM);
        }
        public static DoctorDTO MapToDoctorDTO(RegisterDoctorVM doctorVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<RegisterDoctorVM, DoctorDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Speciality))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                ).CreateMapper().Map<RegisterDoctorVM, DoctorDTO>(doctorVM);
        }

        public static List<AppointmentVM> MapToAppointmentVMList(IEnumerable<AppointmentDTO> appointmentDTOs)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentVM>()).CreateMapper()
                .Map<IEnumerable<AppointmentDTO>, List<AppointmentVM>>(appointmentDTOs);
        }
        public static List<AppointmentRecordVM> MapToAppointmentRecordVMList(IEnumerable<AppointmentRecordDTO> appointmentRecordDTOs)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecordDTO, AppointmentRecordVM>()).CreateMapper()
                .Map<IEnumerable<AppointmentRecordDTO>, List<AppointmentRecordVM>>(appointmentRecordDTOs);
        }
        
        public static List<DoctorVM> MapToDoctorVMList(IEnumerable<DoctorDTO> doctorDTOs)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()).CreateMapper()
                .Map<IEnumerable<DoctorDTO>, List<DoctorVM>>(doctorDTOs);
        }

        public static AppointmentDTO MapToAppointmentDTO(AppointmentVM appointmentVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentVM, AppointmentDTO>()).CreateMapper()
                .Map<AppointmentVM, AppointmentDTO>(appointmentVM);
        }
        public static AppointmentRecordDTO MapToAppointmentRecordDTO(AppointmentRecordVM appointmentRecordVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecordVM, AppointmentRecordDTO>()).CreateMapper()
                .Map<AppointmentRecordVM, AppointmentRecordDTO>(appointmentRecordVM);
        }
        
        public static AppointmentVM MapToAppointmentVM(AppointmentDTO appointmentDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentVM>()).CreateMapper()
                .Map<AppointmentDTO, AppointmentVM>(appointmentDTO);
        }
        public static AppointmentRecordVM MapToAppointmentRecordVM(AppointmentRecordDTO appointmentRecordDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecordDTO, AppointmentRecordVM>()).CreateMapper()
                .Map<AppointmentRecordDTO, AppointmentRecordVM>(appointmentRecordDTO);
        }



    }
}