using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Biodiversity.Web.Tests
{
    [TestClass]
    public class AuthorsControllerTests
    {
        Mock<IAuthorRepository> _authorRepository ;
        AuthorsController _authorsController ;

        [TestInitialize]
        public void SetUp()
        {
            _authorRepository = new Mock<IAuthorRepository>();
            _authorsController = new AuthorsController(_authorRepository.Object);
        }

        [TestMethod]
        public void When_List_of_Authors_Is_Requested_Returns_List()
        {
            //Arrange
            List<Author> listAuthor = new List<Author>
            {
                new Author
                {
                    AuthorId = 6409,
                    Abbreviation = "G",
                    LastName = "Adams",
                    FirstName = "John",
                    SurName = "Q",
                    Comment = "comment for unit test",
                    ModifiedBy = "Maurice Muoneke",
                    ModifiedDate = null,
                    CreatedDate = DateTime.Parse("09/30/1987"),
                    CreatedBy = "System Admin"
                },
                new Author
                {
                    AuthorId = 233,
                    Abbreviation = "G",
                    LastName = "Adams",
                    FirstName = "John",
                    SurName = "Q",
                    Comment = "comment for unit test",
                    ModifiedBy = "Maurice Muoneke",
                    ModifiedDate = null,
                    CreatedDate = DateTime.Parse("09/30/1987"),
                    CreatedBy = "System Admin"
                },
                new Author
                {
                    AuthorId = 781,
                    Abbreviation = "G",
                    LastName = "Adams",
                    FirstName = "John",
                    SurName = "Q",
                    Comment = "comment for unit test",
                    ModifiedBy = "Maurice Muoneke",
                    ModifiedDate = null,
                    CreatedDate = DateTime.Parse("09/30/1987"),
                    CreatedBy = "System Admin"
                }
            };

            _authorRepository.Setup(y => y.GetAll()).Returns(listAuthor);

            //Act            
            var result = _authorsController.Index(string.Empty, 1);

            //Assert
            _authorRepository.Verify(y => y.GetAll(), Times.Once());
           
        }

        [TestMethod]
        public void Create_Author_Returns_ViewResult()
        {
            //Arrange
            var author = new Author
            {
                AuthorId = 6409,
                Abbreviation = "G",
                LastName = "Adams",
                FirstName = "John",
                SurName = "Q",
                Comment = "comment for unit test",
                ModifiedBy = "Maurice Muoneke",
                ModifiedDate = null,
                CreatedDate = DateTime.Parse("09/30/1987"),
                CreatedBy = "System Admin"
            };

            _authorRepository.Setup(y => y.Add(author));

            //Act            
            var result = _authorsController.Create(author) as RedirectToRouteResult;

            //Assert
            _authorRepository.Verify(y => y.Add(author), Times.Once());
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
