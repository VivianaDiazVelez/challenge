using Magneto.Data;
using Magneto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Magneto.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StatsController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index(Stats stats)
        {
            var countMutants = _db.Mutants
            .Where(m => m.IsMutant == true)
            .Count();

            var countHumans = _db.Mutants
            .Where(m => m.IsMutant == false)
            .Count();

            stats.TotalMutants = countMutants;
            stats.TotalHumans = countHumans;
            if (countHumans != 0)
            {
                stats.Ratio = countMutants / countHumans;
            };

            return View(stats);
        }
    }
}
