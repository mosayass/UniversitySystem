using Autofac;
using University.Core.Services;
using University.Data.Repositries;

namespace University.API.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
        }
    }
}
