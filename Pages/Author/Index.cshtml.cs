using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCRUD.Models;

namespace RazorCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Author> Authors { get; set; }
        public async Task OnGet()
        {
            Authors = await _db.Author.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var findAuthor = await _db.Author.FindAsync(id);
            if(findAuthor != null)
            {
                 _db.Author.Remove(findAuthor);
                await _db.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return RedirectToPage("Index");
        }
    }
}