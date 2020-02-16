using AutoMapper;
using BLL.DTO;
using System.Linq;
using WebHospitalSystem.Models;

namespace WebHospitalSystem.Utils
{
    public static class MapperUtil
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
        public static DoctorVM MapToDoctorVM(DoctorDTO doctorDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                ).CreateMapper().Map<DoctorDTO, DoctorVM>(doctorDTO);
        }

    }
}