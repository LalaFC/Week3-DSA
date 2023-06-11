using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Transactions;
using Week3_DSA;

namespace ConsoleApp2
{
    internal class Login
    {
        static void Main(string[] args) //Main Program
        {
            Menu Menu = new Menu(); //Create new Menu instance
            TransactionRecord record = new TransactionRecord();//Starts a New List of Transactions

            int loginAttempts = 0; //Initialize login attempts
            const string defaultUsername = "user"; //Sets default Username
            const string defaultPassword = "password"; //Sets default Password

            while (loginAttempts < 3) //Loop for 3 Attempts
            {
                Console.Write("Please enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();

                if (ValidateLogin(username, password, defaultUsername, defaultPassword)) //Checking if username and password is correct
                {
                    Console.WriteLine("Login successful!");
                    Menu.ShowMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                    loginAttempts++;
                    Console.Write(3 - loginAttempts + "attempts left. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            if (loginAttempts >= 3)
            {
                Console.WriteLine("Login attempts exceeded. Exiting the program.");
                return;
            }
        }
        private static bool ValidateLogin(string username, string password, string defaultUsername, string defaultPassword) //method fpor checking username and password
        {
            return username == defaultUsername && password == defaultPassword;
        }

    }

    /*
    public static class PrintExtensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            return new List<T>(array) { item }.ToArray();
        }
    }
    internal class DisplayReceipt
    {
        static void Print(Dictionary<string, int> order)
        {
            string folderLocation = @"C:\Users\MSI\Desktop\";
            string fileName = "receipt.txt";
            string fullPath = folderLocation + fileName;

            // An array of strings
            string[] receipt =
                {
                "**************************************",
                "                                      ",
                "          A2 Psych Ward Cafe          ",
                "           Official Receipt           ",
                "                                      ",
                "**************************************",
                "                                      "
             };
            var values = order.Values.ToArray();
            String.Join(", ", values);

            receipt = receipt.CopyTo(values).ToArray();
            //Add Other Strings Here

            File.WriteAllLines(fullPath, receipt);

            var fileToOpen = fullPath;
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileToOpen
            };

            process.Start();
            process.WaitForExit();
        }
    }*/
}