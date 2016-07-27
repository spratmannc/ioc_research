using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Comparison.Providers
{
    class MicrosoftProvider : IDependencyInjectionProvider
    {
        private IServiceCollection services;
        private IServiceProvider provider;


        public IServiceProvider Build()
        {
            return provider = services.BuildServiceProvider();
        }

        public void Populate(IServiceCollection services)
        {
            this.services = services;
        }        
    }
}
