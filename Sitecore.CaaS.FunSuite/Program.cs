using System;
using System.Collections.Generic;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.EventPersistance;
using Sitecore.CaaS.WriteSide.Services;

namespace Sitecore.CaaS.FunSuite
{
    static class Program
    {
        public static IEventStore eventStore = new MemoryEventStore();

        static void Main()
        {
            eventStore.Events.DidEnqueue += Events_DidEnqueue;

            // Write side
            var service = new ItemService(eventStore);

            var itemId = Guid.NewGuid();
            var properties = new Dictionary<string, object>
            {
                {"name", "somename"},
                {"creator", "adg"},
                {"creationTime", DateTime.Now.ToUniversalTime()}  //JSON serialization should take care of this
            };
            var dimension = new Dictionary<string, string>
            {
                {"language", "en"}
            };
            var fields = new Dictionary<Guid, string>()
            {
                {Guid.NewGuid(), "Hello title!"},
                {Guid.NewGuid(), "Hello world!"}
            };

            service.Execute(new CreateItemCommand(itemId, properties));

            // Wait 500ms
            // Read item from tempStore

            service.Execute(new AddVersionCommand(itemId, dimension));

            // Wait 500ms
            // Read item from tempStore

            service.Execute(new FieldsUpdatedCommand(itemId, fields));

            // Wait 500ms
            // Read item from tempStore
        }

        private static void Events_DidEnqueue(object sender, DidEnqueueEventArgs<Tuple<string, string>> e)
        {
            Console.WriteLine("Let's aggregate!");
            Console.WriteLine("Events on the queue: "+  eventStore.Events.Count);

            //TODO: Create aggregated item and move into tempStore
        }
    }
}
