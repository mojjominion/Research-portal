using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterDbStorage.DbModels;
using MasterDbStorage.MasterDbContext;
using MasterDbStorage.DbRespository;
using Microsoft.AspNetCore.Authorization;
using ResearchPortal.Areas.Articles.Models;

namespace ResearchPortal.Areas.Articles.Controllers
{
    [Area("Articles")]
    public class ArticlesController : Controller
    {
        private readonly MasterDBContext _context;
        private readonly ArticleRepository _articleRepository;

        public ArticlesController(MasterDBContext context)
        {
            _context = context;
            _articleRepository = new ArticleRepository(context);

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
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Articles/Edit/5
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
                    _context.Update(article);
                    await _context.SaveChangesAsync();
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
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(long id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
