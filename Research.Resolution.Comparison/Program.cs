/* 
 * My Ratings:
 * 1.   *****   Microsoft Service Collection     
 * 2.   *****   Autofac
 * 3.   ***     SimpleInjector
 * 4.   *       Unity
*/


using Microsoft.Extensions.DependencyInjection;
using Research.Resolution.Comparison.Providers;
using Research.Resolution.Services;
using System;

namespace Research.Resolution.Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate the container using these services
            IDependencyInjectionProvider container;
            
            //container = new MicrosoftProvider();       
            //container = new AutofacProvider();         
            //container = new SimpleInjectorProvider();  
            container = new UnityProvider();                     

            // register
            IServiceCollection services = new MyServiceCollection();
            services.AddTransient<IDocumentActorFactory, DocumentActorFactory>();
            services.AddTransient<IDocumentConsumer, MyDocumentConsumer>();

            // add in all our registered services
            container.Populate(services);

            // get an IServiceProvide`r, which can be used to configure a DependencyResolver 
            IServiceProvider provider = container.Build();

            // try some consumption            
            var consumer = provider.GetService<IDocumentConsumer>();

            // write some stuff to the screen
            Console.Write($"The result is {consumer.GimmeTheName()}");

            Console.ReadLine();
        }
    }
}
