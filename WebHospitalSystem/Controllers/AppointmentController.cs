using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using WebHospitalSystem.Models;
using WebHospitalSystem.Utils;

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

        [ChildActionOnly]
        public PartialViewResult ListAppointmentRecords() { return PartialView("_ListAppointmentRecords", GetAppointmentRecords()); }
        public PartialViewResult AJAXGetAppointmentRecords(long appointmentId) { 
            return PartialView("_ListAppointmentRecords", MapperUtilVM.MapToAppointmentRecordVMList(appointmentService.GetAppointmentRecordsByAppointment(appointmentId)));
        }
        private List<AppointmentRecordVM> GetAppointmentRecords()
        {
            return MapperUtilVM.MapToAppointmentRecordVMList(appointmentService.GetAppointmentRecords());
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
        public PartialViewResult CreateAppRecord(long appointmentId)
        {
            ViewBag.appointmentID = appointmentId;
            return PartialView("_CreateAppRecord", new Models.AppointmentRecordVM());
        }
        [HttpPost]
        public JsonResult CreateAppRecord(AppointmentRecordVM appointmentRecordVM)
        {
            appointmentService.AddAppointmentRecord(MapperUtilVM.MapToAppointmentRecordDTO(appointmentRecordVM));
            return Json(appointmentRecordVM, JsonRequestBehavior.AllowGet);
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
        public JsonResult EditAppointment(AppointmentVM appointmentVM) 
        {
            appointmentService.EditAppointment(MapperUtilVM.MapToAppointmentDTO(appointmentVM));
            return Json(appointmentVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult EditAppointmentRecord(long appointmentRecordId)
        {
            AppointmentRecordVM appointment = MapperUtilVM.MapToAppointmentRecordVM(appointmentService.GetAppointmentRecord(appointmentRecordId));
            return PartialView("_EditAppointmentRecord", appointment);
        }
        [HttpPost]
        public JsonResult EditAppointmentRecord(AppointmentRecordVM appointmentRecordVM)
        {
            appointmentService.EditAppointmentRecord(MapperUtilVM.MapToAppointmentRecordDTO(appointmentRecordVM));
            return Json(appointmentRecordVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteAppointment(long appointmentId)
        {
            appointmentService.DeleteAppointment(appointmentId);
            return RedirectToAction("ListAppointments", "Appointment");
        }

        [HttpGet]
        public ActionResult DeleteAppointmentRecord(long appointmentRecordId)
        {
            appointmentService.DeleteAppointmentRecord(appointmentRecordId);
            return RedirectToAction("ListAppointments", "Appointment");
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