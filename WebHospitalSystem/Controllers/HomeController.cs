using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebHospitalSystem.Models;
using System;
using System.Web.Security;
using WebHospitalSystem.Utils;

namespace WebHospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        IPatientService patientService;
        IDoctorService doctorService;
        static HomeController()
        {
            FormsAuthentication.SignOut();
        }
        public HomeController(IPatientService _patientService, IDoctorService _doctorService)
        {
            patientService = _patientService;
            doctorService = _doctorService;
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
            else if (!string.IsNullOrEmpty(firstName))
            {
                results = results.Where(p => p.FirstName.Contains(firstName));
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                results = results.Where(p => p.LastName.Contains(lastName));
            }
            else if (!string.IsNullOrEmpty(patronymic))
            {
                results = results.Where(notnull => notnull.Patronymic != null);
                results = results.Where(patron => patron.Patronymic.Contains(patronymic));
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
                    patientService.AddPatient(MapperUtil.MapToPatientDTO(patient));
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
                    patientService.EditPatient(MapperUtil.MapToPatientDTO(patient));
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
        
        private List<DoctorVM> GetDoctors()
        {
            return MapperUtil.MapToDoctorVMList(doctorService.GetDoctors());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListDoctors() { return View(GetDoctors()); }

        [Authorize(Roles = "Doctor")]
        public ActionResult EditDoctor(int id)
        {
            return View(MapperUtil.MapToDoctorVM(doctorService.GetDoctors().FirstOrDefault(doctorID => doctorID.DoctorId == id)));
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult EditDoctor(DoctorVM doctorVM)
        {
            var doctor = doctorService.GetDoctors().FirstOrDefault(doctorID => doctorID.DoctorId == doctorVM.DoctorId);
            doctor.FirstName = doctorVM.FirstName;
            doctor.LastName = doctorVM.LastName;
            doctor.Patronymic = doctorVM.Patronymic;
            doctor.PhoneNumber = doctorVM.PhoneNumber;
            doctorService.EditDoctor(doctor);
            return RedirectToAction("ListDoctors", "Home");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteDoctor(int id)
        {
            DoctorDTO doctor = doctorService.GetDoctors().FirstOrDefault(doctorId => doctorId.DoctorId == id);
            if (doctor != null)
            {
                return View(MapperUtil.MapToDoctorVM(doctor));
            }
            else
            {
                ViewBag.Title = "Ошибка удаления врача.";
                ViewBag.Message = "Не удалось найти врача для удаления с идентификационным номером = " + id;
                return View("Error");
            }
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult DeleteDoctor(DoctorVM doctorVM)
        {
            try
            {
                doctorService.DeleteDoctor(doctorVM.DoctorId);
                return RedirectToAction("ListDoctors", "Home");
            }
            catch
            {
                ViewBag.Title = "Ошибка удаления врача.";
                ViewBag.Message = "Не удалось удалить врача с идентификационным номером = " + doctorVM.DoctorId;
                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            patientService.Dispose();
            doctorService.Dispose();
            base.Dispose(disposing);
        }
    }
}