using System.Linq;
using System.Web.Mvc;
using Biodiversity.Web;
using Microsoft.Practices.Unity.Mvc;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof (UnityWebActivator), "Start")]
[assembly: ApplicationShutdownMethod(typeof (UnityWebActivator), "Shutdown")]

namespace Biodiversity.Web
{
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            var container = UnityConfig.BuildUnityContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.BuildUnityContainer();
            container.Dispose();
        }
    }
}