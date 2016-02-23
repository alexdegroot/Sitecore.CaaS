using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.Eventing.Persistance;
using Sitecore.CaaS.WriteSide.Eventing.Queue;

namespace Sitecore.CaaS.WriteSide.Eventing
{
    public class EventHandler : IEventHandler
    {
        public EventHandler(IEventQueue eventQueue, IEventStore eventStore)
        {
            // TODO: Validate if input is null
            EventQueue = eventQueue;
            EventStore = eventStore;
        }

        public IEventQueue EventQueue
        {
            get;
        }

        public IEventStore EventStore
        {
            get;
        }

        public async Task<bool> HandleEvent(string eventName, ICommandAsync command)
        {
            //var serializedEvent = JsonConvert.SerializeObject(command, Formatting.Indented);

            // TODO: Consider how to implement the sort of transaction scope for failing
            await EventStore.PersistEvent(command);
            await EventQueue.Enqueue(eventName, command);

            return true;
        }
    }
}
