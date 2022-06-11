using ContactBookTestEdition.Data.Repository;
using ContactBookTestEdition.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookTestEdition.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var people = _repo.GetAllPeople();
            return View(people);
        }

        [HttpGet("display")]
        public IActionResult Display(int id)
        {
            var person = _repo.GetPerson(id);
            return View(person);
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var person = _repo.GetPerson(id);
            return View(person);
        }

        [HttpPost("edit")]
        public IActionResult Edit(Person person)
        {
            _repo.UpdatePerson(person);
            _repo.SavePerson();
            return RedirectToAction("Index");
        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            _repo.DeletePerson(id);
            _repo.SavePerson();
            return RedirectToAction("Index");
        }
    }
}
