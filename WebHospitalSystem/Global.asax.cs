using BLL.Infrastructure;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebHospitalSystem.Utils;

namespace WebHospitalSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelValidatorProviders.Providers.Clear();
            NinjectModule patientModule = new PatientModule();
            NinjectModule doctorModule = new DoctorModule();
            NinjectModule appointmentModule = new AppointmentModule();
            NinjectModule userModule = new UserModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new Ninject.StandardKernel(patientModule, doctorModule, appointmentModule, userModule, serviceModule); 
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
