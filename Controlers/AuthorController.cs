using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorCRUD.Models;

namespace RazorCRUD.Controlers
{
    [Route("/api/Author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly ApplicationDBContext _db;
        public AuthorController(ApplicationDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Author.ToList()});
        }
    }
}