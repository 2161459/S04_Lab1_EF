using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        //private BaseDonnees _baseDonnees { get; set; }*
        private ZombiePartyDbContext _baseDonnees { get; set; }

        //public ZombieTypeController(BaseDonnees baseDonnees)*
        public ZombieTypeController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            //List<ZombieType> zombieTypesList = _baseDonnees.ZombieTypes.ToList();*

            //return View(zombieTypesList);*
            List<ZombieType> zombieTypes = _baseDonnees.ZombieTypes.ToList();

            return View(zombieTypes);
        }

        public IActionResult Details(int id)
        {
            var zombies = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id);

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = new(),
                ZombiesList = zombies.ToList(),
                ZombiesCount = zombies.Count(),
                PointsAverage = zombies.Average(p => p.Point)
            };

            zombieTypeVM.ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);
        }


        //GET CREATE
        public IActionResult Create()
        {
            //return View();
            return View(new ZombieType());
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.ZombieTypes.Add(zombieType); //indique à Entity Framework qu'un nouveau type doit être ajouté.
                _baseDonnees.SaveChanges(); //exécute les modifications dans SQL Server.
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

    }
}
