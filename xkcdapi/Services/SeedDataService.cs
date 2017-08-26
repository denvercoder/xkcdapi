using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xkcdapi.Entities;

namespace xkcdapi.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly XkcdDbContext _context;

        public SeedDataService(XkcdDbContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            _context.Database.EnsureCreated();

            _context.Comics.RemoveRange(_context.Comics);
            _context.SaveChanges();


            Comic comic = new Comic();
            comic.Id = Guid.NewGuid();
            comic.Alt = "Don\'t we all.";
            comic.Day = "1";
            comic.Img = "https://imgs.xkcd.com/comics/barrel_cropped_(1).jpg";
            comic.Link = "";
            comic.Month = "1";
            comic.News = "";
            comic.Num = 1;
            comic.SafeTitle = "Barrel - Part 1";
            comic.Title = "Barrel - Part 1";
            comic.Transcript = "[[A boy sits in a barrel which is floating in an ocean.]] Boy: I wonder where I\'ll float next? [[The barrel drifts into the distance. Nothing else can be seen.]] {{Alt: Don\'t we all.}}";
            comic.Year = "2006";

            _context.Add(comic);

            Comic comic2 = new Comic();
            comic2.Id = Guid.NewGuid();
            comic2.Alt = "\'Petit\' being a reference to Le Petit Prince, which I only thought about halfway through the sketch";
            comic2.Day = "1";
            comic2.Img = "https://imgs.xkcd.com/comics/tree_cropped_(1).jpg";
            comic2.Link = "";
            comic2.Month = "1";
            comic2.News = "";
            comic2.Num = 2;
            comic2.SafeTitle = "Petit Trees (sketch)";
            comic2.Title = "Petit Trees (sketch)";
            comic2.Transcript = "[[Two trees are growing on opposite sides of a sphere.]] {{Alt-title: \'Petit\' being a reference to Le Petit Prince, which I only thought about halfway through the sketch}}";
            comic2.Year = "2006";

            _context.Add(comic2);

            Comic comic3 = new Comic();
            comic3.Id = Guid.NewGuid();
            comic3.Alt = "Hello, island";
            comic3.Day = "1";
            comic3.Img = "https://imgs.xkcd.com/comics/island_color.jpg";
            comic3.Link = "";
            comic3.Month = "1";
            comic3.News = "";
            comic3.Num = 1;
            comic3.SafeTitle = "Island (sketch)";
            comic3.Title = "Island (sketch)";
            comic3.Transcript = "[[A sketch of an Island]] {{Alt:Hello, island}}";
            comic3.Year = "2006";

            _context.Add(comic3);

            await _context.SaveChangesAsync();

        }
    }
}
