using System.Web;
using System.Web.Http;

namespace Biodiversity.WebAPI.Services
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //UnityConfig.Initialize();
        }
    }
}