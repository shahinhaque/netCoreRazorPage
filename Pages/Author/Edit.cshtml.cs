using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUD.Models;

namespace RazorCRUD
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Author Author { get; set; }
        public async Task OnGet( int id)
        {
            Author = await _db.Author.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var authFromDB = await _db.Author.FindAsync(Author.Id);
                if(authFromDB != null)
                {
                    authFromDB.Name = Author.Name;
                    authFromDB.Origin = Author.Origin;
                    authFromDB.Description = Author.Description;

                    await _db.SaveChangesAsync();

                    return RedirectToPage("Index");
                }
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}