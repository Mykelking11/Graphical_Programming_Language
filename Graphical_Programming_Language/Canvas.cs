namespace Graphical_Programming_Language
{
    public partial class Canvas : Form
    {
        private bool isFill = false;
        private Point Position = new Point(250, 150);
        private Pen PenColor = new Pen(Color.Black);
        private Color fillColor = Color.Black;


        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {

        }

        private void LoadScript_Click(object sender, EventArgs e)
        {

        }

        private void runScriptBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveScriptBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {

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
