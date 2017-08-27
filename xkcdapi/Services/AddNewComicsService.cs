using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xkcdapi.Entities;
using xkcdapi.Repositories;

namespace xkcdapi.Services
{
    public class AddNewComicsService : IAddNewComicsService
    {
        private readonly XkcdDbContext _context;

        public AddNewComicsService(XkcdDbContext context)
        {
            _context = context;
        }

        public async Task AddComic()
        {
            WebClient getNew = new WebClient();
            var newComic = getNew.DownloadString("http://xkcd.com/info.0.json");
            Comic deserializeNewComic = JsonConvert.DeserializeObject<Comic>(newComic);

            var newestComicInDb = _context.Comics.Max(n => n.Num);

            
            if (deserializeNewComic.Num > newestComicInDb)
            {
                AddNewComic(deserializeNewComic);
            }
            await _context.SaveChangesAsync();
        }

        public void AddNewComic(Comic newComic)
        {
            _context.Add(newComic);
        }
    }
}
