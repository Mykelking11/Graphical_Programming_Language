using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Interface
{
    /// <summary>
    /// Represents an interface for graphics commands.
    /// </summary>
    public interface IGraphicsCommand
    {
        /// <summary>
        /// Executes the graphics command.
        /// </summary>
        /// <param name="shape">The Graphics object to perform drawing operations.</param>
        /// <param name="arguments">An array of arguments passed to the command.</param>
        /// <param name="canvas">The Canvas object representing the drawing surface.</param>
        void Execute(Graphics shape, string[] arguments, Canvas canvas);
    }
}
