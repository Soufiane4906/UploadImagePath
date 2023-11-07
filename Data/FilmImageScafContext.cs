using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmImageScaf.Models;

namespace FilmImageScaf.Data
{
    public class FilmImageScafContext : DbContext
    {
        public FilmImageScafContext (DbContextOptions<FilmImageScafContext> options)
            : base(options)
        {
        }

        public DbSet<FilmImageScaf.Models.Movie> Movie { get; set; } = default!;
        public DbSet<FilmImageScaf.Models.ModelTest> ModelTest { get; set; } = default!;
    }
}
