using System.Runtime.InteropServices;

namespace Password_validator_from_flowchart
{
    internal class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Controller();
        }
        #endregion
        #region Controller
        static void Controller()
        {
            do
            {
                Console.ResetColor();
                Console.Clear();
                ConsoleKey key;
                key = Console.ReadKey(true).Key;
                int stage = 0;
                GUI(stage = 0);
                string passwordInput = Console.ReadLine();
                if (passwordInput == "")
                {
                    //show an error
                    GUI(stage = 1);
                    continue;
                }
                else if (CheckPasswordLength(passwordInput) == true && CheckIfContainsSpecial(passwordInput) == true && CheckIfMixOfLettersAndNumbers(passwordInput) == true && CheckIfMixOfUpperAndLowercase(passwordInput) == true)
                {
                    if (CheckIfFourConcecutiveCharacters(passwordInput) == true || CheckIfSequentialNumbers(passwordInput) == true)
                    {
                        GUI(stage = 2);
                        if(key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        GUI(stage = 3);
                        if (key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    GUI(stage = 4);
                    if (key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);
        }
        #endregion
        #region Model
        static void Model()
        {

        }
        #endregion
        #region GUI
        static void GUI(int stage)
        {
            if (stage == 0)
            {
                Console.WriteLine("Welcome to the password validator!");
                Console.WriteLine("Here you can check to see how secure your chosen password is");
                Console.WriteLine("Your password needs to be between 12 and 64 characters long (both included),");
                Console.WriteLine("have a mix of UPPER and lowercase letters,");
                Console.WriteLine("have a mix of letters and numbers,");
                Console.WriteLine("and have at least 1 special character.");
                Console.WriteLine();
                Console.WriteLine("If these rules are being followed then your password will be accepted,");
                Console.WriteLine("BUT if it has at least 4 consecutive numbers or letters (I.E AAAA, 4444, etc.),");
                Console.WriteLine("or if it has 4 sequential numbers (I.E 1234, 6789) then it will be accepted, but weak.");
                Console.WriteLine();
                Console.WriteLine("Input your chosen password now: ");
            }
            else if (stage == 1)
            {
                Console.WriteLine("You need to input a password!");
                Console.WriteLine("Press enter to try again!");
                Console.ReadLine();
            }
            else if (stage == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Your password has passed, but has been downgraded :|");
                Console.WriteLine("Press enter to try again, or any other key to exit.");
                Console.ReadLine();
            }
            else if (stage == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your password is strong! :)");
                Console.WriteLine("Press enter to try again, or any other key to exit.");
                Console.ReadLine();
            }
            else if (stage == 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your password is too weak. :(");
                Console.WriteLine("Press enter to try again, or any other key to exit.");
                Console.ReadLine();
            }
        }
        #endregion
        #region Utilities
        static bool CheckPasswordLength(string passwordInput)
        {
            bool length = false;
            if(passwordInput.Length >= 12 && passwordInput.Length <= 64)
            {
                length = true;
            }
            else
            {

            }
            if(length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckIfContainsSpecial(string passwordInput)
        {
            bool special = false;
            for(int i = 0; i < passwordInput.Length; i++)
            {
                if (Char.IsLetterOrDigit(passwordInput[i]) == false)
                {
                    special = true;
                }
            }
            if (special)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckIfMixOfLettersAndNumbers(string passwordInput)
        {
            bool foundLetter = false;
            bool foundNumber = false;
            for(int i = 0;i < passwordInput.Length;i++)
            {
                if (Char.IsLetter(passwordInput[i]))
                {
                    foundLetter = true;
                }
                else if (Char.IsNumber(passwordInput[i]))
                {
                    foundNumber = true;
                }
            }
            if(foundLetter && foundNumber) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckIfMixOfUpperAndLowercase(string passwordInput)
        {
            bool foundUpper = false;
            bool foundLower = false;
            for(int i = 0; i < passwordInput.Length; ++i)
            {
                if (Char.IsUpper(passwordInput[i])) 
                {
                    foundUpper = true; 
                }
                else if (Char.IsLower(passwordInput[i]))
                {
                    foundLower = true;
                }
            }
            if(foundUpper && foundLower)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static bool CheckIfFourConcecutiveCharacters(string passwordInput)
        {
            bool concecutive = false;
            for(int i = 0; i < passwordInput.Length - 3; i++)
            {
                if (passwordInput[i] == passwordInput[i + 1] && passwordInput[i + 1] == passwordInput[i + 2] && passwordInput[i + 2] == passwordInput[i + 3])
                {
                    concecutive = true;
                }
            }
            if(concecutive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckIfSequentialNumbers(string passwordInput)
        {
            bool sequential = false;
            for (int i = 0; i < passwordInput.Length - 3; i++)
            {
                if (passwordInput[i] == passwordInput[i+1] - 1 && passwordInput[i+1] == passwordInput[i+2] - 1 && passwordInput[i+2] == passwordInput[i+3] - 1)
                {
                    sequential = true;
                }
            }
            if (sequential)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}