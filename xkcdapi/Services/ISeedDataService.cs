using System.Threading.Tasks;

namespace xkcdapi.Services
{
    public interface ISeedDataService
    {
        Task EnsureSeedData();
    }
}
