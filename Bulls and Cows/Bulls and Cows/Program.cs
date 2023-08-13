using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Bulls_and_Cows
{
    internal class Program
    {
        public static void InitializingWordOfComputer(ref char[] WordOfComputer, int i_sizeOfWord)
        {
            Random random = new Random();
            int letter;
            for (int i = 0; i < i_sizeOfWord; i++)
            {
                letter = random.Next(65, 73);
                if (WordOfComputer.Contains((char)letter))
                {
                    i--;
                }
                else
                {
                    WordOfComputer[i] = (char)letter;
                } 
            }
        }

            public static void InitializingGuessArray(ref Guess[] arrayOfGuesses, int i_numberGuesses)
        {
            arrayOfGuesses = new Guess[i_numberGuesses];

            arrayOfGuesses[0] = new Guess();
            arrayOfGuesses[0].MyGuess = "####";

            for (int i = 1; i < i_numberGuesses; i++)
            {
                arrayOfGuesses[i] = new Guess();
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
            int numberGuesses;
            int sizeOfWord = 4;
            Guess[] arrayOfGuesses = null;
            char[] wordOfComputer = new char[sizeOfWord];
            bool validNumberOfAttempts = true;
            string message;
            char answer;

            start:
            InitializingWordOfComputer(ref wordOfComputer, sizeOfWord);

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

            InitializingGuessArray(ref arrayOfGuesses, numberGuesses);

            for (int step = 0; step < numberGuesses; step++)
            {
                Console.WriteLine(wordOfComputer);

                PrintBoard(ref arrayOfGuesses, numberGuesses);
                Console.WriteLine("Please type your next guess or 'Q' to quit");
                input:
                switch (arrayOfGuesses[step].InputGuess())
                {
                    case 0:
                        Console.WriteLine("\nBye Bye");
                        goto end;
                    case 1:
                        Console.WriteLine("\nInvalid input.\nPlease enter a word containing the letters A - H");
                        goto input;
                    default:
                        break;
                }
                if(arrayOfGuesses[step].CheckGuess(ref wordOfComputer))
                {
                    Screen.Clear();
                    PrintBoard(ref arrayOfGuesses, numberGuesses);
                    message = string.Format("You guessed after {0} steps!", step+1);
                    Console.Write(message);

                    do
                    {
                        Console.WriteLine("\nWould you like to start a new game? (Y/N)");
                        answer = Console.ReadKey().KeyChar;

                        if (answer == 'Y')
                        {
                            goto start;
                        }
                        else if(answer == 'N')
                        {
                            goto end;
                        }

                    } while (true);
                   
                }
                Screen.Clear();
            }

            do
            {
                Console.WriteLine("No more guesses allowed.\nWould you like to start a new game? (Y/N)");
                answer = Console.ReadKey().KeyChar;

                if (answer == 'Y')
                {
                    goto start;
                }
                else if (answer == 'N')
                {
                    goto end;
                }

            } while (true);

        end:;
        }
    }
}
