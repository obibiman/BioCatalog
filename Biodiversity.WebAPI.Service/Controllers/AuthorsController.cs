using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.WebAPI.Service.Models.Author;

namespace Biodiversity.WebAPI.Service.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthorsController()
        {
        }

        // GET: api/Authors
        public IEnumerable<AuthorListModel> Get()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorListModel>());
            var mapper = config.CreateMapper();

            var authors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable();
            var authorListModels = mapper.Map<IEnumerable<Author>, List<AuthorListModel>>(authors);
            return authorListModels;
        }


        // GET: api/Authors/5
        public IHttpActionResult Get(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorListModel>());
            var mapper = config.CreateMapper();

            var author = _unitOfWork.AuthorRepository.GetById(id);
            var transformedAuthor = mapper.Map<Author, AuthorListModel>(author);
            if (transformedAuthor == null)
            {
                return BadRequest("No author found");
            }
            return Ok(transformedAuthor);
        }

        //// GET: api/Authors/5
        //[HttpGet]
        //public AuthorListModel GetByIdReturnObject(int id)
        //{
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorListModel>());
        //    var mapper = config.CreateMapper();

        //    var author = _unitOfWork.AuthorRepository.GetById(id);
        //    var transformedAuthor = mapper.Map<Author, AuthorListModel>(author);
        //    return transformedAuthor;
        //}

        // POST: api/Authors
        public HttpResponseMessage Post(AuthorListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorListModel, Author>());
            var mapper = config.CreateMapper();
            var transformedAuthor = mapper.Map<AuthorListModel, Author>(authorListModel);
            _unitOfWork.AuthorRepository.Add(transformedAuthor);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            var uri = Url.Link("DefaultApi", new {id = authorListModel.AuthorId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Authors/5
        public HttpResponseMessage Put(int id, AuthorListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorListModel, Author>());
            var mapper = config.CreateMapper();
            var transformedAuthor = mapper.Map<AuthorListModel, Author>(authorListModel);
            transformedAuthor.AuthorId = id;
            _unitOfWork.AuthorRepository.Update(transformedAuthor);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            var uri = Url.Link("DefaultApi", new {id = authorListModel.AuthorId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // DELETE: api/Authors/5
        public HttpResponseMessage Delete(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetById(id);
            _unitOfWork.AuthorRepository.Delete(author);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}