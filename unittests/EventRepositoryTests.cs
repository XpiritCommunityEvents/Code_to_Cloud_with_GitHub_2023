using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Catalog.Repositories;
using GloboTicket.Catalog.Infrastructure;
using GloboTicket.Catalog;
using Microsoft.Extensions.Logging;
namespace unittests
{
    [TestClass]
    public class EventRepositoryTests
    {
        private Mock<ILogger<EventRepository>> mockLogger;
        private EventRepository eventRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockLogger = new Mock<ILogger<EventRepository>>();
            eventRepository = new EventRepository(mockLogger.Object);
        }

        [TestMethod]
        public async Task AddArtist_ShouldReturnAddedArtist()
        {
            var artist = await eventRepository.AddArtist("Artist3", "Genre3");
            Assert.AreEqual("Artist3", artist.Name);
            Assert.AreEqual("Genre3", artist.Genre);
        }

    

        [TestMethod]
        public async Task GetArtistById_ShouldReturnCorrectArtist()
        {
            var addedArtist = await eventRepository.AddArtist("Artist4", "Genre4");

            var artist = await eventRepository.GetArtistById(addedArtist.Id);
            Assert.AreEqual(addedArtist.Id, artist.Id);
        }

        [TestMethod]
        public async Task AddEvent_ShouldReturnAddedEvent()
        {
            var @event = new Event { EventId = Guid.NewGuid(), Name = "Event3" };
            var result = await eventRepository.AddEvent(@event);
            Assert.AreEqual(@event.EventId, result.EventId);

            var eventbyId = await eventRepository.GetEventById(@event.EventId);
            Assert.AreEqual(@event.EventId, eventbyId.EventId);
        }
    }
}