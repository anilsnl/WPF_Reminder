using ADSReminder.DataAccess.Abstraction;
using ADSReminder.DataAccess.Concrete.EF;
using Autofac;

namespace ADSReminder.DataAccess
{
    public class DataAccessIOCModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFGenericRepository>().As<IGenericRepository>().SingleInstance();
            base.Load(builder);
        }
    }
}
