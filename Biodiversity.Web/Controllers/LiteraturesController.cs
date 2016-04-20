using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Models.Literature;

namespace Biodiversity.Web.Controllers
{
    public class LiteraturesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LiteraturesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string searchString)
        {
            IEnumerable<Literature> allLiteratures;
            List<LiteratureListViewModel> literatureListViewModels;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Literature, LiteratureListViewModel>());
            var mapper = config.CreateMapper();
            if (!string.IsNullOrEmpty(searchString))
            {
                allLiteratures = _unitOfWork.LiteratureRepository.GetAll().AsEnumerable()
                    .Where(s => s.TitleofArticleBooktitle.ToUpper()
                        .StartsWith(searchString.ToUpper()));
                literatureListViewModels =
                    mapper.Map<IEnumerable<Literature>, List<LiteratureListViewModel>>(allLiteratures);
            }
            else
            {
                allLiteratures = _unitOfWork.LiteratureRepository.GetAll().AsEnumerable();
                literatureListViewModels =
                    mapper.Map<IEnumerable<Literature>, List<LiteratureListViewModel>>(allLiteratures);
            }
            return View(literatureListViewModels);
        }


        // GET: Literatures/Details/5
        public ActionResult Details(int id)
        {
            var literature = _unitOfWork.LiteratureRepository.GetById(id);
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
                _unitOfWork.LiteratureRepository.Add(literature);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(literature);
        }


        public PartialViewResult GetAuthorForGivenLiterature(string searchString)
        {
            searchString = "l";
            var authors = _unitOfWork.AuthorRepository.GetAll(y => y.LastName.StartsWith(searchString)).ToList();
            var lst = new List<AuthorPartialViewModel>();
            foreach (var author in authors)
            {
                var apm = new AuthorPartialViewModel
                {
                    AuthorId = author.AuthorId,
                    LastName = author.LastName,
                    FirstName = author.FirstName
                };
                lst.Add(apm);
            }
            return PartialView(lst);
        }

        // GET: Literatures/Edit/5
        public ActionResult Edit(int id)
        {
            var literature = _unitOfWork.LiteratureRepository.GetById(id);
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
            if (_unitOfWork.LiteratureRepository.GetById(id) == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                literature.ModifiedDate = DateTime.Now;
                literature.ModifiedBy = "Admin";
                _unitOfWork.LiteratureRepository.Update(literature);
                _unitOfWork.Complete();
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
            var literature = _unitOfWork.LiteratureRepository.GetById(id);
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
            var literature = _unitOfWork.LiteratureRepository.GetById(id);
            //var taxonLiteratureRepository = new Taxonl
            _unitOfWork.LiteratureRepository.Delete(literature);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}