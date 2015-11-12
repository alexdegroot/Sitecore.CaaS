using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.EventPersistance;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public interface ICommandAsync
    {
        Task<bool> ExecuteAsync(IEventStore eventStore);
    }
}