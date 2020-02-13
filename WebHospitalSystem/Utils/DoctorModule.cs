using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebHospitalSystem.Utils
{
    public class DoctorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDoctorService>().To<DoctorService>();
        }
    }
}