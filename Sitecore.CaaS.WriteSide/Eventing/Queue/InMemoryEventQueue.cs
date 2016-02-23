using System;
using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;

namespace Sitecore.CaaS.WriteSide.Eventing.Queue
{
    public class InMemoryEventQueue : IEventQueue
    { 
        public Task<bool> Enqueue(string eventName, ICommandAsync command)
        {
            throw new NotImplementedException();
        }
    }
}
