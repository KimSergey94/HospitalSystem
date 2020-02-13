using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebHospitalSystem.Utils
{
    public class AppointmentModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAppointmentService>().To<AppointmentService>();
        }
    }
}