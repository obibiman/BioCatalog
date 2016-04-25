using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class TaxonLiteraturesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxonLiteraturesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TaxonLiteratures
        public ActionResult Index(int? page = 1)
        {
            IEnumerable<TaxonLiterature> allTaxonLiteratures;
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            allTaxonLiteratures = _unitOfWork.TaxonLiteratureRepository.GetAll().AsEnumerable().OrderBy(y => y.TaxonLiteratureId);
        
            return View(allTaxonLiteratures.ToPagedList(pageNumber, pageSize));
        }

        // GET: TaxonLiteratures/Details/5
        public ActionResult Details(int id)
        {
            var TaxonLiterature = _unitOfWork.TaxonLiteratureRepository.GetById(id);
            if (TaxonLiterature == null)
            {
                return HttpNotFound();
            }
            return View(TaxonLiterature);
        }

        // GET: TaxonLiteratures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxonLiteratures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxonLiterature TaxonLiterature)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TaxonLiteratureRepository.Add(TaxonLiterature);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(TaxonLiterature);
        }

        // GET: TaxonLiteratures/Edit/5
        public ActionResult Edit(int id)
        {
            var TaxonLiterature = _unitOfWork.TaxonLiteratureRepository.GetById(id);
            if (TaxonLiterature == null)
            {
                return HttpNotFound();
            }
            return View(TaxonLiterature);
        }

        // POST: TaxonLiteratures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            TaxonLiterature TaxonLiterature)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TaxonLiteratureRepository.Update(TaxonLiterature);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(TaxonLiterature);
        }

        // GET: TaxonLiteratures/Delete/5
        public ActionResult Delete(int id)
        {
            var TaxonLiterature = _unitOfWork.TaxonLiteratureRepository.GetById(id);
            if (TaxonLiterature == null)
            {
                return HttpNotFound();
            }
            return View(TaxonLiterature);
        }

        // POST: TaxonLiteratures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var TaxonLiterature = _unitOfWork.TaxonLiteratureRepository.GetById(id);
            _unitOfWork.TaxonLiteratureRepository.Delete(TaxonLiterature);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}