using Graphical_Programming_Language.Implementations.BasicCommands;
using Graphical_Programming_Language.Implementations.GraphicCommands;
using Graphical_Programming_Language.Interface;

namespace Graphical_Programming_Language.Implementations
{
    public class ShapeMaker
    {
        private Canvas canvas;
        private readonly object _locker = new object();



        /// <summary>
        /// Dictionary of basic commands.
        /// </summary>
        private Dictionary<string, IBasicCommand> basicCommands = new Dictionary<string, IBasicCommand>
        {
            { "moveto", new MoveToCommand() },
            { "drawto", new DrawToCommand() },
            { "fill", new FillCommand() },
            { "reset", new ResetCommand() },
            { "clear", new ClearScreen() },
            { "pen", new PenCommand() }
        };


        /// <summary>
        /// Dictionary of graphics commands.
        /// </summary>
        private Dictionary<string, IGraphicsCommand> graphicsCommands = new Dictionary<string, IGraphicsCommand>
        {
            { "rectangle", new RectangleCommand() },
            { "circle", new CircleCommand() },
            { "triangle", new TriangleCommand() },
        };

        /// <summary>
        /// Initializes a new instance of the ShapeMaker class with the specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas on which the commands will be executed.</param>
        public ShapeMaker(Canvas canvas)
        {
            this.canvas = canvas;
        }


        /// <summary>
        /// Executes the drawing command parsed by the CommandParser.
        /// </summary>
        /// <param name="parser">The CommandParser containing the parsed command.</param>
        public void ExecuteDrawing(CommandParser parser)
        {
            if (canvas.InvokeRequired)
            {
                canvas.Invoke(new Action(() => ExecuteDrawingInternal(parser)));
            }
            else
            {
                ExecuteDrawingInternal(parser);
            }
        }



        /// <summary>
        /// Executes the drawing command internally after checking if the invocation is required.
        /// </summary>
        /// <param name="parser">The CommandParser containing the parsed command.</param>
        private void ExecuteDrawingInternal(CommandParser parser)
        {
            lock (_locker)
            {
                using (Graphics graphics = canvas.DrawingPictureBox.CreateGraphics())
                {
                    switch (parser.Command.ToLower())
                    {
                        case "moveto":
                        case "drawto":
                        case "fill":
                        case "reset":
                        case "clear":
                        case "pen":
                            basicCommands[parser.Command.ToLower()].Execute(canvas, parser.Argument);
                            break;
                        case "rectangle":
                        case "circle":
                        case "triangle":
                            graphicsCommands[parser.Command.ToLower()].Execute(graphics, parser.Argument, canvas);
                            break;
                        default:
                            MessageBox.Show("Unrecognized command: " + parser.Command, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
    }
}
