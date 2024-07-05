using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoLab.Models;

namespace ToDoLab.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDoItem> toDoItems = new List<ToDoItem>();

        public ActionResult Index()
        {
            return View(toDoItems);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDoItem toDoItem)
        {
            toDoItems.Add(toDoItem);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var itemToDelete = toDoItems.FirstOrDefault(x => x.Id == id);
            if (itemToDelete != null)
                toDoItems.Remove(itemToDelete);

            return RedirectToAction("Index");
        }
    }
}
