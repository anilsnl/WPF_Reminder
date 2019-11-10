using ADSReminder.BUS.Abstraction;
using ADSReminder.BUS.Concrete;
using Autofac;

namespace ADSReminder.BUS
{
    public class BUSIOCModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccess.DataAccessIOCModule());

            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            base.Load(builder);
        }
    }
}
