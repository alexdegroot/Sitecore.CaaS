using System;
using System.Collections.Generic;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.Eventing.Persistance;
using Sitecore.CaaS.WriteSide.Eventing.Queue;
using Sitecore.CaaS.WriteSide.Services;
using EventHandler = Sitecore.CaaS.WriteSide.Eventing.EventHandler;

namespace Sitecore.CaaS.FunSuite
{
    static class Program
    {
        static void Main()
        {
            var eventQueue = new InMemoryEventQueue();
            var eventStore = new InMemoryEventStore();

            var eventHandler = new EventHandler(eventQueue, eventStore);

            // Write side
            var service = new ItemService(eventHandler);

            var itemId = Guid.NewGuid();
            var properties = new Dictionary<string, object>
            {
                {"name", "somename"},
                {"creator", "adg"},
                {"creationTime", DateTime.Now.ToUniversalTime()}
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
    }
}
