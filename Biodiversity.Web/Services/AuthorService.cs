using System.Collections.Generic;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;

namespace Biodiversity.Web.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _repository;

        public AuthorService(Biocontext context)
        {
            _repository = new AuthorRepository(context);
        }

        //public IEnumerable<Author> GetAuthors()
        //{
        //    var authors = _repository.GetAll();
        //    return authors;
        //}

        public ICollection<Author> GetAuthors()
        {
            var authors = _repository.GetAll();
            return authors;
        }
    }
}