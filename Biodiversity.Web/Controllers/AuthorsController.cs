using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;
using PagedList;

namespace Biodiversity.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly Biocontext _biocontext = new Biocontext();

        //// GET: Authors
        //public ActionResult Index()
        //{
        //    var authorRepository = new AuthorRepository(_biocontext);
        //    var authors = authorRepository.GetAll(y => y.AuthorId > 2000000).ToList();
        //    var singleAuthor = authorRepository.GetById(2000095);
        //    return View(_biocontext.Authors.ToList());
        //}

        //public JsonResult GetAuthorsByLastName(string term)
        //{
        //    IAuthorRepository authorRepository = new AuthorRepository(_biocontext);
        //    List<String> data = authorRepository.GetAll().Where(y => y.LastName.StartsWith(term)).Select(y => y.LastName).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        // GET: Authors
        public ActionResult Index(string searchString, int? page = 1)
        {
            IAuthorRepository authorRepository = new AuthorRepository(_biocontext);

            IEnumerable<Author> allAuthors;

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(searchString))
            {
                allAuthors = authorRepository.GetAll().AsEnumerable()
                    .Where(s => s.LastName.ToUpper()
                        .StartsWith(searchString.ToUpper()));
            }
            else
            {
                allAuthors = authorRepository.GetAll().AsEnumerable();
            }

            return View(allAuthors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _biocontext.Authors.Find(id);
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
        public ActionResult Create(
            [Bind(
                Include =
                    "AuthorId,Abbreviation,LastName,FirstName,SurName,Comment,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
                )] Author author)
        {
            if (ModelState.IsValid)
            {
                IAuthorRepository authorRepository = new AuthorRepository(_biocontext);
                author.CreatedDate = DateTime.Now;
                authorRepository.Add(author);
                //_biocontext.Authors.Add(author);
                //_biocontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _biocontext.Authors.Find(id);
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
                IAuthorRepository authorRepository = new AuthorRepository(_biocontext);
                author.ModifiedDate = DateTime.Now;
                authorRepository.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            var authorRepository = new AuthorRepository(_biocontext);
            var author = authorRepository.GetById(id);
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
            var authorRepository = new AuthorRepository(_biocontext);
            var author = authorRepository.GetById(id);
            authorRepository.Delete(author);
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