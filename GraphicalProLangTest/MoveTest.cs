using Graphical_Programming_Language;
using Graphical_Programming_Language.Implementations.BasicCommands;
using System.Drawing;

namespace GraphicalProgrammingLangTests
{
    [TestFixture]
    public class MoveTest
    {
        [Test]

        public void Execute_WithValidArguments_SetsCurrentPosition()
        {
            // Arrange
            var canvas = new Canvas(); // Assuming Canvas is a class provided by your application
            var moveToCommand = new MoveToCommand();
            string[] args = new string[] { "100", "200" }; // Valid arguments for coordinates

            // Act
            moveToCommand.Execute(canvas, args);

            // Assert
            Assert.AreEqual(new Point(100, 200), canvas.CurrentPosition);
        }

        [Test]
        public void Execute_WithInvalidArguments_ShowErrorMessage()
        {
            // Arrange
            var canvas = new Canvas();
            var moveToCommand = new MoveToCommand();
            string[] args = { "invalid", "50" };

            // Act
            moveToCommand.Execute(canvas, args);
        }
               
    }
}
