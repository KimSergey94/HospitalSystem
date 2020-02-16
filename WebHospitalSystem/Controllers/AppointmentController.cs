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

        [Authorize(Roles = "Doctor")]
        public ActionResult ListAppointments() { return View(GetAppointments()); }
        private List<AppointmentVM> GetAppointments()
        {
            return MapperUtil.MapToAppointmentVMList(appointmentService.GetAppointments());
        }

        [HttpGet]
        public PartialViewResult CreateAppointment()
        {
            return PartialView("_CreateAppointment", new Models.AppointmentVM());
        }
        [HttpPost]
        public JsonResult CreateAppointment(AppointmentVM appointmentVM)
        {

            appointmentService.AddAppointment();
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