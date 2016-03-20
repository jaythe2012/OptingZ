using OptingZ.Models;
using OptingZ.DAL;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OptingZ
{
    public static class Bootstraper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OptingzDbContext())))
              .As<UserManager<ApplicationUser>>().InstancePerRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

      
    }
}