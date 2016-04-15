using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.WebAPI.Service.Models.Literature;

namespace Biodiversity.WebAPI.Service.Controllers
{
    public class LiteraturesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LiteraturesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult RetrieveAuthors(string searchText = "")
        {
            //var searchString = HttpUtility.HtmlEncode(searchText);
            var searchString = searchText.Trim();
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
                return BadRequest("No Authors found");
            }
            return Ok(allAuthors);
        }

        // GET: api/Literatures
        public IEnumerable<LiteratureListModel> Get()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Literature, LiteratureListModel>());
            var mapper = config.CreateMapper();

            var literatures = _unitOfWork.LiteratureRepository.GetAll().AsEnumerable();
            var literatureListModels = mapper.Map<IEnumerable<Literature>, List<LiteratureListModel>>(literatures);
            return literatureListModels;
        }

        //// GET: api/Literatures/5
        //public IHttpActionResult Get(int id)
        //{
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<Literature, LiteratureListModel>());
        //    var mapper = config.CreateMapper();

        //    var literature = _literatureRepository.GetById(id);
        //    var literatureListModel = mapper.Map<Literature, LiteratureListModel>(literature);
        //    if (literatureListModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(literatureListModel);
        //}

        // GET: api/Literatures/5
        [HttpGet]
        public LiteratureListModel GetByIdReturnObject(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Literature, LiteratureListModel>());
            var mapper = config.CreateMapper();

            var literature = _unitOfWork.LiteratureRepository.GetById(id);
            var literatureListModel = mapper.Map<Literature, LiteratureListModel>(literature);
            return literatureListModel;
        }

        // POST: api/Literatures
        public HttpResponseMessage Post(LiteratureListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LiteratureListModel, Literature>());
            var mapper = config.CreateMapper();
            var literature = mapper.Map<LiteratureListModel, Literature>(authorListModel);
            _unitOfWork.LiteratureRepository.Add(literature);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            var uri = Url.Link("DefaultApi", new {id = authorListModel.LiteratureId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Literatures/5
        public HttpResponseMessage Put(int id, LiteratureListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LiteratureListModel, Literature>());
            var mapper = config.CreateMapper();
            var literature = mapper.Map<LiteratureListModel, Literature>(authorListModel);
            literature.LiteratureId = id;
            _unitOfWork.LiteratureRepository.Update(literature);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            var uri = Url.Link("DefaultApi", new {id = authorListModel.LiteratureId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // DELETE: api/Literatures/5
        public HttpResponseMessage Delete(int id)
        {
            var literature = _unitOfWork.LiteratureRepository.GetById(id);
            _unitOfWork.LiteratureRepository.Delete(literature);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}