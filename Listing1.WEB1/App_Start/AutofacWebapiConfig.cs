using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Listing1.DATA.Infrastructure;
using Listing1.DATA.Repositories;
using Listing1.DATA;
using Listing1.SERVICES;
using Listing1.SERVICES.Abstract;
using Autofac.Core;
using Listing1.ENTITIES;
using System.Data.Entity;
using AutoMapper;
using Listing1.SERVICES.Services.Customers;
using Listing1.SERVICES.Abstract.Customer;

namespace Listing1.WEB.App_Start
{
    public class AutofacWebapiConfig
    {


        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF--> DbContext
            builder.RegisterType<CustomerContext>().As<DbContext>().SingleInstance();

            
            //Service AddCustomerService
            builder.RegisterType<CustomerService>()
                   .As<ICustomerService>()
                   .InstancePerRequest();
            

            //UnitOfWork
            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>()
                   .InstancePerRequest();

            //DbFactory
            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();

            //Repository
            builder.RegisterGeneric(typeof(EntityBaseRepository<>))
                   .As(typeof(IEntityBaseRepository<>))
                   .InstancePerRequest();

            //builder.Register(context => context.Resolve<MapperConfiguration>()
            //      .CreateMapper(context.Resolve))
            //      .As<IMapper>()
            //      .InstancePerLifetimeScope();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();


            return Container;
        }


    }
}