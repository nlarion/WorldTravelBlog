using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeoplesControllers : Controller
    {
        private TravelBlogDbContext db = new TravelBlogDbContext();
        public IActionResult Index()
        {
            return View(db.Peoples.Include(people => people.PeopleId).ToList());
        }
        public IActionResult Details(int id)
        {
            //ExperienceLocation MyEperienceLocation = new ExperienceLocation
            //{
            //    locationList = db.Locations.ToList(),
            //    experience = db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id)
            //};
            var people = db.Peoples.FirstOrDefault(experiences => experiences.PeopleId == id);
            return View(people);
        }
        public ActionResult Create()
        {
            ViewBag.ExperienceId = new SelectList(db.Locations, "ExperienceId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(People people)
        {
            db.Peoples.Add(people);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var thisExperience = db.Peoples.FirstOrDefault(items => items.PeopleId == id);
            ViewBag.ExperienceId = new SelectList(db.Locations, "ExperienceId", "Name");
            return View(thisExperience);
        }
        [HttpPost]
        public ActionResult Update(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisExperience = db.Peoples.FirstOrDefault(experience => experience.PeopleId == id);
            return View(thisExperience);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Peoples.FirstOrDefault(experience => experience.PeopleId == id);
            db.Peoples.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
