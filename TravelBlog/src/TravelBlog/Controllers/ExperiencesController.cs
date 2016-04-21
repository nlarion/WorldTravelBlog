using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelBlogDbContext db = new TravelBlogDbContext();
        public IActionResult Index()
        {
            return View(db.Experiences.Include(experience => experience.Location).ToList());
        }
        public IActionResult Details(int id)
        {
            ViewBag.Location = db.Locations.ToList();
            var experience = db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            return View(experience);
        }
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(items => items.ExperienceId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View(thisExperience);
        }
        [HttpPost]
        public ActionResult Update(Experience experience)
        {
            db.Entry(experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            return View(thisExperience);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
