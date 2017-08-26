using System;
using System.Linq;
using xkcdapi.Entities;

namespace xkcdapi.Repositories
{
    public interface IComicRepository
    {
        IQueryable<Comic> GetAll();
        Comic GetSingle(Guid id);
        void Add(Comic item);
        void Delete(Guid id);
        void Update(Comic item);
        bool Save();
    }
}