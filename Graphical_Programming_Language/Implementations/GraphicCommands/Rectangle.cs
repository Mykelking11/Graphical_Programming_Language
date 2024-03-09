using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.GraphicCommands
{

    /// <summary>
    /// Represents a command to draw a rectangle on the canvas.
    /// </summary>
    public class RectangleCommand : IGraphicsCommand
    {
        /// <inheritdoc/>
        public void Execute(Graphics graphics, string[] argument, Canvas canvas)
        {
            // Get current position, drawing pen, and command text box from the canvas
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            // Check if valid arguments for width and height are provided
            if (argument.Length == 2)
            {
                // Parse width and height from arguments
                if (int.TryParse(argument[0], out int width) && int.TryParse(argument[1], out int height))
                {
                    int x = currentPosition.X;
                    int y = currentPosition.Y;

                    // Draw or fill the rectangle based on canvas settings
                    if (canvas.IsFilling)
                    {
                        // Fill the rectangle
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillRectangle(brush, x, y, width, height);
                        }
                    }

                    // Draw the rectangle
                    graphics.DrawRectangle(drawingPen, x, y, width, height);

                    // Use Invoke to update the commandTextBox on the UI thread
                    commandTextBox.Invoke((MethodInvoker)delegate
                    {
                        commandTextBox.Clear();
                    });
                }
                else
                {
                    // Show error message for invalid width and height arguments
                    MessageBox.Show("Invalid arguments for 'rectangle' command. Please provide valid width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show error message for insufficient arguments
                MessageBox.Show("Not enough arguments for 'rectangle' command. Please provide width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
