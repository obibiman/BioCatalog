using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Models.Taxon;

namespace Biodiversity.Web.Controllers
{
    public class TaxonsController : Controller
    {
        private readonly Biocontext _biocontext = new Biocontext();
        private readonly ITaxonRepository _taxonRepository;

        public TaxonsController()
        {
            _taxonRepository = new TaxonRepository(_biocontext);
        }

        public ActionResult Index(string searchString)
        {
            IEnumerable<Taxon> allTaxons;
            List<TaxonListViewModel> taxonListViewModels;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Taxon, TaxonListViewModel>());
            var mapper = config.CreateMapper();
            if (!string.IsNullOrEmpty(searchString))
            {
                allTaxons = _taxonRepository.GetAll().AsEnumerable()
                    .Where(s => s.TaxonName.ToUpper()
                        .StartsWith(searchString.ToUpper()));
                taxonListViewModels = mapper.Map<IEnumerable<Taxon>, List<TaxonListViewModel>>(allTaxons);
            }
            else
            {
                allTaxons = _taxonRepository.GetAll().AsEnumerable();
                taxonListViewModels = mapper.Map<IEnumerable<Taxon>, List<TaxonListViewModel>>(allTaxons);
            }
            return View(taxonListViewModels);
            //return View(allTaxons.ToList());
        }

        // GET: Taxons/Details/5
        public ActionResult Details(int id)
        {
            var taxon = _taxonRepository.GetById(id);
            if (taxon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(taxon);
        }

        // GET: Taxons/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Taxon taxon)
        {
            if (ModelState.IsValid)
            {
                _taxonRepository.Add(taxon);
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(taxon);
        }

        // GET: Taxons/Edit/5
        public ActionResult Edit(int id)
        {
            var taxon = _taxonRepository.GetById(id);
            if (taxon == null)
            {
                return HttpNotFound();
            }
            return View(taxon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Taxon taxon)
        {
            if (_taxonRepository.GetById(id) == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                taxon.ModifiedDate = DateTime.Now;
                _taxonRepository.Update(taxon);
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(taxon);
        }

        // GET: Taxons/Delete/5
        public ActionResult Delete(int id)
        {
            var taxon = _taxonRepository.GetById(id);
            if (taxon == null)
            {
                return HttpNotFound();
            }
            return View(taxon);
        }

        // POST: Taxons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taxon = _taxonRepository.GetById(id);
            _taxonRepository.Delete(taxon);
            return RedirectToAction("Index");
        }
    }
}