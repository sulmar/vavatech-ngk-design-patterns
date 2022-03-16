using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace StatePattern.UnitTests
{

    [TestClass]
    public class LampTests
    {
        [TestMethod]
        public void Graph_Call_ShouldReturnsGraph()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            string graph = lamp.Graph;

            // Assert
            Assert.IsNotNull(graph);
        }

        [TestMethod]
        public void PushDown_Init_ShouldIsOff()
        {
            // Arrange

            // Act
            Lamp lamp = new Lamp();

            // Assert
            Assert.AreEqual(Lamp.LampState.Off, lamp.State);

        }

        [TestMethod]
        public void PushDown_Once_ShouldIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();

            // Assert
            Assert.AreEqual(Lamp.LampState.On, lamp.State);
        }

        [TestMethod]
        public void PushDown_PushUp_ShouldIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushUp();

            // Assert
            Assert.AreEqual(Lamp.LampState.Off, lamp.State);
        }

        [TestMethod]
        public void PushDown_Twice_ShouldReturnBlinking()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushDown();
            lamp.PushDown();

            // Assert
            Assert.AreEqual(Lamp.LampState.Blinking, lamp.State);
        }

        [TestMethod]
        public void Timer_Elapsed_ShouldReturnFalse()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();

            Assert.AreEqual(Lamp.LampState.On, lamp.State);

            Thread.Sleep(5100);

            // Assert
            Assert.AreEqual(Lamp.LampState.Off, lamp.State);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushDown_Twice_ShouldThrowException()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushDown();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushUp_Twice_ShouldThrowException()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushUp();
            lamp.PushUp();

            // Assert
        }
    }
}
