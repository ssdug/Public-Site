using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Web.Infrastructure.Windsor.Facilities;

namespace Web.Infrastructure.Windsor.Installers
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<RavenPersistenceFacility>();
        }
    }
}