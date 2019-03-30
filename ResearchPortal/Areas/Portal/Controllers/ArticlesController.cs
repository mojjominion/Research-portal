using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterDbStorage.DbModels;
using MasterDbStorage.MasterDbContext;
using MasterDbStorage.DbRespository;
using Microsoft.AspNetCore.Authorization;
using ResearchPortal.Areas.Portal.Models;

namespace ResearchPortal.Areas.Portal.Controllers
{
    [Area("Portal")]
    public class ArticlesController : Controller
    {
        private readonly MasterDBContext _db;
        private readonly ArticleRepository _articleRepository;

        public ArticlesController(MasterDBContext db)
        {
            _db = db;
            _articleRepository = new ArticleRepository(db);

        }

        // GET: Articles/Articles
        public IActionResult Index()
        {
            return View(_articleRepository.GetAll());
        }

        // GET: Articles/Articles/Details/5
        public IActionResult Details(long id)
        {
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                return NotFound();
            }
            var articleViewModel = new ArticleViewModel();
            return View(articleViewModel.FromDbModel(article));
        }

        // GET: Articles/Articles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                _articleRepository.Add(article);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Articles/Edit/5
        [Authorize]
        public IActionResult Edit(long id)
        {
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                return NotFound();
            }
            var articleViewModel = new ArticleViewModel();
            return View(articleViewModel.FromDbModel(article));
        }

        // POST: Articles/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Description,HtmlContent,Id,AuthorId,CreatedAt,LastUpdated,IsDeleted")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(article);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Articles/Delete/5
        [Authorize]
        public IActionResult Delete(long id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var article = _articleRepository.Get(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(long id)
        {
            var article = _articleRepository.Get(id);
            _articleRepository.Remove(article);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(long id)
        {
            return _db.Articles.Any(e => e.Id == id);
        }
    }
}
