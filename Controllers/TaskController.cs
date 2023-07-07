using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Lab5.Controllers
{
    public class TaskController : ApiController
    {
        private static List<Task> tasks = new List<Task>(); // Przykładowa lista zadań

        public IHttpActionResult CreateTask(Task task)
        {
            if (task == null)
            {
                return BadRequest("Nieprawidłowe dane zadania");
            }

            tasks.Add(task);
            return Ok("Zadanie zostało utworzone");
        }

        public IHttpActionResult GetAllTasks()
        {
            return Ok(tasks);
        }

        public IHttpActionResult GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        public IHttpActionResult UpdateTask(int id, Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;

            return Ok("Zadanie zostało zaktualizowane");
        }
        public IHttpActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return Ok("Zadanie zostało usunięte");
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
