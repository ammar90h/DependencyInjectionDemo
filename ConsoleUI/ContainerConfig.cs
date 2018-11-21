using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        // Store classes in container
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            //IBusinessLogic return instance of BetterBusinessLogic
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();

            //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            //in DemoLibrary find where the namespace contains word Utilities and get interface equals I+name
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));


            // Build Container
            return builder.Build();

        }
    }
}
