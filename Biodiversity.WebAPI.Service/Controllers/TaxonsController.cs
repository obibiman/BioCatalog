using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.WebAPI.Service.Models.Taxon;

namespace Biodiversity.WebAPI.Service.Controllers
{
    public class TaxonsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Taxons
        public IEnumerable<TaxonListModel> Get()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Taxon, TaxonListModel>());
            var mapper = config.CreateMapper();

            var authors = _unitOfWork.TaxonRepository.GetAll().AsEnumerable();
            var taxonListModels = mapper.Map<IEnumerable<Taxon>, List<TaxonListModel>>(authors);
            return taxonListModels;
        }

        // GET: api/Taxons/5
        public IHttpActionResult Get(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Taxon, TaxonListModel>());
            var mapper = config.CreateMapper();

            var taxon = _unitOfWork.TaxonRepository.GetById(id);
            var taxonListModel = mapper.Map<Taxon, TaxonListModel>(taxon);
            if (taxonListModel == null)
            {
                return NotFound();
            }
            return Ok(taxonListModel);
        }

        //// GET: api/Taxons/5
        //[HttpGet]
        //public TaxonListModel GetByIdReturnObject(int id)
        //{
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<Taxon, TaxonListModel>());
        //    var mapper = config.CreateMapper();

        //    var taxon = _taxonRepository.GetById(id);
        //    var taxonListModel = mapper.Map<Taxon, TaxonListModel>(taxon);
        //    return taxonListModel;
        //}

        // POST: api/Taxons
        public HttpResponseMessage Post(TaxonListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaxonListModel, Taxon>());
            var mapper = config.CreateMapper();
            var taxon = mapper.Map<TaxonListModel, Taxon>(authorListModel);
            _unitOfWork.TaxonRepository.Add(taxon);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            var uri = Url.Link("DefaultApi", new {id = authorListModel.TaxonId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Taxons/5
        public HttpResponseMessage Put(int id, TaxonListModel authorListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaxonListModel, Taxon>());
            var mapper = config.CreateMapper();
            var taxon = mapper.Map<TaxonListModel, Taxon>(authorListModel);
            taxon.TaxonId = id;
            _unitOfWork.TaxonRepository.Update(taxon);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            var uri = Url.Link("DefaultApi", new {id = authorListModel.TaxonId});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // DELETE: api/Taxons/5
        public HttpResponseMessage Delete(int id)
        {
            var taxon = _unitOfWork.TaxonRepository.GetById(id);
            _unitOfWork.TaxonRepository.Delete(taxon);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}