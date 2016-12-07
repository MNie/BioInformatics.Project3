using Autofac;
using BioInformatics.Project3.Core.Providers;
using Nancy.Bootstrappers.Autofac;

namespace BioInformatics.Project3.Web
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);
            existingContainer.Update(x =>
            {
                x.RegisterType<SequenceProvider>().As<ISequenceProvider>();
                x.RegisterType<StatisticsProvider>().As<IStatisticsProvider>();
            });
        }

        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
    }
}