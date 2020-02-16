using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebHospitalSystem.Models;
using System;

namespace WebHospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        IPatientService patientService;
        IDoctorService doctorService;
        IAppointmentService appointmentService;

        public HomeController(IPatientService _patientService, IDoctorService _doctorService, 
                IAppointmentService _appointmentService)
        {
            patientService = _patientService;
            doctorService = _doctorService;
            appointmentService = _appointmentService;
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult PatientsList() { return View(); }

        [Authorize(Roles = "Doctor")]
        public JsonResult GetPatientsJSON(string sidx, string sord, int page, int rows, string iin, string firstName, string lastName, string patronymic)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var results = patientService.GetPatients().Select(
                a => new
                {
                    a.PatientId,
                    a.FirstName,
                    a.LastName,
                    a.Patronymic,
                    a.IIN,
                    a.PhoneNumber,
                    a.Address
                });

            if (!string.IsNullOrEmpty(iin))
            {
                results = results.Where(p => p.IIN.Contains(iin));
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                results = results.Where(p => p.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                results = results.Where(p => p.LastName.Contains(lastName));
            }
            if (!string.IsNullOrEmpty(patronymic))
            {
                results = results.SelectMany(x => x.Patronymic).Where(p => p.Patronymic.)).Contains(patronymic));
            }

            int totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                results = results.OrderByDescending(s => s.PatientId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                results = results.OrderBy(s => s.PatientId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public string CreatePatient([Bind(Exclude="PatientId")] PatientVM patient)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    patientService.AddPatient(MapToPatientDTO(patient));
                    msg = "Пациент добавлен успешно";
                }
                else
                {
                    msg = "Пациент не был добавлен. Ошибка валидации модели";
                }
            }
            catch (Exception ex)
            {
                msg = "Возникла ошибка: " + ex.Message;
            }
            return msg;
        }
        
        [Authorize(Roles = "Doctor")]
        public string EditPatient(PatientVM patient)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    patientService.EditPatient(MapToPatientDTO(patient));
                    msg = "Запись пациента успешно редактирована";
                }
                else
                {
                    msg = "Запись пациента не была редактирована. Ошибка валидации модели";
                }
            }
            catch(Exception ex)
            {
                msg = "Возникла ошибка: " + ex.Message;
            }
            return msg;
        }
        
        [Authorize(Roles = "Doctor")]
        public string DeletePatient(long id)
        {
            patientService.DeletePatient(id);
            return "Удаление успешно";
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult FindPatientByIIN() 
        {
            Session["searchBy"] = "iin";
            return View("PatientsList"); 
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult FindPatientByFirstName()
        {
            Session["searchBy"] = "firstName";
            return View("PatientsList");
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult FindPatientByLastName()
        {
            Session["searchBy"] = "lastName";
            return View("PatientsList");
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult FindPatientByPatronymic()
        {
            Session["searchBy"] = "patronymic";
            return View("PatientsList");
        }

        private PatientDTO MapToPatientDTO(PatientVM patient)
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

        private List<AppointmentVM> GetAppointments()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentVM>()).CreateMapper()
                .Map<IEnumerable<AppointmentDTO>, List<AppointmentVM>>(appointmentService.GetAppointments());
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

        [Authorize(Roles= "Doctor")]
        public ActionResult ListDoctors() { return View(GetDoctors()); }

        public ActionResult ListAppointments() { return View(GetAppointments()); }


    }
}