using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

            WebClient getLatest = new WebClient();
            var latestComicNumber = 0;
            var latestComic = getLatest.DownloadString("http://xkcd.com/info.0.json");
            Comic deserializeLatest = JsonConvert.DeserializeObject<Comic>(latestComic);
            latestComicNumber = deserializeLatest.Num + 1;

            //Get all of the comics
            for (var i = 1; i < latestComicNumber; i++)
            {
                if (i != 404)
                {
                    //get json
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString("https://xkcd.com/" + i + "/info.0.json");

                        Comic deserializedComic = JsonConvert.DeserializeObject<Comic>(json);

                        deserializedComic.Id = Guid.NewGuid();

                        _context.Add(deserializedComic);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            getLatest.Dispose();


        }
    }
}
