using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class Prompts
    {
        internal const string Choice = "Enter your choice: ";
        internal const string Quantity = "Enter the quantity: ";
        internal const string anykeyContinue = "Press Any Key to Continue. ";
        internal const string invalidInput = "Invalid Input. Please Enter Numbers Only. ";
        internal static void ContinueKey()
        {
            int leftPadding = (Console.WindowWidth - anykeyContinue.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.Write(anykeyContinue);
        }
        internal static void CenterText(string Text) 
        {
            int leftPadding = (Console.WindowWidth - Text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(Text);
        }
        internal static void CenterPrompt(string Text)
        {
            int leftPadding = (Console.WindowWidth - Text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.Write(Text);
        }

    }
}
