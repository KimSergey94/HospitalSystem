using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebHospitalSystem.Models;
using WebHospitalSystem.Utils;

namespace WebHospitalSystem.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        IPatientService patientService;
        IDoctorService doctorService;
        static AccountController()
        {
            FormsAuthentication.SignOut();
        }
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
                try {
                    var userDTO = userService.GetUser(user.Login);
                    user = MapperUtilVM.MapToUserVM(userDTO);

                    if (user != null) {
                        Session["Login"] = user.Login;
                        Session["Id"] = user.UserId;
                        Session["Role"] = userService.GetUserRole(userDTO).Name;
                        if (user.RoleId == 1 && Session["DoctorId"] != null)
                            Session["DoctorId"] = doctorService.GetDoctors().FirstOrDefault(id => id.UserId == user.UserId).DoctorId;
                        FormsAuthentication.SetAuthCookie(user.Login, true);
                        return RedirectToAction("Index", "Home");
                    } else {
                        ModelState.AddModelError("", "Пользователь с таким логином не существует.");
                    }
                } catch (ValidationException ex) {
                    Debug.WriteLine("Возникла ошибка (Пользователь с введенным логином не найден): " + ex.Message);
                }
                return View(user);
            } else {
                ModelState.AddModelError("", "Введенный логин или пароль не верны.");
                return View(user);
            }
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult RegisterDoctor() { return View(); }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterDoctor(RegisterDoctorVM model) {
            if (ModelState.IsValid) {
                UserDTO user = userService.GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if (user == null) {
                    model.RoleId = 1;
                    userService.AddUser(MapperUtilVM.MapToUserDTO(model));

                    // проверяем если пользователь удачно добавлен в бд
                    var newUser = userService.GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    if (newUser != null) {
                        try {
                            model.UserId = newUser.UserId;
                            doctorService.AddDoctor(MapperUtilVM.MapToDoctorDTO(model));
                            Session["Login"] = newUser.Login;
                            Session["Id"] = newUser.UserId;
                            Session["Role"] = "Doctor";
                            Session["DoctorId"] = doctorService.GetDoctors().FirstOrDefault(id => id.UserId == newUser.UserId).DoctorId;
                            FormsAuthentication.SetAuthCookie(model.Login, true);
                            return RedirectToAction("ListDoctors", "Home");
                        } catch (Exception ex) {
                            ModelState.AddModelError("", "Ошибка регистрации врача: " + ex.Message);
                        }
                    }
                } else {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            Session["Login"] = null;
            Session["Id"] = null;
            Session["DoctorId"] = null;
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
    
