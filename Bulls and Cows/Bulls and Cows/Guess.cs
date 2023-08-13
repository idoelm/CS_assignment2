using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_Cows
{
    internal class Guess
    {
        const int sizeOfWord = 4;
        char[] myGuess;
        int numberOfbulls;
        int numberOfCows;

        public Guess()
        {
            this.myGuess = new char[sizeOfWord];
            this.numberOfbulls = 0;
            this.numberOfCows = 0;  
        }
        public string MyGuess
        {
            set
            {
                for (int i = 0; i < sizeOfWord; i++)
                {
                    myGuess[i] = value[i];
                }
            }
            get
            {
                return new string(myGuess);
            }
        }

        public int Cows
        {
            get
            {
                return numberOfCows;
            }
            set
            {
                numberOfCows = value;
            }
        }

        public int Bulls
        {
            get
            {
                return numberOfbulls;
            }
            set
            {
                numberOfbulls = value;
            }
        }

        public int InputGuess()
        {
            char letter;
            for (int i = 0; i < sizeOfWord; i++)
            {
                letter = Console.ReadKey().KeyChar;
                
                if (letter == 'Q')
                {

                    return 0;
                }
                else if (letter < 'A' || letter  > 'H')
                {
                    return 1;
                }
                else
                {
                    myGuess[i] = letter;
                }
            }

            return 2;
        }

        public bool CheckGuess(ref char[] i_WordOfComputer)
        {
            for (int indexGuessFromPlayer = 0; indexGuessFromPlayer < sizeOfWord; indexGuessFromPlayer++)
            {
                for (int indexWordOfComputer = 0; indexWordOfComputer < sizeOfWord; indexWordOfComputer++)
                {
                    //Console.WriteLine(myGuess[indexGuessFromPlayer] + "\t" + i_WordOfComputer[indexWordOfComputer]);
                    if (myGuess[indexGuessFromPlayer] == i_WordOfComputer[indexWordOfComputer])
                    {
                        if (indexGuessFromPlayer == indexWordOfComputer)
                        {
                            numberOfbulls++;
                        }
                        else
                        {
                            numberOfCows++;
                        }
                    }
                }
            }

            if( numberOfbulls == sizeOfWord)
            {
                return true;
            }

            return false;   
        }

        public string PrintResult()
        {
            char[] result = new char[sizeOfWord];
            int index = 0;
            for (int i = 0; i < numberOfbulls;i++, index++)
            {
                result[index] = 'V';
            }
            for (int i = 0; i < numberOfCows; i++, index++)
            {
                result[index] = 'X';
            }
            for (int i = 0; index < (sizeOfWord - numberOfbulls - numberOfCows) ; i++,index++)
            {
                result[index] = ' ';
            }

            return new string(result);
        }



    }
}
