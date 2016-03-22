using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class TaxonsController : Controller
    {
        private readonly Biocontext _biocontext = new Biocontext();

        // GET: Taxons
        //public ActionResult Index()
        //{
        //    return View(_biocontext.Taxons.ToList());
        //}


        public ActionResult Index(string searchString)
        {
            var taxonRepository = new TaxonRepository(_biocontext);

            IEnumerable<Taxon> allTaxons;

            if (!string.IsNullOrEmpty(searchString))
            {
                allTaxons = taxonRepository.GetAll().AsEnumerable()
                    .Where(s => s.TaxonName.ToUpper()
                        .StartsWith(searchString.ToUpper()));
            }
            else
            {
                allTaxons = taxonRepository.GetAll().AsEnumerable();
            }

            return View(allTaxons.ToList());
        }
        // GET: Taxons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taxon = _biocontext.Taxons.Find(id);
            if (taxon == null)
            {
                return HttpNotFound();
            }
            return View(taxon);
        }

        // GET: Taxons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taxons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                Include =
                    "TaxonId,TaxonName,TaxonType,Sex,Level,Parent,LevelUp,TypeSpecies,OrigGenus,OrigSpelling,StartAge,EndAge,GeologicAge,RecentGenera,FossilGenera,RecentSpecies,FossilSpecies,Page,Illustration,TaxonComment,Commonname,TypeForGroup,TaxonKey,PhylumKey,OldKey,OldId,LevelUpOld,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
                )] Taxon taxon)
        {
            if (ModelState.IsValid)
            {
                _biocontext.Taxons.Add(taxon);
                _biocontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taxon);
        }

        // GET: Taxons/Edit/5
        public ActionResult Edit(int id)
        {
            TaxonRepository taxonRepository = new TaxonRepository(_biocontext);
            var taxon = taxonRepository.GetById(id);
            if (taxon == null)
            {
                return HttpNotFound();
            }
            return View(taxon);
        }

        [HttpPost]
        public ActionResult Edit(int id, Taxon taxon)
        {
            TaxonRepository taxonRepository = new TaxonRepository(_biocontext);
            if (taxonRepository.GetById(id) == null)
            {
                return HttpNotFound();
            }
         
            if (ModelState.IsValid)
            {
                taxon.ModifiedDate = DateTime.Now;
                taxonRepository.Update(taxon);
                return RedirectToAction("Index");
            }
            return View(taxon);
        }

        // POST: Taxons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(
        //    [Bind(
        //        Include =
        //            "TaxonId,TaxonName,TaxonType,Sex,Level,Parent,LevelUp,TypeSpecies,OrigGenus,OrigSpelling,StartAge,EndAge,GeologicAge,RecentGenera,FossilGenera,RecentSpecies,FossilSpecies,Page,Illustration,TaxonComment,Commonname,TypeForGroup,TaxonKey,PhylumKey,OldKey,OldId,LevelUpOld,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
        //        )] Taxon taxon)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TaxonRepository taxonRepository = new TaxonRepository(_biocontext);
        //        taxon.ModifiedDate = DateTime.Now;
        //        taxonRepository.Update(taxon);
        //        return RedirectToAction("Index");
        //    }
        //    return View(taxon);
        //}

        // GET: Taxons/Delete/5
        public ActionResult Delete(int id)
        {
            var taxonRepository = new TaxonRepository(_biocontext);
            var taxon = taxonRepository.GetById(id);
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
            var taxonRepository = new TaxonRepository(_biocontext);
            var taxon = taxonRepository.GetById(id);
            taxonRepository.Delete(taxon);
            _biocontext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _biocontext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}