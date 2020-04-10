using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUD.Models;

namespace RazorCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public Author Author { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(Author Author)
        {
            if (ModelState.IsValid)
            {
                await _db.Author.AddAsync(Author);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}