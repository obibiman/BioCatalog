using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.Web.WebServices.Asmx
{
    /// <summary>
    /// Summary description for Author
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthorService : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<Author> RetrieveAuthors(string searchText = "")
        {
            var searchString = HttpUtility.HtmlEncode(searchText);
            IEnumerable<Author> allAuthors;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable()
                    .Where(s => s.LastName.ToUpper()
                        .StartsWith(searchString.ToUpper()));
            }
            else
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable();
            }
            if (allAuthors == null)
            {
                throw new NotImplementedException();
            }
            return allAuthors;
        }
    }
}
