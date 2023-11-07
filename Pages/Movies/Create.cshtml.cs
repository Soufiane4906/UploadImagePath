using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FilmImageScaf.Data;
using FilmImageScaf.Models;
using Microsoft.AspNetCore.Hosting;

namespace FilmImageScaf.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly FilmImageScaf.Data.FilmImageScafContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public CreateModel(FilmImageScafContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


      

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Movie.ImageFile != null)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string uniqueFileName = Guid.NewGuid() + "_" + Movie.ImageFile.FileName;
                    string filePath = Path.Combine(webRootPath, "images", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Movie.ImageFile.CopyToAsync(stream);
                    }

                    Movie.ImagePath = "images/" + uniqueFileName;

                    _context.Movie.Add(Movie);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError("ModelTest.ImageFile", "Please select a file to upload.");
                }
            }

            return Page();
        }

    }
}