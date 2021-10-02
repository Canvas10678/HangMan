using System;
using System.Collections.Generic;
using System.Text;

enum Menu { PlayGame = 1, Exit } // ใช้ตอนเลือกเมนู

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHead();
        }
        static void PrintHead() 
        {
            Console.WriteLine("Welcome to Hangman"); //เข้าหน้าเกม
            Console.WriteLine("-------------------");
            PrintMenuInputMenuFormKeyborad();
        }
        static void PrintMenuInputMenuFormKeyborad() //เมนูเล่นเกม
        {
            Console.WriteLine("1. Playgame");
            Console.WriteLine("2. Exit");
            Console.Write("Please select Menu : ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu) //เงื่อนไข
        {
            if (menu == Menu.PlayGame)
            {
                Play_HangMan();
            }
            else if (menu == Menu.Exit)
            {
                Console.ReadLine();
            }
        }
        static void Play_HangMan() //ตัวเกม
        {
            Console.Clear();
            string[] Vocabulary = new string[3];
            Vocabulary[0] = "tennis";
            Vocabulary[1] = "football";
            Vocabulary[2] = "badminton";
            Random random = new Random();
            int resultRandom = random.Next(0, 2);
            string puzzle = Vocabulary[resultRandom];

            StringBuilder displayToPlayer = new StringBuilder(puzzle.Length);

            int underscore = puzzle.Length;
            int Incorrect = 0;
            List<char> CorrectGuesses = new List<char>();
            List<char> IncorrectGuesses = new List<char>();

            int ScoreHeart = 6;
            bool Win = false;
            int LetterCorrect = 0;

            string Letter;
            char NumberCount;

            PlayHangMan(); 
            Console.WriteLine("Incorrect score : " + Incorrect);

            for (int i = 0; i < underscore; i++)
            { 
                Console.Write("_");
            }

            for (int i = 0; i < puzzle.Length; i++) 
            {
                displayToPlayer.Append('_');
            }
             
            while (!Win && ScoreHeart > 0)
            {
                Console.Write("\nInput letter alphabet: ");

                Letter = Console.ReadLine();
                NumberCount = Letter[0];


                if (puzzle.Contains(NumberCount))
                {
                    CorrectGuesses.Add(NumberCount);

                    for (int i = 0; i < puzzle.Length; i++)
                    {
                        if (puzzle[i] == NumberCount)
                        {
                            displayToPlayer[i] = puzzle[i];
                            LetterCorrect++;
                        }
                    }

                    if (LetterCorrect == puzzle.Length)
                        Win = true;
                }
                else
                {
                    IncorrectGuesses.Add(NumberCount);
                    Incorrect++;
                    ScoreHeart--;
                    PlayHangMan();
                    Console.WriteLine("Incorrect score : " + Incorrect);
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (Win)
                Console.WriteLine("You win!!");
            else
                Console.WriteLine("Game Over");

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();

        }
        static void PlayHangMan()
        {
            Console.Clear();
            Console.WriteLine("PlayGameHangman");
            Console.WriteLine("----------------------------------------");

        }
    }
}
        
       