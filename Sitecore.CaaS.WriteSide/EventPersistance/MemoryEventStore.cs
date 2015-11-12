using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sitecore.CaaS.WriteSide.Commands;

namespace Sitecore.CaaS.WriteSide.EventPersistance
{
    public class MemoryEventStore : IEventStore
    {
        public MemoryEventStore()
        {
            Events = new TriggeredQueue<Tuple<string, string>>();
        }

        public TriggeredQueue<Tuple<string, string>> Events { get; } 

        public async Task<bool> StoreEvent(string eventName, ICommandAsync command)
        {
            return await Task.Run(() =>
            {
                var serializedEvent = JsonConvert.SerializeObject(command, Formatting.Indented);
                Events.Enqueue(new Tuple<string, string>(eventName, serializedEvent));
                Console.WriteLine("Event Stored: {0}{1}{2}", eventName, Environment.NewLine, serializedEvent);
                return true;
            });
        }
    }
}
