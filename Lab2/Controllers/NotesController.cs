using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class NotesController : Controller
    {
        private NotesDbContext _dbContext;

        public NotesController(NotesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Notes()
        {
            ViewData["notes"] = _dbContext.Notes.ToList();
            return View();
        }

        public IActionResult Create(CreateNoteModel model)
        {
            Note note = new Note
            {
                Date = DateTime.Now,
                Theme = model.Theme,
                Text = model.Text
            };
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return Redirect("/Notes/Notes");
        }

        public IActionResult Delete(long id)
        {
            var note = _dbContext.Notes.FirstOrDefault(obj => obj.Id.Equals(id));
            _dbContext.Notes.Remove(note);
            _dbContext.SaveChanges();
            return Redirect("/Notes/Notes");
        }
    }
}
