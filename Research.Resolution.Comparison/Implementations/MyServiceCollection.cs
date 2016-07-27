using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Comparison
{
    class MyServiceCollection : List<ServiceDescriptor>, IServiceCollection
    {
    }
}
