using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;

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

        // GET: Appointment
        public ActionResult Index()
        {
            return View(appointmentService.GetAppointments());
        }

        [HttpGet]
        public PartialViewResult CreateAppointment()
        {
            return PartialView("_CreateAppointment", new Models.AppointmentVM());
        }
        [HttpPost]
        public JsonResult CreateAppointment(AppointmenVM appointmentVM)
        {

            appointmentService.AddAppointment();
        }
        private
    }
}