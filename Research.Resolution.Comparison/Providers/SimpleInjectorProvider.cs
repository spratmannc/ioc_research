using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace Research.Resolution.Comparison.Providers
{
    class SimpleInjectorProvider : IDependencyInjectionProvider
    {
        Container container = new Container();

        public IServiceProvider Build()
        {
            return container;
        }

        public void Populate(IServiceCollection services)
        {
            foreach (var descriptor in services)
            {
                if (descriptor.ImplementationFactory != null)
                {
                    container.Register(descriptor.ServiceType, 
                                       () => {
                                                return descriptor.ImplementationFactory(container);
                                             }, 
                                       Convert(descriptor.Lifetime));
                }
                else if (descriptor.ImplementationInstance != null)
                {
                    container.RegisterSingleton(descriptor.ServiceType, descriptor.ImplementationInstance);
                }
                else
                {

                    switch (descriptor.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            container.RegisterSingleton(descriptor.ServiceType, descriptor.ImplementationType);
                            break;

                        default:
                            container.Register(descriptor.ServiceType, descriptor.ImplementationType, Convert(descriptor.Lifetime));
                            break;
                    }

                }

            }
        }
        

        private Lifestyle Convert(ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    return Lifestyle.Singleton;

                case ServiceLifetime.Scoped:
                    return Lifestyle.Scoped;

                case ServiceLifetime.Transient:
                default:
                    return Lifestyle.Singleton;
            }
        }
    }
}
