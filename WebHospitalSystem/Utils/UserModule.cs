using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebHospitalSystem.Utils
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}