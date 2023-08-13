using System;
using System.Linq;
using Ex02.ConsoleUtils;

namespace Bulls_and_Cows
{
    internal class Program
    {
        public static void  Start()
        {
            int numberGuesses;
            int sizeOfWord = 4;
            Guess[] arrayOfGuesses = null;
            char[] wordOfComputer = new char[sizeOfWord];

            do
            {
                InitializingWordOfComputer(ref wordOfComputer, sizeOfWord);

                numberGuesses = InitializingNumberGuesses();

                InitializingGuessArray(ref arrayOfGuesses, numberGuesses);

                RunningGame(ref arrayOfGuesses, ref wordOfComputer, numberGuesses);

            } while (!QuitGame());
        }
        public static bool QuitGame()
        {
            char answer; 
            do
            {
                Console.WriteLine(@"
Would you like to start a new game? (Y/N)");
                answer = Console.ReadKey().KeyChar;

                if (answer == 'Y')
                {
                    return false;
                }
                else if (answer == 'N')
                {
                    return true;
                }

            } while (true);
        }
        public static void RunningGame(ref Guess[] io_ArrayOfGuesses, ref char[] i_WordOfComputer, int i_NumberGuesses)
        {
            string message;
            for (int step = 0; step < i_NumberGuesses; step++)
            {
                PrintBoard(ref io_ArrayOfGuesses, i_NumberGuesses);
                Console.WriteLine("Please type your next guess or 'Q' to quit");
                input:
                switch (io_ArrayOfGuesses[step].InputGuess())
                {
                    case 0:
                        Console.WriteLine(@"
Bye Bye");
                        Environment.Exit(0);
                        return;
                    case 1:
                        Console.WriteLine(@"
Invalid input.
Please enter a word containing the letters A - H");
                        goto input;
                    default:
                        break;
                }
                if (io_ArrayOfGuesses[step].CheckGuess(ref i_WordOfComputer))
                {
                    Screen.Clear();
                    PrintBoard(ref io_ArrayOfGuesses, i_NumberGuesses);
                    message = string.Format("You guessed after {0} steps!", step + 1);
                    Console.WriteLine(message);
                    return;
                }
                Screen.Clear();
            }
            Screen.Clear();
            PrintBoard(ref io_ArrayOfGuesses, i_NumberGuesses);
            Console.WriteLine("No more guesses allowed.");
            return;
        }
        public static int InitializingNumberGuesses()
        {
            int numberGuesses = 0;
            bool validNumberOfAttempts = true;
            do
            {
                Console.WriteLine("Please enter the number of guess attempts (between 4 and 10 attempts)");
                numberGuesses = int.Parse(Console.ReadLine());

                if (numberGuesses < 4 || numberGuesses > 10)
                {
                    validNumberOfAttempts = false;
                }

            } while (!validNumberOfAttempts);

            numberGuesses++;
            return numberGuesses;
        }
        public static void InitializingWordOfComputer(ref char[] o_WordOfComputer, int i_SizeOfWord)
        {
            Random random = new Random();
            int letter;
            for (int i = 0; i < i_SizeOfWord; i++)
            {
                letter = random.Next(65, 73);
                if (o_WordOfComputer.Contains((char)letter))
                {
                    i--;
                }
                else
                {
                    o_WordOfComputer[i] = (char)letter;
                } 
            }
        }
        public static void InitializingGuessArray(ref Guess[] o_ArrayOfGuesses, int i_NumberGuesses)
        {
            o_ArrayOfGuesses = new Guess[i_NumberGuesses];

            o_ArrayOfGuesses[0] = new Guess();
            o_ArrayOfGuesses[0].MyGuess = "####";

            for (int i = 1; i < i_NumberGuesses; i++)
            {
                o_ArrayOfGuesses[i] = new Guess();
            }
        }
        public static void PrintBoard(ref Guess[] i_ArrayOfGuess, int i_SizeOfAttempts)
        {
            string printLineInChart; 
            string line = "|=======|========|";
            Console.WriteLine("Current status board:");
            printLineInChart = string.Format("|Pins:\t|Results:|\n{0}",line);
            Console.WriteLine(printLineInChart);
           
            for (int i = 0; i < i_SizeOfAttempts; i++)
            {
                if (i_ArrayOfGuess[i].MyGuess != "\0\0\0\0")
                {
                    printLineInChart = String.Format("|{0}\t|{1}\t |\n{2}", i_ArrayOfGuess[i].MyGuess, i_ArrayOfGuess[i].PrintResult(),line);

                }
                else
                {
                    printLineInChart = String.Format("|\t|\t |\n{0}", line);
                }
                Console.WriteLine(printLineInChart);
            }
        }
        public static void Main()
        {
            Start();
        }
    }
}
