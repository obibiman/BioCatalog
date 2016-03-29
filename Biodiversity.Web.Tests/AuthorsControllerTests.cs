using System;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Biodiversity.Web.Tests
{
    [TestClass]
    public class AuthorsControllerTests
    {
        private Mock<IAuthorRepository> _authorRepository;

        public void Initialize()
        {
            _authorRepository = new Mock<IAuthorRepository>();
            AuthorsController authorController = new AuthorsController();
        }

        [TestMethod]
        public void Index_Accepts_SearchString_And_Returns_List()
        {
            
        }
    }
}
