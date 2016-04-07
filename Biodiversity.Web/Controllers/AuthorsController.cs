using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using Biodiversity.Web.Models.Author;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Authors
        public ActionResult Index(string searchString, int? page = 1)
        {
            searchString = HttpUtility.HtmlEncode(searchString);
            IEnumerable<Author> allAuthors;
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(searchString))
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable()
                    .Where(s => s.LastName.ToUpper()
                        .StartsWith(searchString.ToUpper()));
            }
            else
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable();
            }
            return View(allAuthors.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index2(string searchString, int? page = 1)
        {
            searchString = HttpUtility.HtmlEncode(searchString);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorListViewModel>());
            var mapper = config.CreateMapper();
            IEnumerable<Author> allAuthors;
            List<AuthorListViewModel> filteredAuthors;
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(searchString))
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable()
                    .Where(s => s.LastName.ToUpper()
                        .StartsWith(searchString.ToUpper()));

                filteredAuthors = mapper.Map<IEnumerable<Author>, List<AuthorListViewModel>>(allAuthors);
            }
            else
            {
                allAuthors = _unitOfWork.AuthorRepository.GetAll().AsEnumerable();
                filteredAuthors = mapper.Map<IEnumerable<Author>, List<AuthorListViewModel>>(allAuthors);
            }

            return View(filteredAuthors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.CreatedDate = DateTime.Now;
                _unitOfWork.AuthorRepository.Add(author);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "AuthorId,Abbreviation,LastName,FirstName,SurName,Comment,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
                )] Author author)
        {
            if (ModelState.IsValid)
            {
                author.ModifiedDate = DateTime.Now;
                _unitOfWork.AuthorRepository.Update(author);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetById(id);
            _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}