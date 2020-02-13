using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospitalSystem.Models;

namespace WebHospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        IPatientService patientService;
        IDoctorService doctorService;
        IAppointmentService appointmentService;

        public HomeController(IPatientService _patientService, IDoctorService _doctorService, IAppointmentService _appointmentService)
        {
            patientService = _patientService;
            doctorService = _doctorService;
            appointmentService = _appointmentService;
        }

        public ActionResult Index()
        {
            IEnumerable<DoctorDTO> doctorDTOs = doctorService.GetDoctors();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()).CreateMapper(); 
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, List<DoctorVM>>(doctorDTOs); 
            return View(doctors);
        }

        public ActionResult ListDoctors()
        {
            IEnumerable<DoctorDTO> doctorDTOs = doctorService.GetDoctors();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorVM>()).CreateMapper();
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, List<DoctorVM>>(doctorDTOs);
            return View(doctors);
        }

        public ActionResult ListPatients()
        {
            IEnumerable<PatientDTO> patientDTOs = patientService.GetPatients();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, PatientVM>()).CreateMapper();
            var patients = mapper.Map<IEnumerable<PatientDTO>, List<PatientVM>>(patientDTOs);
            return View(patients);
        }

        public ActionResult ListAppointments()
        {
            IEnumerable<AppointmentDTO> appointmentDTOs = appointmentService.GetAppointments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentVM>()).CreateMapper();
            var appointments = mapper.Map<IEnumerable<AppointmentDTO>, List<AppointmentVM>>(appointmentDTOs);
            return View(appointments);
        }

        //////////////////////////////////////////


        public ActionResult AddPatient()
        {
            //IEnumerable<AppointmentDTO> orderDtos = orderService.GetOrders();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
            //var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderVM>>(orderDtos);
            //return View(orders);
        }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}