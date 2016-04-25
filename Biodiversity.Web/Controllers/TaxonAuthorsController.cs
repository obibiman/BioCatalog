using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class TaxonAuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxonAuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TaxonAuthors
        public ActionResult Index(int? page = 1)
        {
            IEnumerable<TaxonAuthor> taxonAuthors;
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            taxonAuthors = _unitOfWork.TaxonAuthorRepository.GetAll().AsEnumerable().OrderBy(y => y.TaxonAuthorId);

            return View(taxonAuthors.ToPagedList(pageNumber, pageSize));
        }

        // GET: TaxonAuthors/Details/5
        public ActionResult Details(int id)
        {
            var taxonAuthor = _unitOfWork.TaxonAuthorRepository.GetById(id);
            if (taxonAuthor == null)
            {
                return HttpNotFound();
            }
            return View(taxonAuthor);
        }

        // GET: TaxonAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxonAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxonAuthor taxonAuthor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TaxonAuthorRepository.Add(taxonAuthor);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(taxonAuthor);
        }

        // GET: TaxonAuthors/Edit/5
        public ActionResult Edit(int id)
        {
            var taxonAuthor = _unitOfWork.TaxonAuthorRepository.GetById(id);
            if (taxonAuthor == null)
            {
                return HttpNotFound();
            }
            return View(taxonAuthor);
        }

        // POST: TaxonAuthors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            TaxonAuthor taxonAuthor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TaxonAuthorRepository.Update(taxonAuthor);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(taxonAuthor);
        }

        // GET: TaxonAuthors/Delete/5
        public ActionResult Delete(int id)
        {
            var taxonAuthor = _unitOfWork.TaxonAuthorRepository.GetById(id);
            if (taxonAuthor == null)
            {
                return HttpNotFound();
            }
            return View(taxonAuthor);
        }

        // POST: TaxonAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taxonAuthor = _unitOfWork.TaxonAuthorRepository.GetById(id);
            _unitOfWork.TaxonAuthorRepository.Delete(taxonAuthor);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}