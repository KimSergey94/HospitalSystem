using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebHospitalSystem.Utils
{
    public class PatientModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPatientService>().To<PatientService>();
        }
    }
}