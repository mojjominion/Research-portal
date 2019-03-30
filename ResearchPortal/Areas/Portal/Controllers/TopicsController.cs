using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterDbStorage.DbRespository;
using MasterDbStorage.MasterDbContext;
using Microsoft.AspNetCore.Mvc;

namespace ResearchPortal.Areas.Portal.Controllers
{
    [Area("Portal")]
    public class TopicsController : Controller
    {
        private readonly MasterDBContext _db;
        private readonly TopicsRepository _topicsRepository;

        public TopicsController(MasterDBContext db)
        {
            this._db = db;
            this._topicsRepository = new TopicsRepository(db);
        }

        public IActionResult Index()
        {
            var topicsList = _topicsRepository.GetAll().ToList();
            return View(topicsList);
        }
    }
}