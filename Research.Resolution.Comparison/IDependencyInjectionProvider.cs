using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Comparison
{
    /// <summary>
    /// Enables regist
    /// </summary>
    interface IDependencyInjectionProvider
    {
        /// <summary>
        /// Registers a bunch of ServiceDescriptors
        /// </summary>
        /// <param name="services"></param>
        void Populate(IServiceCollection services);

        /// <summary>
        /// Prepares provider for resolutions
        /// </summary>
        IServiceProvider Build();
    }
}
