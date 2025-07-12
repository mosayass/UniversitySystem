using Autofac;
using System.Reflection;
using University.Data.Entities;
using University.Data.Repositries;

namespace University.API.Modules
{
    public class RepositoryModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
        }
    }
}
