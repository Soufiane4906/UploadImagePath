using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmImageScaf.Data;
using FilmImageScaf.Models;

namespace FilmImageScaf.Pages.Test
{
    public class EditModel : PageModel
    {
        private readonly FilmImageScaf.Data.FilmImageScafContext _context;

        public EditModel(FilmImageScaf.Data.FilmImageScafContext context)
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

            var modeltest =  await _context.ModelTest.FirstOrDefaultAsync(m => m.Id == id);
            if (modeltest == null)
            {
                return NotFound();
            }
            ModelTest = modeltest;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ModelTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelTestExists(ModelTest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ModelTestExists(int id)
        {
          return (_context.ModelTest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
