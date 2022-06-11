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
            try
            {
                var people = _repo.GetAllPeople();
                return View(people);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet("display")]
        public IActionResult Display(Person per)
        {
            try
            {
                var person = _repo.GetPerson(per.Id);
                return View(person);
            }
            catch (Exception)
            {
                return View("Error");
            }
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
