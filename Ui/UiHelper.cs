using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_FileJsonSerialise_Due14Nov.UI;

namespace Week7_FileJsonSerialise_Due14Nov.Ui
{
    internal static class UiHelper
    {
        public static string PromptAndGetNonEmptyString(string prompt)
        {
            string input = null;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input == string.Empty)
                    ConsoleHelpers.PrintError("Empty input is not allowed!");

            } while (string.IsNullOrWhiteSpace(input) || input == string.Empty);

            return input;
        }

        public static Student GetStudentFromConsole()
        {
            var name = PromptAndGetNonEmptyString("Name: ");
            var surname = PromptAndGetNonEmptyString("Surname: ");
            var code = PromptAndGetNonEmptyString("Code: ");
            return new(name,surname,code);
        }
        


        public static int DisplayAndGetCommandBySelection<T>
            (T[] commands, string header = "")
        {
            int currentCmdIndex = 0;
            do
            {
                Console.Clear();
                ConsoleHelpers.PrintBuffer();

                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < commands.Length; i++)
                {
                    if (i == currentCmdIndex)
                        ConsoleHelpers.InlineSelectionCursor();
                    else
                        Console.Write("  ");
                    Console.WriteLine(commands[i]);
                }
                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentCmdIndex = currentCmdIndex - 1 < 0 ? 0 : currentCmdIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentCmdIndex = currentCmdIndex + 1 > commands.Length - 1 ? commands.Length - 1 : currentCmdIndex + 1;
                }

                if (keyPress == ConsoleKey.Enter)
                    return currentCmdIndex;

            } while (true);
        }

    }
}
