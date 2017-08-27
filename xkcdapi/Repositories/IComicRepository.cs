using System;
using System.Linq;
using xkcdapi.Entities;

namespace xkcdapi.Repositories
{
    public interface IComicRepository
    {
        IQueryable<Comic> GetAll();
        Comic GetSingle(int id);
        void Add(Comic item);
        void Delete(int id);
        void Update(Comic item);
        bool Save();
    }
}