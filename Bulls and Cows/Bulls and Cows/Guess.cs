using System;
namespace Bulls_and_Cows
{
    internal class Guess
    {
        const int k_SizeOfWord = 4;
        char[] m_MyGuess;
        int m_NumberOfbulls;
        int m_NumberOfCows;

        public Guess()
        {
            this.m_MyGuess = new char[k_SizeOfWord];
            this.m_NumberOfbulls = 0;
            this.m_NumberOfCows = 0;  
        }
        public string MyGuess
        {
            set
            {
                for (int i = 0; i < k_SizeOfWord; i++)
                {
                    m_MyGuess[i] = value[i];
                }
            }
            get
            {
                return new string(m_MyGuess);
            }
        }

        public int Cows
        {
            get
            {
                return m_NumberOfCows;
            }
            set
            {
                m_NumberOfCows = value;
            }
        }

        public int Bulls
        {
            get
            {
                return m_NumberOfbulls;
            }
            set
            {
                m_NumberOfbulls = value;
            }
        }

        public int InputGuess()
        {
            char letter;
            for (int i = 0; i < k_SizeOfWord; i++)
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
                    m_MyGuess[i] = letter;
                }
            }
            return 2;
        }

        public bool CheckGuess(ref char[] i_WordOfComputer)
        {
            for (int indexGuessFromPlayer = 0; indexGuessFromPlayer < k_SizeOfWord; indexGuessFromPlayer++)
            {
                for (int indexWordOfComputer = 0; indexWordOfComputer < k_SizeOfWord; indexWordOfComputer++)
                {
                    if (m_MyGuess[indexGuessFromPlayer] == i_WordOfComputer[indexWordOfComputer])
                    {
                        if (indexGuessFromPlayer == indexWordOfComputer)
                        {
                            m_NumberOfbulls++;
                        }
                        else
                        {
                            m_NumberOfCows++;
                        }
                    }
                }
            }

            if(m_NumberOfbulls == k_SizeOfWord)
            {
                return true;
            }
            return false;   
        }

        public string PrintResult()
        {
            char[] result = new char[k_SizeOfWord];
            int index = 0;
            for (int i = 0; i < m_NumberOfbulls; i++, index++)
            {
                result[index] = 'V';
            }
            for (int i = 0; i < m_NumberOfCows; i++, index++)
            {
                result[index] = 'X';
            }
            for (int i = 0; index < (k_SizeOfWord - m_NumberOfbulls - m_NumberOfCows) ; i++,index++)
            {
                result[index] = ' ';
            }
            return new string(result);
        }
    }
}
