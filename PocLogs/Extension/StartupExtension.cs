
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PocLogs.Handlers;
using PocLogs.Logging;
using PocLogs.Request;
using PocLogs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace PocLogs.Extension
{
    public static class StartupExtension
    {
        #region DependencyInjection


        private static IUnityContainer _container;

        public static HttpConfiguration ConfigureIoc(this HttpConfiguration config)
        {

            var container = Initialize()
                .ResolveSingleton()
                .ResolveWebRequest();

            config.DependencyResolver = new UnityConfig.UnityResolver(container);

            ILog driver = container.Resolve<ILog>();

            ICorrelation correlationDriver = container.Resolve<ICorrelation>();
            IBasicRequestDataProvider basicRequestDriver = container.Resolve<IBasicRequestDataProvider>();

            config.MessageHandlers.Add(new CorrelationHandler(correlationDriver, basicRequestDriver));
            config.MessageHandlers.Add(new CustomLogHandler(driver));

            return config;
        }

        private static IUnityContainer Initialize()
        {
            if (_container == null)
            {
                _container = new Unity.UnityContainer();
            }

            return _container;
        }


        private static IUnityContainer ResolveSingleton(this IUnityContainer container)
        {
            container.RegisterType<ITaskService, TaskService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILog, Log>(new HierarchicalLifetimeManager());
            container.RegisterType<IBasicRequestDataProvider, BasicRequestDataProvider>(new HierarchicalLifetimeManager());

            return container;
        }

        private static IUnityContainer ResolveWebRequest(this IUnityContainer container)
        {
            container.RegisterType<ICorrelation, Correlation>(new ContainerControlledLifetimeManager());
            return container;
        }

        #endregion

        public static void ConfigureJsonSettings(this HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}