using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Interface
{
    /// <summary>
    /// Represents an interface for generic commands.
    /// </summary>
    public interface IBasicCommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="canvas">The Canvas object representing the drawing surface.</param>
        /// <param name="arguments">An array of arguments passed to the command.</param>
        void Execute(Canvas canvas, string[] arguments);
    }
}
