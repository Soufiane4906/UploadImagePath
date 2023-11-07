using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmImageScaf.Data;
using FilmImageScaf.Models;

namespace FilmImageScaf.Pages.Test
{
    public class DeleteModel : PageModel
    {
        private readonly FilmImageScaf.Data.FilmImageScafContext _context;

        public DeleteModel(FilmImageScaf.Data.FilmImageScafContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ModelTest ModelTest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ModelTest == null)
            {
                return NotFound();
            }

            var modeltest = await _context.ModelTest.FirstOrDefaultAsync(m => m.Id == id);

            if (modeltest == null)
            {
                return NotFound();
            }
            else 
            {
                ModelTest = modeltest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ModelTest == null)
            {
                return NotFound();
            }
            var modeltest = await _context.ModelTest.FindAsync(id);

            if (modeltest != null)
            {
                ModelTest = modeltest;
                _context.ModelTest.Remove(ModelTest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
