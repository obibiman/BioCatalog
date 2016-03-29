using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Models.Literature;

namespace Biodiversity.Web.Controllers
{
    public class LiteraturesController : Controller
    {
        private readonly Biocontext _biocontext = new Biocontext();
        private readonly ILiteratureRepository _literatureRepository;

        public LiteraturesController()
        {
            _literatureRepository = new LiteratureRepository(_biocontext);
        }

        //// GET: Literatures
        //public ActionResult Index()
        //{
        //    return View(_literatureRepository.GetAll().ToList());
        //}

        public ActionResult Index(string searchString)
        {
            IEnumerable<Literature> allLiteratures;
            List<LiteratureListViewModel> literatureListViewModels;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Literature, LiteratureListViewModel>());
            var mapper = config.CreateMapper();
            if (!string.IsNullOrEmpty(searchString))
            {
                allLiteratures = _literatureRepository.GetAll().AsEnumerable()
                    .Where(s => s.TitleofArticleBooktitle.ToUpper()
                        .StartsWith(searchString.ToUpper()));
                literatureListViewModels = mapper.Map<IEnumerable<Literature>, List<LiteratureListViewModel>>(allLiteratures);
            }
            else
            {
                allLiteratures = _literatureRepository.GetAll().AsEnumerable();
                literatureListViewModels = mapper.Map<IEnumerable<Literature>, List<LiteratureListViewModel>>(allLiteratures);
            }
            return View(literatureListViewModels);
        }


        // GET: Literatures/Details/5
        public ActionResult Details(int id)
        {
            var literature = _literatureRepository.GetById(id);
            if (literature == null)
            {
                return HttpNotFound();
            }
            return View(literature);
        }

        // GET: Literatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Literatures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Literature literature)
        {
            if (ModelState.IsValid)
            {
                literature.CreatedBy = "Admin";
                literature.CreatedDate = DateTime.Now;
                _literatureRepository.Add(literature);
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(literature);
        }

        // GET: Literatures/Edit/5
        public ActionResult Edit(int id)
        {
            var literature = _literatureRepository.GetById(id);
            if (literature == null)
            {
                return HttpNotFound();
            }
            return View(literature);
        }

        // POST: Literatures/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Literature literature)
        {
            if (_literatureRepository.GetById(id) == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                literature.ModifiedDate = DateTime.Now;
                literature.ModifiedBy = "Admin";
                _literatureRepository.Update(literature);
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(literature);
        }

        // GET: Literatures/Delete/5
        public ActionResult Delete(int id)
        {
            var literature = _literatureRepository.GetById(id);
            if (literature == null)
            {
                return HttpNotFound();
            }
            return View(literature);
        }

        // POST: Literatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var literature = _literatureRepository.GetById(id);
            //var taxonLiteratureRepository = new Taxonl
            _literatureRepository.Delete(literature);
            return RedirectToAction("Index");
        }
    }
}