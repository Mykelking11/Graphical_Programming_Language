using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.BasicCommands
{
    /// <summary>
    /// Represents a command to toggle filling mode on or off on the canvas.
    /// </summary>
    public class FillCommand : IBasicCommand
    {
        public void Execute(Canvas canvas, string[] argument)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length >= 1)
            {
                string fillMode = argument[0].ToLower();

                switch (fillMode)
                {
                    case "on":
                        // Turn on filling mode and set fill color to current drawing pen color
                        canvas.IsFilling = true;
                        canvas.FillColor = canvas.DrawingPen.Color;
                        break;
                    case "off":
                        // Turn off filling mode
                        canvas.IsFilling = false;
                        break;
                    default:
                        // Show error message for invalid fill mode
                        MessageBox.Show("Invalid fill mode. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else
            {
                // Show error message for missing argument
                MessageBox.Show("Missing argument for 'fill' command. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
