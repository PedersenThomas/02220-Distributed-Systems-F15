using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedModel;

namespace SharedMode.UnitTestProject
{
    [TestClass]
    public class JsonSerializerTest
    {
        [TestMethod]
        public void SerializeSensorMessage()
        {
            var message = new SensorMessage {ID = "DummyID", Status = Status.Occupied};

            var json = ParkingJsonSerializer.Serialize(message);
            var parsedMessage = ParkingJsonSerializer.Deserialize(json);

            Assert.AreEqual(message.ID, parsedMessage.ID);
            Assert.AreEqual(message.Status, parsedMessage.Status);
        }

        [TestMethod]
        public void SerializeSensorEvent()
        {
            var message = new SensorMessage { ID = "DummySensorID", Status = Status.Occupied };
            var e = new ParkingLotEvent {Message = message, Time = DateTime.Now};

            var json = ParkingJsonSerializer.SerializeEvent(e);
            Debug.WriteLine(json);
            var parsedEvent = ParkingJsonSerializer.DeserializeEvent(json);

            Assert.IsNotNull(parsedEvent);
            Assert.AreEqual(e.Time, parsedEvent.Time);
            Assert.IsInstanceOfType(e.Message, message.GetType());
        }

        [TestMethod]
        public void SerializeDisplayEvent()
        {
            var message = new DisplayMessage() { ID = "DummyDisplayID", NumberOfFreeSpace = 21 };
            var e = new ParkingLotEvent { Message = message, Time = DateTime.Now };

            var json = ParkingJsonSerializer.SerializeEvent(e);
            Debug.WriteLine(json);
            var parsedEvent = ParkingJsonSerializer.DeserializeEvent(json);

            Assert.IsNotNull(parsedEvent);
            Assert.AreEqual(e.Time, parsedEvent.Time);
            Assert.IsInstanceOfType(e.Message, message.GetType());
        }
    }
}
