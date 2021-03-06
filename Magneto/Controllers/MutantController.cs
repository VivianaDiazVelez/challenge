using Magneto.Data;
using Microsoft.AspNetCore.Mvc;
using DomainLogic;
using Magneto.Models;
using System;


namespace Magneto.Controllers
{
    public class MutantController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly HashData _hashData;


        public MutantController(ApplicationDBContext db)
        {
            _db = db;
            _hashData = new HashData();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowMutant()
        {
            return View();
        }
        public IActionResult ShowHuman()
        {
            return View();
        }
        //POST-Scan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Scan(Mutant mutant)
        {
            string [] dna = mutant.DNA.Split("-");

            var task = Scanner.IsMutant(dna);
            mutant.IsMutant = task.Result;
            mutant.DNAHash=_hashData.CreateHash(mutant.DNA);

            _db.Mutants.Add(mutant);
            _db.SaveChanges();
            if (mutant.IsMutant)
            {
                return RedirectToAction("ShowMutant");
            }
            else
            {
                return RedirectToAction("ShowHuman");
            }
        }
    }

}
