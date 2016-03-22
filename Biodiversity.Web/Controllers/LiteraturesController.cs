using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Biodiversity.DataAccess.SqlDataTier;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.Web.Controllers
{
    public class LiteraturesController : Controller
    {
        private readonly Biocontext db = new Biocontext();

        // GET: Literatures
        public ActionResult Index()
        {
            return View(db.Literatures.ToList());
        }

        // GET: Literatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var literature = db.Literatures.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                Include =
                    "LiteratureId,ReferenceYear,ReferenceYearSub,ReferenceDate,TitleofArticleBooktitle,InReferenceNumber,Journal,Volume,Page,Plate,Publisher,City,Comment,PdfId,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
                )] Literature literature)
        {
            if (ModelState.IsValid)
            {
                db.Literatures.Add(literature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(literature);
        }

        // GET: Literatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var literature = db.Literatures.Find(id);
            if (literature == null)
            {
                return HttpNotFound();
            }
            return View(literature);
        }

        // POST: Literatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "LiteratureId,ReferenceYear,ReferenceYearSub,ReferenceDate,TitleofArticleBooktitle,InReferenceNumber,Journal,Volume,Page,Plate,Publisher,City,Comment,PdfId,TimeStamp,ModifiedBy,ModifiedDate,CreatedBy,CreatedDate"
                )] Literature literature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(literature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(literature);
        }

        // GET: Literatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var literature = db.Literatures.Find(id);
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
            var literature = db.Literatures.Find(id);
            db.Literatures.Remove(literature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}