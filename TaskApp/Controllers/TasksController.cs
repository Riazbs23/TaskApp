using Microsoft.AspNetCore.Mvc;
using Task = TaskApp.Models.Task;


namespace TaskApp.Controllers
{
    public class TasksController : Controller
    {
        private static List <Task> tasks = new List <Task> ();

        
        public IActionResult Index()
        {
            return View(tasks);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = tasks.Count + 1;
                tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        
        public IActionResult Edit(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Task updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTask = tasks.Find(t => t.Id == id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;

                return RedirectToAction(nameof(Index));
            }
            return View(updatedTask);
        }
    }
}