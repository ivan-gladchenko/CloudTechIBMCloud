using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private NotesDbContext _dbContext;

        public InfoController(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("get")]
        public List<Note> GetNotes()
        {
            return _dbContext.Notes.ToList();
        }

        [HttpPost("create")]
        public Note CreateNote([FromForm] string theme, [FromForm] string text)
        {
            Note note = new Note
            {
                Date = DateTime.Now,
                Theme = theme,
                Text = text
            };
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return note;
        }

        [HttpPost("delete")]
        public bool Delete([FromForm] long id)
        {
            var entity = _dbContext.Notes.FirstOrDefault(obj => obj.Id.Equals(id));
            if (entity == null)
            {
                return false;
            }
            _dbContext.Notes.Remove(entity);
            _dbContext.SaveChanges();
           return true;
        }
    }
}
