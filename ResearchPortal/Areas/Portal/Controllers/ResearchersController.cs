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
    public class ResearchersController : Controller
    {
        private readonly MasterDBContext _db;
        private readonly UsersRepository _researchersRepository;

        public ResearchersController(MasterDBContext db)
        {
            this._db = db;
            this._researchersRepository = new UsersRepository(db);
        }

        public IActionResult Index()
        {
            return View(_researchersRepository.GetAll().ToList());
        }
    }
}