using ProjectViper.Models.Domain.Abstract;
using ProjectViper.Models.Domain.Concrete;
using ProjectViper.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectViper.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository repo)
        {
            this.repo = repo;

            //InitDB();
        }

        IRepository repo;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TagList()
        {
            return View(repo.Tags.ToList());
        }

        [HttpPost]
        public RedirectToRouteResult AddTag(Tag tag)
        {
            repo.AddTag(tag);

            ViewBag.complete = true;

            return RedirectToAction("TagList");
        }

        [HttpPost]
        public RedirectToRouteResult DeleteTag(Tag tag)
        {
            bool complete = repo.DeleteTag(tag.Name);

            ViewBag.complete = true;

            return RedirectToAction("TagList");
        }

        private void InitDB()
        {
            //using (EFDBContext context = new EFDBContext())
            //{
            //    //Tag tag = new Tag() { Name = "Music" };
            //    //context.Tags.Add(tag);
            //    //context.SaveChanges();

            //    //FileMeta file = new FileMeta() { Name = "SomeMusic", Dir = "" };
            //    //context.Files.Add(file);
            //    //context.SaveChanges();

            //    //tag.Files.Add(file);
            //    //file.Tags.Add(tag);          
                
            //    //context.SaveChanges();


            //    //context.Tags.Add(new Tag() { Name = "Music" });
            //    //context.Tags.Add(new Tag() { Name = "Picture" });
            //    //context.Tags.Add(new Tag() { Name = "ISO Image" });
            //    //context.Tags.Add(new Tag() { Name = "Distributive" });
            //    //context.SaveChanges();
            //}
        }
    }
}