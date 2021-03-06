﻿using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xkcdapi.Entities;

namespace xkcdapi.Services
{
    public class AddNewComicsService : IScheduledTask
    {
        private readonly XkcdDbContext _context;
        public string Schedule => "0 0 * * *";

        public AddNewComicsService(XkcdDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            WebClient getNew = new WebClient();
            var newComic = getNew.DownloadString("http://xkcd.com/info.0.json");
            Comic deserializeNewComic = JsonConvert.DeserializeObject<Comic>(newComic);

            var newestComicInDb = _context.Comics.Max(n => n.Num);

            if (deserializeNewComic.Num > newestComicInDb)
            {
                AddNewComic(deserializeNewComic);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void AddNewComic(Comic newComic)
        {
            _context.Add(newComic);
        }
    }
}
