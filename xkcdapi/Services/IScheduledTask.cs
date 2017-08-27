using System.Threading;
using System.Threading.Tasks;

namespace xkcdapi.Services
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
