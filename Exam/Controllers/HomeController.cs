using RecyclingApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace RecyclingApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                RecyclableTypes = db.RecyclableTypes.ToList(),
                RecyclableItems = db.RecyclableItems.ToList(),
                NewRecyclableType = new RecyclableType(),
                NewRecyclableItem = new RecyclableItem()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecyclableType(HomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.RecyclableTypes.Add(viewModel.NewRecyclableType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.RecyclableTypes = db.RecyclableTypes.ToList();
            viewModel.RecyclableItems = db.RecyclableItems.ToList();
            return View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecyclableItem(HomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.NewRecyclableItem.ComputedRate = viewModel.NewRecyclableItem.Weight * db.RecyclableTypes.Find(viewModel.NewRecyclableItem.RecyclableTypeId).Rate;
                db.RecyclableItems.Add(viewModel.NewRecyclableItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.RecyclableTypes = db.RecyclableTypes.ToList();
            viewModel.RecyclableItems = db.RecyclableItems.ToList();
            return View("Index", viewModel);
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
