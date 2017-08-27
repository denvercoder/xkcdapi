using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xkcdapi.Entities;

namespace xkcdapi.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private XkcdDbContext _context;

        public ComicRepository(XkcdDbContext context)
        {
            _context = context;
        }

        public IQueryable<Comic> GetAll()
        {

            return _context.Comics;
        }

        public Comic GetSingle(int id)
        {
            return _context.Comics.FirstOrDefault(x => x.Num == id);
        }

        public void Add(Comic item)
        {
            _context.Comics.Add(item);
        }

        public void Delete(int id)
        {
            Comic Comic = GetSingle(id);
            _context.Comics.Remove(Comic);
        }

        public void Update(Comic item)
        {
            _context.Comics.Update(item);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
