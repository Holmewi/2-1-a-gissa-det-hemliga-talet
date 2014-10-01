using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;
        private int _count;
        private int _number;

        public const int MinValue = 1;
        public const int MaxValue = 100;


        // Tilldelar _count värdet 0 och ett slumpmässigt tal mellan 1 och 100 till _number
        public void Initialize()
        {
            _count = 0;
            Random randomNumber = new Random();
            _number = randomNumber.Next(MinValue, MaxValue + 1);
        }

        public bool MakeGuess(int guessedNumber)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (guessedNumber < 1 || guessedNumber > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Tog ett tag innan jag insåg att jag själv var tvungen att öka världet på _count vid varje gissning.
            _count++;

            if (guessedNumber == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count);
                return true;
            }   

            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
                return false;
            }   
            if (guessedNumber < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", guessedNumber, (MaxNumberOfGuesses - _count));
                return false;  
            }

            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", guessedNumber, (MaxNumberOfGuesses - _count));
                return false;
            }
    
        }

        // Konstruktorn som skickar ut värderna som initieras i methoden med samma namn
        public SecretNumber()
        {
            Initialize();
        }

    }
}
