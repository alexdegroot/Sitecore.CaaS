using System;
using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;

namespace Sitecore.CaaS.WriteSide.Eventing.Persistance
{
    public class InMemoryEventStore : IEventStore
    {
        public Task<bool> PersistEvent(ICommandAsync eventToPersist)
        {
            return Task<bool>.Factory.StartNew(() => { return true; });
            //throw new NotImplementedException();
        }
    }
}
