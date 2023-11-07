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
    public class DetailsModel : PageModel
    {
        private readonly FilmImageScaf.Data.FilmImageScafContext _context;

        public DetailsModel(FilmImageScaf.Data.FilmImageScafContext context)
        {
            _context = context;
        }

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
    }
}
