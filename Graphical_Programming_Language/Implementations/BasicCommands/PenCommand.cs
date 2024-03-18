using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.BasicCommands
{
    /// <summary>
    /// Represents a command to set the drawing pen color on the canvas.
    /// </summary>
    public class PenCommand : IBasicCommand
    {
        private static readonly Dictionary<string, Color> ColorMap = new Dictionary<string, Color>
        {
            { "red", Color.Red },
            { "blue", Color.Blue },
            { "green", Color.Green },
            { "yellow", Color.Yellow },
            { "orange", Color.Orange },
            { "purple", Color.Purple },
            { "pink", Color.Pink },
            { "cyan", Color.Cyan },
            { "magenta", Color.Magenta },
            { "brown", Color.Brown },
            { "black", Color.Black },
            { "white", Color.White },
            { "gray", Color.Gray },
            { "darkred", Color.DarkRed },
            { "darkblue", Color.DarkBlue },
            { "darkgreen", Color.DarkGreen },
            { "darkorange", Color.DarkOrange },
            { "darkcyan", Color.DarkCyan },
            { "lavender", Color.Lavender },
            { "lime", Color.Lime }
        };

        public void Execute(Canvas canvas, string[] argument)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            // Get the current drawing pen from the canvas
            Pen currentPen = canvas.DrawingPen;

            if (argument.Length >= 1)
            {
                // Get the color name from the argument and convert it to lowercase
                string colorName = argument[0].ToLower();

                if (ColorMap.TryGetValue(colorName, out Color newColor))
                {
                    // Set the new drawing pen color and fill color on the canvas
                    canvas.DrawingPen = new Pen(newColor);
                    canvas.FillColor = newColor;
                }
                else
                {
                    // Show error message for invalid pen color
                    MessageBox.Show("Invalid pen color. Available colors: red, blue, ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Show error message for invalid pen command
                MessageBox.Show("Invalid pen command. Please provide a valid color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Use Invoke to update the commandTextBox on the UI thread
           /* commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });*/
        }
    }
}
