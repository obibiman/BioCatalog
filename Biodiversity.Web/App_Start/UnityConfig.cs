using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace Biodiversity.Web
{
    public class UnityConfig
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // register all your components with the container here  
            //This is the important line to edit  
            // TODO: Register your types here
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<ILiteratureRepository, LiteratureRepository>();
            container.RegisterType<ITaxonRepository, TaxonRepository>();
            container.RegisterType<ITaxonAuthorRepository, TaxonAuthorRepository>();
            container.RegisterType<ILiteratureAuthorRepository, LiteratureAuthorRepository>();
            container.RegisterType<ITaxonLiteratureRepository, TaxonLiteratureRepository>();
        }
    }
}