using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using WebHospitalSystem.Models;
using WebHospitalSystem.Utils;
using BLL.Util;

namespace WebHospitalSystem.Controllers
{
    public class AppointmentController : Controller
    {
        IPatientService patientService;
        IDoctorService doctorService;
        IAppointmentService appointmentService;
        static AppointmentController()
        {
            FormsAuthentication.SignOut();
        }
        public AppointmentController(IPatientService _patientService, IDoctorService _doctorService,
                IAppointmentService _appointmentService)
        {
            patientService = _patientService;
            doctorService = _doctorService;
            appointmentService = _appointmentService;
        }

        //[Authorize(Roles = "Doctor")]
        public ActionResult ListAppointments() { return View(GetAppointments()); }
        private List<AppointmentVM> GetAppointments()
        {
            List<AppointmentVM> appointments = MapperUtilVM.MapToAppointmentVMList(appointmentService.GetAppointments());
            foreach(AppointmentVM appointment in appointments)
            {
                appointment.DoctorName = appointmentService.GetDoctorName(appointment.DoctorId);
                appointment.PatientName = appointmentService.GetPatientName(appointment.PatientId);
            }
            return appointments;
        }

        [HttpGet]
        public PartialViewResult CreateAppointment()
        {
            List<DoctorVM> doctorVMs = MapperUtilVM.MapToDoctorVMList(doctorService.GetDoctors());
            List<PatientVM> patientVMs = MapperUtilVM.MapToPatientVMList(patientService.GetPatients());
            SelectList doctorNamesList = new SelectList(doctorVMs, "DoctorId", "FullName");
            SelectList patientNamesList = new SelectList(patientVMs, "PatientId", "FullName");
            ViewBag.doctorNamesList = doctorNamesList;
            ViewBag.patientNamesList = patientNamesList;
            return PartialView("_CreateAppointment", new Models.AppointmentVM());
        }
        [HttpPost]
        public JsonResult CreateAppointment(AppointmentVM appointmentVM)
        {
            appointmentService.AddAppointment(MapperUtilVM.MapToAppointmentDTO(appointmentVM));
            return Json(appointmentVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult EditAppointment(long appointmentId)
        {
            List<DoctorVM> doctorVMs = MapperUtilVM.MapToDoctorVMList(doctorService.GetDoctors());
            List<PatientVM> patientVMs = MapperUtilVM.MapToPatientVMList(patientService.GetPatients());
            SelectList doctorNamesList = new SelectList(doctorVMs, "DoctorId", "FullName");
            SelectList patientNamesList = new SelectList(patientVMs, "PatientId", "FullName");
            ViewBag.doctorNamesList = doctorNamesList;
            ViewBag.patientNamesList = patientNamesList;

            AppointmentVM appointment = MapperUtilVM.MapToAppointmentVM(appointmentService.GetAppointment(appointmentId));
            return PartialView("_EditAppointment", appointment);
        }
        [HttpPost]
        public JsonResult EditAppointment(AppointmentVM appointmentVM) // id check
        {
            appointmentService.EditAppointment(MapperUtilVM.MapToAppointmentDTO(appointmentVM));
            return Json(appointmentVM, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            appointmentService.Dispose();
            patientService.Dispose();
            doctorService.Dispose();
            base.Dispose(disposing);
        }
    }
}