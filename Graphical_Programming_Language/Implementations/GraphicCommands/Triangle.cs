using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.GraphicCommands
{
    /// <summary>
    /// Represents a command to draw a triangle on the canvas.
    /// </summary>
    public class TriangleCommand : IGraphicsCommand
    {
        /// <inheritdoc/>
        public void Execute(Graphics graphics, string[] argument, ICanvas canvas)
        {
            // Get current position, drawing pen, and command text box from the canvas
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            // Check if a valid side length is provided as an argument
            if (argument.Length == 1)
            {
                // Parse side length from the argument
                if (int.TryParse(argument[0], out int sideLength))
                {
                    // Calculate coordinates of triangle vertices
                    int x1 = currentPosition.X;
                    int y1 = currentPosition.Y;
                    int x2 = x1 + sideLength;
                    int y2 = y1;
                    int x3 = x1 + sideLength / 2;
                    int y3 = y1 - (int)(Math.Sqrt(3) * sideLength / 2);

                    // Define the triangle vertices
                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    // Draw or fill the triangle based on canvas settings
                    if (canvas.IsFilling)
                    {
                        // Fill the triangle
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillPolygon(brush, points);
                        }
                    }

                    // Draw the triangle
                    graphics.DrawPolygon(drawingPen, points);

                    // Use Invoke to update the commandTextBox on the UI thread
                    /* commandTextBox.Invoke((MethodInvoker)delegate
                     {
                         commandTextBox.Clear();
                     });*/
                }
                else
                {
                    // Show error message for invalid side length argument
                    MessageBox.Show("Invalid arguments for 'triangle' command. Please provide a valid side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show error message for insufficient arguments
                MessageBox.Show("Not enough arguments for 'triangle' command. Please provide a side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
