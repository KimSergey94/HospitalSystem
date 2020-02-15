using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System;
using System.Diagnostics;
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
                try {
                    var userDTO = userService.GetUser(user.Login);
                    user = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper()
                    .Map<UserDTO, UserVM>(userDTO);

                    if (user != null) {
                        Session["Login"] = user.Login;
                        Session["Id"] = user.UserId;
                        Session["Role"] = userService.GetUserRole(userDTO);
                        if (user.RoleId == 1 && Session["DoctorId"] != null)
                            Session["DoctorId"] = doctorService.GetDoctors().FirstOrDefault(id => id.UserId == user.UserId).DoctorId;
                        FormsAuthentication.SetAuthCookie(user.Login, true);
                        return RedirectToAction("Index", "Home");
                    } else {
                        ModelState.AddModelError("", "Пользователь с таким логином не существует.");
                    }
                } catch (ValidationException ex) {
                    Debug.WriteLine("Возникло исключение (Пользователь с введенным логином не найден): " + ex.Message);
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
        public ActionResult RegisterDoctor(RegisterDoctorVM model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = userService.GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if (user == null) {
                    model.RoleId = 1;
                    userService.AddUser(MapToUserDTO(model));

                    // проверяем если пользователь удачно добавлен в бд
                    var newUser = userService.GetUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    if (newUser != null) {
                        try
                        {
                            model.UserId = newUser.UserId;
                            doctorService.AddDoctor(MapToDoctorDTO(model));
                            Session["Login"] = newUser.Login;
                            Session["Id"] = newUser.UserId;
                            Session["Role"] = "Doctor";
                            Session["DoctorId"] = doctorService.GetDoctors().FirstOrDefault(id => id.UserId == newUser.UserId).DoctorId;
                            FormsAuthentication.SetAuthCookie(model.Login, true);
                            return RedirectToAction("Index", "Home");
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", "Ошибка регистрации врача");
                        }
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
            Session["DoctorId"] = null;
            Session["PatientId"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private UserDTO MapToUserDTO(RegisterDoctorVM doctorVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<RegisterDoctorVM, UserDTO>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                ).CreateMapper().Map<RegisterDoctorVM, UserDTO>(doctorVM);
        }
      
        private DoctorDTO MapToDoctorDTO(RegisterDoctorVM doctorVM)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<RegisterDoctorVM, DoctorDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                ).CreateMapper().Map<RegisterDoctorVM, DoctorDTO>(doctorVM);
        }

        protected override void Dispose(bool disposing) {
            userService.Dispose();
            patientService.Dispose();
            doctorService.Dispose();
            base.Dispose(disposing);
        }
    }
}
    
