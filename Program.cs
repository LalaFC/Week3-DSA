using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Week3_DSA
{
    internal class Program
    {
        static void Main(string[] args) //Main Program
        {
            Login.LoginScreen();
        }


    }

    internal class Login
    {
        internal static void LoginScreen()
        {
            Console.Clear();
            Prompts.ContinueKey();

            Console.Clear();
            Menu Menu = new(); //Create new Menu instance

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
                    Console.Write(3 - loginAttempts + " attempts left. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (loginAttempts >= 3) //If exceeded 3 wrong attempts, Exit Program
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
}