using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xkcdapi.Services
{
    public interface ISeedDataService
    {
        Task EnsureSeedData();
    }
}
