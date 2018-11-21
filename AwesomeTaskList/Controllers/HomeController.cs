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

        public ActionResult Index()
        {
            List<Task> tasks = null;
            using (var db = new AppContext())
            {
                tasks = db.Tasks.ToList();
            }
            return View(tasks);
        }

        public ActionResult Create()
        {
            ViewData["InvalidTitle"] = false;
            return View(new Task());
        }

        [HttpPost]
        public ActionResult CreateTask(string title, string description, DateTime? dueDate)
        {
            Task task = new Task()
            {
                Title = title,
                Description = description,
                DueTime = dueDate
            };
            if (!string.IsNullOrWhiteSpace(task.Title))
            {
                using (var db = new AppContext())
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                }
            }
            else
            {
                ViewData["InvalidTitle"] = true;
                return View("Create", task);
            }

            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int Id)
        {
            using (var db = new AppContext())
            {
                Task task = db.Tasks.Find(Id);
                db.Entry(task).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Task task = new Task();
            using (var db = new AppContext())
            {
                task = db.Tasks.Find(Id);
            }

            return View(task);
        }

        [HttpPost]
        public ActionResult EditTask(int id, string title, string description, DateTime? dueDate )
        {
            Task task = new Task();

            using (var db = new AppContext())
            {
                task = db.Tasks.Find(id);
                task.Title = title;
                task.Description = description;
                task.DueTime = dueDate;

                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Complete(int Id)
        {
            Task task = new Task();

            using (var db = new AppContext())
            {
                task = db.Tasks.Find(Id);
                if (task.Completed)
                {
                    task.Completed = false;
                }
                else
                {
                    task.Completed = true;
                }

                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult IncompleteTasks()
        {
            List<Task> Incomplete = new List<Task>();
            using (var db = new AppContext())
            {
                Incomplete = db.Tasks.Where(t => t.Completed == false).ToList();
            }
            return View("Index", Incomplete);
        }

        public ActionResult CompleteTasks()
        {
            List<Task> Complete = new List<Task>();
            using (var db = new AppContext())
            {
                Complete = db.Tasks.Where(t => t.Completed == true).ToList();
            }
            return View("Index", Complete);
        }
    }
}