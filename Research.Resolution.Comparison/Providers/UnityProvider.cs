using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.Unity;

namespace Research.Resolution.Comparison.Providers
{
    class UnityProvider : IDependencyInjectionProvider
    {
        UnityContainer container = new UnityContainer();
        private UnityServiceProvider provider;

        public IServiceProvider Build()
        {
            return provider = new UnityServiceProvider(container);
        }

        public void Populate(IServiceCollection services)
        {
            foreach (var descriptor in services)
            {
                switch (descriptor.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        container.RegisterInstance(descriptor.ServiceType, descriptor.ImplementationInstance);
                        break;

                    case ServiceLifetime.Scoped:
                        // N/A in Console App
                        break;

                    case ServiceLifetime.Transient:
                    default:
                        if (descriptor.ImplementationFactory != null)
                        {
                            AddTransient(descriptor.ServiceType, descriptor.ImplementationFactory);
                        }
                        else
                        {
                            AddTransient(descriptor.ServiceType, descriptor.ImplementationType);
                        }
                        break;
                }
            }
        }

        private void AddTransient(Type serviceType, Type implementationType)
        {
            container.RegisterType(serviceType, implementationType);
        }

        private void AddTransient(Type serviceType, Func<IServiceProvider, object> factory)
        {
            container.RegisterType(serviceType, new InjectionFactory((unityContainer) =>
            {
                return factory(new UnityServiceProvider(unityContainer));

            }));
        }
    }

    class UnityServiceProvider : IServiceProvider
    {
        private IUnityContainer container;

        public UnityServiceProvider(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }
    }
}
