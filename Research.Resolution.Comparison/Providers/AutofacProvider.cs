using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Comparison.Providers
{
    // http://docs.autofac.org/en/latest/integration/aspnetcore.html

    class AutofacProvider : IDependencyInjectionProvider
    {
        ContainerBuilder builder = new ContainerBuilder();
        AutofacServiceProvider provider;

        public IServiceProvider Build()
        {
            return provider = new AutofacServiceProvider(builder.Build());
        }
        public void Populate(IServiceCollection services)
        {
            builder.Populate(services);
        }
    }
}
