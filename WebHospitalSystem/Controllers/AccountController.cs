using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebHospitalSystem.Models;

namespace WebHospitalSystem.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        IPatientService patientService;
        IDoctorService doctorService;
        public AccountController(IUserService uServ, IPatientService pServ, IDoctorService dServ ) { 
            userService = uServ; 
            patientService = pServ; 
            doctorService = dServ;
        }
        public ActionResult Login() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserVM user)
        {
            if (ModelState.IsValid) {
                var userDTO = userService.GetUser(user.Login);
                user = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper()
                    .Map<UserDTO, UserVM>(userDTO);

                if (user != null) {
                    Session["Login"] = user.Login;
                    Session["Id"] = user.UserId;
                    Session["Role"] = userService.GetUserRole(userDTO);
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Home");
                } else {
                    ModelState.AddModelError("", "The user with such login and password does not exist.");
                }
            }
            return View(user);
        }

        private List<UserVM> GetUsers() {
            return new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper()
                .Map<IEnumerable<UserDTO>, List<UserVM>>(userService.GetUsers());
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
        public ActionResult Register() {  return View(); }

        [Authorize(Roles = "Doctor")]
        public ActionResult RegisterPatient() { return View(); }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPatient(RegisterPatientVM model) {
            if (ModelState.IsValid) {
                UserVM user = GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                
                if (user == null) {
                    var userDTO = new UserDTO {
                        Login = model.Login,
                        Password = model.Password,
                        RoleId = 2
                    };
                    userService.AddUser(userDTO);

                    // проверяем если пользователь удачно добавлен в бд
                    var newUser = GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    if (user != null) {
                        if(patientService.isIINAvailable(model.IIN)) {
                            PatientDTO patient = new PatientDTO
                            {
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                IIN = model.IIN,
                                PhoneNumber = model.IIN,
                                Address = model.Address,
                                UserId = newUser.UserId
                            };
                            patientService.AddPatient(patient);
                            Session["Login"] = newUser.Login;
                            Session["Id"] = newUser.UserId;                 
                            Session["Role"] = "Patient";
                            Session["PatientId"] = patientService.GetPatients().FirstOrDefault(id => id.UserId == user.UserId).PatientId;
                            FormsAuthentication.SetAuthCookie(model.Login, true);
                            return RedirectToAction("Index", "Home");
                        }
                    } else {
                        ModelState.AddModelError("", "Пациент с таким ИИН уже существует");
                    }
                } else {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }


        [Authorize(Roles = "Doctor")]
        public ActionResult RegisterDoctor() { return View(); }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterDoctor(RegisterDoctorVM model)
        {
            if (ModelState.IsValid)
            {
                UserVM user = GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if (user == null) {
                    var userDTO = new UserDTO {
                        Login = model.Login,
                        Password = model.Password,
                        RoleId = 1
                    };
                    userService.AddUser(userDTO);

                    // проверяем если пользователь удачно добавлен в бд
                    var newUser = GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    if (user != null) {
                        DoctorDTO doctorDTO = new DoctorDTO {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            UserId = newUser.UserId
                        };
                        doctorService.AddDoctor(doctorDTO);
                        Session["Login"] = user.Login;
                        Session["Id"] = user.UserId;
                        Session["Role"] = "Doctor";
                        Session["DoctorId"] = doctorService.GetDoctors().FirstOrDefault(id => id.UserId == user.UserId).DoctorId;
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        
        public ActionResult Logoff()
        {
            Session["Login"] = null;
            Session["Id"] = null;
            Session["Role"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing) {
            userService.Dispose();
            patientService.Dispose();
            doctorService.Dispose();
            base.Dispose(disposing);
        }
    }
}
    
