using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class LiteratureAuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LiteratureAuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: LiteratureAuthors
        public ActionResult Index(int? page = 1)
        {
            IEnumerable<LiteratureAuthor> literatureAuthors;
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            literatureAuthors = _unitOfWork.LiteratureAuthorRepository.GetAll().AsEnumerable().OrderBy(y => y.LiteratureAuthorId);

            return View(literatureAuthors.ToPagedList(pageNumber, pageSize));
        }

        // GET: LiteratureAuthors/Details/5
        public ActionResult Details(int id)
        {
            var literatureAuthor = _unitOfWork.LiteratureAuthorRepository.GetById(id);
            if (literatureAuthor == null)
            {
                return HttpNotFound();
            }
            return View(literatureAuthor);
        }

        // GET: LiteratureAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiteratureAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LiteratureAuthor literatureAuthor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LiteratureAuthorRepository.Add(literatureAuthor);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(literatureAuthor);
        }

        // GET: LiteratureAuthors/Edit/5
        public ActionResult Edit(int id)
        {
            var literatureAuthor = _unitOfWork.LiteratureAuthorRepository.GetById(id);
            if (literatureAuthor == null)
            {
                return HttpNotFound();
            }
            return View(literatureAuthor);
        }

        // POST: LiteratureAuthors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            LiteratureAuthor literatureAuthor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LiteratureAuthorRepository.Update(literatureAuthor);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(literatureAuthor);
        }

        // GET: LiteratureAuthors/Delete/5
        public ActionResult Delete(int id)
        {
            var literatureAuthor = _unitOfWork.LiteratureAuthorRepository.GetById(id);
            if (literatureAuthor == null)
            {
                return HttpNotFound();
            }
            return View(literatureAuthor);
        }

        // POST: LiteratureAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var literatureAuthor = _unitOfWork.LiteratureAuthorRepository.GetById(id);
            _unitOfWork.LiteratureAuthorRepository.Delete(literatureAuthor);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}