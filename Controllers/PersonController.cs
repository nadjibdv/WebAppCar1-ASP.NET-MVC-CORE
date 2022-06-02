using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCar1.Models;

namespace WebAppCar1.Controllers
{
    public class PersonController : Controller
    {
        public readonly ICarPersonRepository<Person> personDbbb;

        public PersonController(ICarPersonRepository<Person> _personDbb)
        {
            this.personDbbb = _personDbb;
        }

        // GET: PersonController
        public ActionResult Index()
        {

            return View(personDbbb.List());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            var findPerson = personDbbb.Find(id);

            return View(findPerson);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person newPerson)
        {
            try
            {
                
                personDbbb.Add(newPerson);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var findPerson = personDbbb.Find(id);

            return View(findPerson);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person updatePerson)
        {
            try
            {
                personDbbb.Update(id, updatePerson);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var findPerson = personDbbb.Find(id);

            return View(findPerson);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person collection)
        {
            try
            {
                personDbbb.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
