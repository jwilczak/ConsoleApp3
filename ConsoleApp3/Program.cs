using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Program startAgain = new Program();
            bool gameLoop = true;
            while (gameLoop == true)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                string[] wordBank = { "Warsaw", "Berlin", "Moscow", "Paris", "Rome", "Seoul" };

                string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
                string wordToGuessUppercase = wordToGuess.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                for (int i = 0; i < wordToGuess.Length; i++)
                    displayToPlayer.Append('_');

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                int lives = 5;
                bool won = false;
                int lettersRevealed = 0;

                string input;
                string inputw;
                char guess;

                Console.WriteLine("Hello!");
                Console.WriteLine("This is Motorola Hangman Game");
                Console.WriteLine("");


                while (!won && lives > 0)
                {

                    Console.WriteLine("Your lives: " + lives);
                    Console.WriteLine("");
                    Console.WriteLine("Capitol: " + displayToPlayer);
                    Console.WriteLine("");
                    Console.Write("Please chose! [1] for guess a letter or [2] for guess a word: ");
                    Console.WriteLine("");
                    string playerDecision = Console.ReadLine();
                    if (playerDecision == "1")
                    {

                        Console.WriteLine("Guess a letter: ");
                        input = Console.ReadLine().ToUpper();
                        guess = input[0];

                        if (correctGuesses.Contains(guess))
                        {
                            Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                            continue;
                        }
                        else if (incorrectGuesses.Contains(guess))
                        {
                            Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                            continue;
                        }

                        if (wordToGuessUppercase.Contains(guess))
                        {
                            correctGuesses.Add(guess);

                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuessUppercase[i] == guess)
                                {
                                    displayToPlayer[i] = wordToGuess[i];
                                    lettersRevealed++;
                                }
                            }

                            if (lettersRevealed == wordToGuess.Length)
                                won = true;
                        }
                        else
                        {
                            incorrectGuesses.Add(guess);

                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                        }


                    }

                    else if (playerDecision == "2")

                    {

                        {
                            Console.WriteLine("Guess a word: ");
                            inputw = Console.ReadLine().ToUpper();
                            guess = inputw[0];

                            if (inputw == wordToGuess.ToUpper())
                            {
                                won = true;
                            }
                            else
                            {
                                Console.WriteLine("Nope, there's no " + inputw, "in it!", guess);
                                lives--;
                            }
                        }
                    }


                }

                if (won)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);

                Console.WriteLine("");
                Console.Write("Press [1] for play again or Press any button to exit ");
                Console.WriteLine("");
                string playAgain = Console.ReadLine();

                if (playAgain == "1")
                {
                    gameLoop=true;
                }
                else 
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bye Bye");
                    gameLoop = false;
                }
            }
        }


        
    }
    
}