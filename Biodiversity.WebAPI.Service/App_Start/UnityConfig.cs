using System.Web.Http;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Biodiversity.WebAPI.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<ILiteratureRepository, LiteratureRepository>();
            container.RegisterType<ITaxonRepository, TaxonRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}