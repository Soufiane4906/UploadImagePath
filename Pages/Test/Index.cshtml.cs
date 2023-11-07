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
    public class IndexModel : PageModel
    {
        private readonly FilmImageScaf.Data.FilmImageScafContext _context;

        public IndexModel(FilmImageScaf.Data.FilmImageScafContext context)
        {
            _context = context;
        }

        public IList<ModelTest> ModelTest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ModelTest != null)
            {
                ModelTest = await _context.ModelTest.ToListAsync();
            }
        }
    }
}
