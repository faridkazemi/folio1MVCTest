using Autofac;
using Autofac.Integration.WebApi;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Folio1MvcTest.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            RegisterAutoFac(GlobalConfiguration.Configuration);
        }

        public static IContainer Container;
        public static void RegisterAutoFac(HttpConfiguration config)
        {
            // Setup the Container Builder
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            var modelAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Split(',')[0] == "Database");
            builder.RegisterAssemblyTypes(modelAssembly);

            //  Register UnitOfWork
            builder.RegisterAssemblyTypes(modelAssembly)//.AsImplementedInterfaces()
                .As(typeof(IUnitOfWork)).InstancePerRequest();

            //  Register repositories
            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(ICustomerActivityRepository)).InstancePerRequest();

            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(IReportGroupRepository)).InstancePerRequest();

            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(ICustomerReportGroupRepository)).InstancePerRequest();


            ////  Register Mappers
            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(ICustomerActivityHistoryMapper)).InstancePerRequest();

            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(IReportGroupMapper)).InstancePerRequest();

            //builder.RegisterAssemblyTypes(modelAssembly).AsImplementedInterfaces()
            //    .As(typeof(ICustomerReportGroupMapper)).InstancePerRequest();

            // Build the container
            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
        // public static void SetAutofacContainer()
        //{
        //// Setup the Container Builder
        //var builder = new ContainerBuilder();
        //var config = GlobalConfiguration.Configuration;
        //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        //builder.RegisterWebApiFilterProvider(config);

        //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

        //var modelAssembly = AppDomain.CurrentDomain.GetAssemblies();//.FirstOrDefault(a => a.FullName.Split(',')[0] == "Database");
        //builder.RegisterAssemblyTypes(modelAssembly);

        ////  Register UnitOfWork
        //builder.RegisterAssemblyTypes(modelAssembly)//.AsImplementedInterfaces()
        //    .As(typeof(IUnitOfWork)).InstancePerRequest();

        //// Build the container
        //Container = builder.Build();
        //config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);





        //}
    }
}