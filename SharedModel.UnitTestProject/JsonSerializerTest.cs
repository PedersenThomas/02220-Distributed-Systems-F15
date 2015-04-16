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
        public void SerializeSensorEvent()
        {
            var message = new SensorMessage { ID = "DummySensorID", Status = Status.Occupied };
            var e = new ParkingLotEvent {Message = message, Time = DateTime.Now};

            var json = ParkingJsonSerializer.Serialize(e);
            Debug.WriteLine(json);
            var parsedEvent = ParkingJsonSerializer.Deserialize(json);

            Assert.IsNotNull(parsedEvent);
            Assert.AreEqual(e.Time, parsedEvent.Time);
            Assert.IsInstanceOfType(e.Message, message.GetType());
        }

        [TestMethod]
        public void SerializeDisplayEvent()
        {
            var message = new DisplayMessage() { ID = "DummyDisplayID", NumberOfFreeSpace = 21 };
            var e = new ParkingLotEvent { Message = message, Time = DateTime.Now };

            var json = ParkingJsonSerializer.Serialize(e);
            Debug.WriteLine(json);
            var parsedEvent = ParkingJsonSerializer.Deserialize(json);

            Assert.IsNotNull(parsedEvent);
            Assert.AreEqual(e.Time, parsedEvent.Time);
            Assert.IsInstanceOfType(e.Message, message.GetType());
        }
    }
}
