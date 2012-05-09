using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Raven.Client;

namespace Web.Infrastructure.Windsor.Facilities
{
    public class RavenPersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                            Component.For<IDocumentStore>()
                                     .UsingFactoryMethod(_ => DocumentStoreHolder.DocumentStore),
                            Component.For<IDocumentSession>()
                                     .UsingFactoryMethod(k => k.Resolve<IDocumentStore>().OpenSession())
                                     .LifestylePerWebRequest()
                           );
        }
    }
}