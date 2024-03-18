using Graphical_Programming_Language.Implementations.BasicCommands;
using Graphical_Programming_Language;

namespace GraphicalProgrammingLangTests
{
    [TestFixture]
    public class FillTest
    {
        [Test]

        public void Execute_FillCommand_OnMode()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] arguments = { "on" };

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            Assert.IsTrue(canvas.IsFilling);
            Assert.AreEqual(canvas.DrawingPen.Color, canvas.FillColor);
        }


        [Test]
        public void Execute_FillCommand_OffMode()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] arguments = { "off" };

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            Assert.IsFalse(canvas.IsFilling);
        }

        [Test]
        public void Execute_FillCommand_InvalidMode()
        {
            // Arrange
            Canvas canvas = new Canvas();
            FillCommand fillCommand = new FillCommand();
            string[] arguments = { "invalid" }; // Using invalid mode

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            Assert.IsFalse(canvas.IsFilling);
        }



    }
}
