using MakRecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakRecipes.Controllers
{
    public class PersonController : Controller
    {
        private Recipes Recipes;
        public PersonController()
        {
            Recipes = new Recipes();
        }
        public ActionResult PersonDetail(int id)
        {
            using (var Recipes = new Recipes())
            {
                var person = Recipes.People.SingleOrDefault(p => p.PersonId == id);
                if (person != null)
                {
                    var personViewModel = new PersonViewModel
                    {
                        PersonId = person.PersonId,
                        LastName = person.LastName,
                        FirstName = person.FirstName
                    };

                    return View(personViewModel);
                }
            }
                return new HttpNotFoundResult();
            }

        public ActionResult PersonAdd()
        {
            var personViewModel = new PersonViewModel();

            return View("AddEditPerson", personViewModel);

        }


        [HttpPost]
        public ActionResult AddPerson(PersonViewModel personViewModel)
        {
            using (var Recipes = new Recipes())
            {
                var nextPersonId = Recipes.People.Max(p => p.PersonId) + 1;

                var person = new Person
                {
                    LastName = personViewModel.LastName,
                    FirstName = personViewModel.FirstName
                };

                Recipes.People.Add(person);
                Recipes.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult PersonEdit(int id)
        {
            using (var Recipes = new Recipes())
            {
                var person = Recipes.People.SingleOrDefault(p => p.PersonId == id);
                if (person != null)
                {
                    var personViewModel = new PersonViewModel
                    {
                        PersonId = person.PersonId,
                        LastName = person.LastName,
                        FirstName = person.FirstName
                    };

                    return View("AddEditPerson", personViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditPerson(PersonViewModel personViewModel)
        {
            using (var Recipes = new Recipes())
            {
                var person = Recipes.People.SingleOrDefault(p => p.PersonId == personViewModel.PersonId);

                if (person != null)
                {
                    person.LastName = personViewModel.LastName;
                    person.FirstName = personViewModel.FirstName;
                    Recipes.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeletePerson(PersonViewModel personViewModel)
        {
            using (var Recipes = new Recipes())
            {
                var person = Recipes.People.SingleOrDefault(p => p.PersonId == personViewModel.PersonId);

                if (person != null)
                {
                    Recipes.People.Remove(person);
                    Recipes.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }


        public ActionResult Index()
        {
            var personList = new PersonListViewModel
            {
                //Convert each Person to a PersonViewModel
                People = Recipes.People.Select(p => new PersonViewModel
                {
                    PersonId = p.PersonId,
                    LastName = p.LastName,
                    FirstName = p.FirstName
                }).ToList()
            };

            personList.TotalPeople = personList.People.Count;

            return View(personList);
        }
    }
}