using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations.BasicCommands
{
    /// <summary>
    /// Represents a command to clear the screen on the canvas.
    /// </summary>
    public class ClearScreen : IBasicCommand
    {
        public void Execute(Canvas canvas, string[] args)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            // Invalidate the drawing area of the canvas to clear the screen
            canvas.DrawingPictureBox.Invalidate();

            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
