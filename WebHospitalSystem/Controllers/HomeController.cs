using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebHospitalSystem.Models;

namespace WebHospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        IPatientService patientService;
        IDoctorService doctorService;
        IAppointmentService appointmentService;
        IUserService userService;

        public HomeController(IPatientService _patientService, IDoctorService _doctorService, 
                IAppointmentService _appointmentService, IUserService _userService)
        {
            patientService = _patientService;
            doctorService = _doctorService;
            appointmentService = _appointmentService;
            userService = _userService;
        }
        private List<UserVM> GetUsers()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper()
                .Map<IEnumerable<UserDTO>, List<UserVM>>(userService.GetUsers());
        }
        private List<AppointmentVM> GetAppointments()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentVM>()).CreateMapper()
                .Map<IEnumerable<AppointmentDTO>, List<AppointmentVM>>(appointmentService.GetAppointments());
        }
        private List<PatientVM> GetPatients()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, PatientVM>()).CreateMapper()
                .Map<IEnumerable<PatientDTO>, List<PatientVM>>(patientService.GetPatients());
        }
        private List<DoctorVM> GetDoctors()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()).CreateMapper()
                .Map<IEnumerable<DoctorDTO>, List<DoctorVM>>(doctorService.GetDoctors());
        }

        //      CHANGE LATER 
        public ActionResult Index()
        {
            IEnumerable<DoctorDTO> doctorDTOs = doctorService.GetDoctors();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()).CreateMapper(); 
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, List<DoctorVM>>(doctorDTOs); 
            return View(doctors);
        }

        [Authorize(Roles= "Doctor, Patient")]
        public ActionResult ListDoctors() { return View(GetDoctors()); }

        [Authorize(Roles = "Doctor, Patient")]
        public ActionResult ListUsers() { return View(GetUsers()); }

        [Authorize(Roles = "Doctor, Patient")]
        public ActionResult ListPatients() { return View(GetPatients()); }

        [Authorize(Roles = "Doctor, Patient")]
        public ActionResult ListAppointments() { return View(GetAppointments()); }

    }
}