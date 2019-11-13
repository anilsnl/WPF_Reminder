using Autofac;

namespace ADSReminder.UI.Helpers.IOC
{
    public class CenteralIOCModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new BUS.BUSIOCModule());
            base.Load(builder);
        }
    }
}
