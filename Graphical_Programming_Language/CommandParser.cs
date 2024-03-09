namespace Graphical_Programming_Language
{
    public class CommandParser
    {

        public string Command { get; private set; } = "";

        public string[] Argument { get; private set; } = Array.Empty<string>();


        /// <summary>
        /// Initializes a new instance of the CommandParser class with the specified command text.
        /// </summary>
        /// <param name="commandText">The text of the command to parse.</param>
        public CommandParser(string commandText)
        {
            Thread parseThread = new Thread(() => ParseCommand(commandText));
            parseThread.Start();
            parseThread.Join();
        }



        /// <summary>
        /// Parses the command text to extract the command and its arguments.
        /// </summary>
        /// <param name="commandText">The text of the command to parse.</param>
        private void ParseCommand(string commandText)
        {
            string[] commandParts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (commandParts.Length == 0)
            {
                Command = "";
                Argument = Array.Empty<string>();
                return;
            }

            Command = commandParts[0];

            if (commandParts.Length > 1)
            {
                Argument = ParseArguments(commandParts, 1);
            }
            else
            {
                Argument = Array.Empty<string>();
            }
        }



        /// <summary>
        /// Parses the arguments from the command parts starting from the specified index.
        /// </summary>
        /// <param name="commandParts">The parts of the command.</param>
        /// <param name="startIndex">The index to start parsing arguments from.</param>
        /// <returns>An array containing the parsed arguments.</returns>
        private string[] ParseArguments(string[] commandParts, int startIndex)
        {
            List<string> arguments = new List<string>();

            for (int i = startIndex; i < commandParts.Length; i++)
            {
                arguments.Add(commandParts[i]);
            }

            return arguments.ToArray();
        }
    }
}
