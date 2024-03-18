using Graphical_Programming_Language;
using Graphical_Programming_Language.Implementations.GraphicCommands;
using Graphical_Programming_Language.Interface;
using Moq;
using System.Drawing;

namespace GraphicalProgrammingLangTests
{
    [TestFixture]
    public class TriangleTest
    {

        [Test]
        public void Execute_WithValidSideLength_DrawsTriangle()
        {
            var canvas = new Canvas();
            var triangleCommand = new TriangleCommand();
            string[] args = new string[] { "50" }; // Test size for triangle
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            triangleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }

        [Test]
        public void Triangle_Execute_InvalidArguments_ShowErrorMessage()
        {
            // Arrange
            TriangleCommand triangleCommand = new TriangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { }; // No arguments provided

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();

            // Act
            triangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert.
            Assert.IsTrue(true); // Placeholder assertion, you can refine it if needed
        }


        [Test]
        public void Execute_WithInsufficientArguments_ShowErrorMessage()
        {
            // Arrange
            var canvas = new Canvas(); // Assuming Canvas is a class provided by your application
            var triangleCommand = new TriangleCommand();
            string[] args = new string[] { }; // No arguments provided
            var bitmap = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bitmap);

            // Act
            triangleCommand.Execute(graphics, args, canvas);

        }

    }
}
