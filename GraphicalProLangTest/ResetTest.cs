using Graphical_Programming_Language.Implementations.BasicCommands;
using Graphical_Programming_Language;
using System.Drawing;

namespace GraphicalProgrammingLangTests
{
    [TestFixture]
    public class ResetTest
    {
        [Test]

        public void Execute_ResetsCanvasProperties()
        {
            // Arrange
            ResetCommand resetCommand = new ResetCommand();
            Canvas canvas = new Canvas(); 

            // Act
            resetCommand.Execute(canvas, new string[] { });

            // Assert
            Assert.AreEqual(new Point(200, 150), canvas.CurrentPosition);
            Assert.AreEqual(Color.Black, canvas.DrawingPen.Color);
            Assert.AreEqual(Color.Black, canvas.FillColor);

        }
    }
}