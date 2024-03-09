using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.BasicCommands
{
    /// <summary>
    /// Represents a command to reset canvas settings.
    /// </summary>
    public class ResetCommand : IBasicCommand
    {
        public void Execute(Canvas canvas, string[] argument)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            // Reset canvas properties
            canvas.CurrentPosition = new Point(200, 150);
            canvas.DrawingPen = new Pen(Color.Black);
            canvas.FillColor = Color.Black;

            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
