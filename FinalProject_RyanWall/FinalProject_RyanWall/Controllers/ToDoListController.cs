using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject_RyanWall.Data;
using FinalProject_RyanWall.Models;

namespace FinalProject_RyanWall.Controllers
{
    public class ToDoListController : Controller
    {
        private ToDoDBContext db = new ToDoDBContext();

        // GET: ToDoList
        public ActionResult Index()
        {
            return View(db.ToDoLists.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked")] IList<ToDoList> todolist, int id)
        {
          
           if (ModelState.IsValid)
            {
                ToDoList list = db.ToDoLists.Find(id);
                
                //ToDoList list = db.ToDoLists.Find(todolist[id].ToDoListId);
                //ToDoList  = db.Entry.Where(c => c.Id == model.ToDoListId).FirstOrDefault();
                list.NameOfDuty = todolist[id].NameOfDuty;
                list.Date = todolist[id].Date;
                list.DateToFinish = todolist[id].DateToFinish;
                //    db.Entry(todolist).State = EntityState.Modified;
                list.IsChecked = todolist[id].IsChecked;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(db.ToDoLists.ToList());
        }



        // GET: ToDoList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // GET: ToDoList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked")] ToDoList toDoList)
        {
            bool.Parse(toDoList.IsChecked.ToString());
            if (ModelState.IsValid)
            {
                db.ToDoLists.Add(toDoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoList);
        }


        
        //public ActionResult Edit2(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToDoList toDoList = db.ToDoLists.Find(id);
        //    if (toDoList == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView(toDoList);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit2([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked")] ToDoList toDoList)
        //{
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(toDoList).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(toDoList);
        //}


        







        public ActionResult Edit2(int id)
        {
            ToDoList model = db.ToDoLists.Find(id);
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Edit2(ToDoList model)
        {
            if (ModelState.IsValid)
            {
                ToDoList todolist = db.ToDoLists.Find(model.ToDoListId);
                //ToDoList  = db.Entry.Where(c => c.Id == model.ToDoListId).FirstOrDefault();
                todolist.NameOfDuty = model.NameOfDuty;
                todolist.Date = model.Date;
                todolist.DateToFinish = model.DateToFinish;


                return Json(JsonFactory.SuccessResponse(todolist), JsonRequestBehavior.DenyGet);

            }
            else
            {
                return Json(JsonFactory.ErrorResponse("Please review your form"), JsonRequestBehavior.DenyGet);
            }
        }
        // GET: ToDoList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }


        // POST: ToDoList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoList);
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoList toDoList = db.ToDoLists.Find(id);
            db.ToDoLists.Remove(toDoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
