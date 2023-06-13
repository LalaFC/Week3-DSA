using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class Prompts
    {
        //List of Frequently used Strings
        internal const string Choice = "Enter your choice: ";
        internal const string Quantity = "Enter the quantity: ";
        internal const string anykeyContinue = "Press Any Key to Continue. ";
        internal const string invalidInput = "Please Enter Numbers Only. \n";
        internal const string OutOfChoice = "Not in the choices. Please Try Again \n";
        internal const string YesNo = "Please Enter a Valid Input. \n";

        //Outputs Formatted Press Key To Continue
        internal static void ContinueKey()
        {
            int leftPadding = (Console.WindowWidth - anykeyContinue.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.Write(anykeyContinue);
            Console.ReadKey();
        }
        //Method to Center Text (Console.WriteLine)
        internal static void CenterText(string Text) 
        {
            int leftPadding = (Console.WindowWidth - Text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(Text);
        }
        //Method to Center Prompt (Console.Write)
        internal static void CenterPrompt(string Text)
        {
            int leftPadding = (Console.WindowWidth - Text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.Write(Text);
        }

    }
}
