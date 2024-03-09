using Graphical_Programming_Language.Implementations;

namespace Graphical_Programming_Language
{
    public partial class Canvas : Form
    {
        private bool isFill = false;
        private Point Position = new Point(250, 150);
        private Pen PenColor = new Pen(Color.Black);
        private Color fillColor = Color.Black;
        public ShapeMaker ShapeMaker;
        public MultiLineCommands MultiLineCommands;

        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();
            CommandParser commandParser = new CommandParser("");
            ShapeMaker = new ShapeMaker(this);
            MultiLineCommands = new MultiLineCommands(this);
        }

        /// <summary>
        /// Event handler for the click event of the Run button.
        /// Parses the command entered in the commandBox and executes it using the ShapeMaker.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void runBtn_Click(object sender, EventArgs e)
        {
            string command = commandBox.Text;
            CommandParser parser = new CommandParser(command);
            ShapeMaker.ExecuteDrawing(parser);
        }



        /// <summary>
        /// Event handler for the click event of the Load Script button.
        /// Loads the content of a text file into the richCommandBox.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void LoadScript_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files|*.txt|All files|*.*";
                openFileDialog.Title = "Open Script File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    try
                    {
                        string scriptContent = File.ReadAllText(fileName);
                        richCommandBox.Text = scriptContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the click event of the Run Script button.
        /// Executes the commands provided in the richCommandBox asynchronously.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void runScriptBtn_Click(object sender, EventArgs e)
        {
            string scriptContent = richCommandBox.Text;
            await Task.Run(() => MultiLineCommands.ExecuteCommands(scriptContent));
        }


        /// <summary>
        /// Event handler for the click event of the Save Script button.
        /// Saves the content of the richCommandBox to a text file.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveScriptBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
                saveFileDialog.Title = "Save Script File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    try
                    {
                        File.WriteAllText(fileName, richCommandBox.Text);
                        MessageBox.Show("Script saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// Event handler for the click event of the Clear button.
        /// Clears the drawing canvas.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            string command = "clear";
            CommandParser parser = new CommandParser(command);
            ShapeMaker.ExecuteDrawing(parser);
        }

        /// <summary>
        /// Event handler for the click event of the Reset button.
        /// Resets the drawing canvas to its initial state.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            string command = "reset";
            CommandParser parser = new CommandParser(command);
            ShapeMaker.ExecuteDrawing(parser);
        }


        /// <summary>
        /// Handles the MouseMove event of the PictureBox control to display the current mouse coordinates.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            // Get current mouse coordinates
            Point mousePosition = e.Location;
            // Display coordinates in the status bar or any other suitable location
            // Example: display in the form's title bar
            this.Text = $"Mouse Position: {mousePosition.X}, {mousePosition.Y}";
        }


        /// <summary>
        /// Handles the Paint event of the PictureBox control to draw a dot at the current position.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Determine the size of the dot
            int dotSize = 5;
            // Calculate the coordinates for drawing the dot
            int x = Position.X - dotSize / 2;
            int y = Position.Y - dotSize / 2;
            // Draw a filled ellipse (dot) at the calculated coordinates
            e.Graphics.FillEllipse(Brushes.Red, x, y, dotSize, dotSize);
        }



        /// <summary>
        /// Gets the TextBox control for entering commands.
        /// </summary>
        public TextBox CommandTextBox
        {
            get { return commandBox; }
        }



        /// <summary>
        /// Gets or sets the current position for drawing shapes on the canvas.
        /// </summary>
        public Point CurrentPosition
        {
            get { return Position; }
            set
            {
                Position = value;
                pictureBox.Invalidate();
            }
        }


        /// <summary>
        /// Gets the PictureBox control used for drawing on the canvas.
        /// </summary>
        public PictureBox DrawingPictureBox
        {
            get { return pictureBox; }
        }


        /// <summary>
        /// Gets or sets the Pen used for drawing on the canvas.
        /// </summary>
        public Pen DrawingPen
        {
            get { return PenColor; }
            set { PenColor = value; }
        }



        /// <summary>
        /// Gets or sets the color used for filling shapes on the canvas.
        /// </summary>
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }



        /// <summary>
        /// Gets or sets a value indicating whether filling mode is enabled on the canvas.
        /// </summary>
        public bool IsFilling
        {
            get { return isFill; }
            set { isFill = value; }
        }

    }
}
