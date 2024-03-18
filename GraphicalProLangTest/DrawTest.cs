using Graphical_Programming_Language.Implementations.BasicCommands;
using Graphical_Programming_Language;
using System.Drawing;

namespace GraphicalProgrammingLangTests
{
    [TestFixture]
    public class DrawTest
    {
        [Test]
        public void Execute_DrawsLineToSpecifiedPoint()
        {
            // Arrange
            var canvas = new Canvas(); // Assuming Canvas is a class provided by your application
            var drawToCommand = new DrawToCommand();
            string[] arguments = new string[] { "100", "100" }; // Destination coordinates

            
            // Act
            drawToCommand.Execute(canvas, arguments);

            // Assert
            Assert.AreEqual(new Point(100, 100), canvas.CurrentPosition);
        }

        [Test]
        public void Execute_WithInvalidArguments_ThrowsExceptionWithErrorMessage()
        {
            var canvas = new Canvas();
            var drawToCommand = new DrawToCommand();
            string[] args = { "invalid", "50" };

            drawToCommand.Execute(canvas, args);
        }
    }
}
