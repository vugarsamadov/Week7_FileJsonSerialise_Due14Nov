
using System.Text;

namespace Week7_FileJsonSerialise_Due14Nov.UI
{
    internal static class ConsoleHelpers
    {
        private const ConsoleColor ERROR_COLOR = ConsoleColor.Red;
        private const ConsoleColor WARNING_COLOR = ConsoleColor.Yellow;
        private const ConsoleColor POSITIVE_COLOR = ConsoleColor.Green;
        private const string SELECTION_CURSOR = ">  ";
        public static string Buffer { get; set; } = string.Empty;


        /// <summary>
        /// Prints buffer to the console. Handles coloring (warning, error)
        /// </summary>
        public static void PrintBuffer()
        {
            if (Buffer != string.Empty)
            {
                if (Buffer.StartsWith("(!)"))
                    ConsoleHelpers.PrintError($"\n{Buffer}\n");
                else
                    ConsoleHelpers.PrintPositive($"\n{Buffer}\n");
            }
            Buffer = string.Empty;
        }

        public static void BufferError(string msg)
        {
            Buffer = string.Empty;
            Buffer = $"(!) {msg}";
        }

        public static void AddListToBuffer<T>(IList<T> elements)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var e in elements)
                sb.Append(">> ").AppendLine(e.ToString());
            Buffer = sb.ToString();
        }

        public static void InlineError(string errorMsg)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.Write(errorMsg);
            Console.ResetColor();
        }

        public static void InlineWarning(string warningMsg)
        {
            Console.ForegroundColor = WARNING_COLOR;
            Console.Write(warningMsg);
            Console.ResetColor();
        }

        public static void InlinePositive(string msg)
        {
            Console.ForegroundColor = POSITIVE_COLOR;
            Console.Write(msg);
            Console.ResetColor();
        }

        public static void InlineSelectionCursor()
        {
            Console.ForegroundColor = POSITIVE_COLOR;
            Console.Write(SELECTION_CURSOR);
            Console.ResetColor();
        }



        public static void PrintError(string errorMsg) => InlineError(errorMsg + "\n");

        public static void PrintWarning(string warningMsg) => InlineWarning(warningMsg + "\n");

        public static void PrintPositive(string msg) => InlinePositive(msg + "\n");

    }
}
