using Sitecore.CaaS.WriteSide.Commands;
using System.Threading.Tasks;

namespace Sitecore.CaaS.WriteSide.Eventing.Persistance
{
    public interface IEventStore
    {
        Task<bool> PersistEvent(ICommandAsync eventToPersist);
    }
}