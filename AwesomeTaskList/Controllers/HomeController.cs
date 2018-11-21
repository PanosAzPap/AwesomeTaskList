using AwesomeTaskList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeTaskList.Controllers
{
    public class HomeController : Controller
    {
        static List<Task> Tasks;
        public HomeController()
        {
            Tasks = new List<Task>();
            Tasks.Add(new Task { Title = "Wash Car", Description = "", Completed = false, DueTime = new DateTime(2018, 09, 09) });
            Tasks.Add(new Task { Title = "Super Market", Description = "List", Completed = true, DueTime = new DateTime(2018, 09, 15) });
            Tasks.Add(new Task { Title = "Pay the Phonebill", Description = "", Completed = false, DueTime = new DateTime(2018, 10, 09) });
            Tasks.Add(new Task { Title = "Fix the bike", Description = "", Completed = false });
            Tasks.Add(new Task { Title = "Laundry", Description = "White", Completed = false, DueTime = DateTime.Now });
        }

        public ActionResult Index()
        {
            List<Task> tasks = null;
            using (var db = new AppContext())
            {
                tasks = db.Tasks.ToList();
            }
            return View(tasks);
        }

        public ActionResult Seed()
        {
            using (var db = new AppContext())
            {
                foreach (var item in Tasks)
                {
                    db.Tasks.Add(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Index(int? Id)
        //{
        //    //ViewData["Id"] = Id;
        //    ViewBag.Id = Id;
        //    return View(Id);
        //}
    }
}