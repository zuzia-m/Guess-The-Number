using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            AppInfo();

            bool correctLanguage = false;

            while (!correctLanguage)
            {
                string language = ChooseLanguage();

                #region language PL
                if (language == "pl")
                {
                    correctLanguage = true;
                    string username = GetUserName("Jak masz na imię? : ");
                    GreetUserPL(username);
                    Random rand = new Random();

                    bool correctAnswer = false;
                    bool play = true;
                    while (play)
                    {
                        int correctNumber = rand.Next(1, 11);
                        play = false;
                        correctAnswer = false;
                        Console.WriteLine("\nZgadnij wylosowaną liczbę z przedziału 1 - 10: ");
                        int count = 0;
                        while (!correctAnswer)
                        {
                            string input = Console.ReadLine();
                            int guess;
                            bool isNumber = int.TryParse(input, out guess);

                            if (!isNumber)
                            {
                                WritelineColorText(ConsoleColor.Yellow, "Wprowadzony tekst musi być liczbą z przedziału 1 - 10. Spróbuj ponownie: ");
                                continue;
                            }
                            if (guess < 1 || guess > 10)
                            {
                                WritelineColorText(ConsoleColor.Yellow, "Wprowadzony tekst musi być liczbą z przedziału 1 - 10. Spróbuj ponownie: ");
                                continue;
                            }

                            if (guess < correctNumber)
                            {
                                count++;
                                WritelineColorText(ConsoleColor.Red, "Błędna odpowiedź, wylosowana liczba jest większa! Spróbuj ponownie:");
                            }
                            else if (guess > correctNumber)
                            {
                                count++;
                                WritelineColorText(ConsoleColor.Red, "Błędna odpowiedź, wylosowana liczba jest mniejsza! Spróbuj ponownie:");
                            }
                            else
                            {
                                count++;
                                WritelineColorText(ConsoleColor.Green, $"Brawo, udzieliłeś prawidłowej odpowiedzi! Udało Ci się za {count} razem.\n\n");
                                correctAnswer = true;
                                play = IfPlayAgain(play, "Naciśniij 'y' żeby zagrać ponownie. Naciśnij inny dowolny klawisz aby zakończyć grę.", "Po naciśnięciu dowolnego klawisza nastąpi zamknięcie gry. Do zobaczenia następnym razem!");
                            }
                        }
                    }
                    break;
                }
                #endregion

                #region language EN
                if (language == "en")
                {
                    correctLanguage = true;
                    string username = GetUserName("What's your name? : ");
                    GreetUserEN(username);
                    Random rand = new Random();

                    bool correctAnswer = false;
                    bool play = true;
                    while (play)
                    {
                        int correctNumber = rand.Next(1, 11);
                        play = false;
                        correctAnswer = false;
                        Console.WriteLine("\nGuess the number from 1 - 10: ");
                        int count = 0;
                        while (!correctAnswer)
                        {
                            string input = Console.ReadLine();
                            int guess;
                            bool isNumber = int.TryParse(input, out guess);

                            if (!isNumber)
                            {
                                WritelineColorText(ConsoleColor.Yellow, "You have to type the number from 1 - 10. Try again:");
                                continue;
                            }
                            if (guess < 1 || guess > 10)
                            {
                                WritelineColorText(ConsoleColor.Yellow, "You have to type the number from 1 - 10. Try again:");
                                continue;
                            }

                            if (guess < correctNumber)
                            {
                                count++;
                                WritelineColorText(ConsoleColor.Red, "Wrong answer, the number drawn is larger! Try again:");
                            }
                            else if (guess > correctNumber)
                            {
                                count++;
                                WritelineColorText(ConsoleColor.Red, "Wrong answer, the number drawn is lower! Try again:");
                            }
                            else
                            {
                                count++;
                                string numerator = "";
                                if (count == 1)
                                    numerator = "st";
                                else if (count == 2)
                                    numerator = "nd";
                                else if (count == 3)
                                    numerator = "rd";
                                else
                                    numerator = "th";
                                WritelineColorText(ConsoleColor.Green, $"Bravo, you gave the correct answer! You guessed on the {count}{numerator} try.\n\n");
                                correctAnswer = true;
                                play = IfPlayAgain(play, "Press 'y' to play again. Press any other key to leave the game.", "After pressing any key the app will close. See you next time!");
                            }
                        }
                    }
                    break;
                }
                #endregion

                #region Wrong Language
                if (language != "en" || language != "pl")
                {
                    WritelineColorText(ConsoleColor.DarkRed, $"\nThe language of the game has not been selected correctly.\nNiepoprawnie wybrano język gry.\n");
                    correctLanguage = false;
                }
                #endregion
            }
            Console.ReadKey();
        }

        #region Methods
        private static bool IfPlayAgain(bool play, string text1, string text2)
        {
            Console.WriteLine(text1);
            string playAgain = Console.ReadLine().ToLower();
            Console.WriteLine("________________________________________________________________________________");
            if (playAgain == "y")
                play = true;
            if (playAgain != "y")
            {
                play = false;
                WritelineColorText(ConsoleColor.DarkYellow, text2);
            }
            return play;
        }

        private static string ChooseLanguage()
        {
            Console.Write($"Please choose the language. For english type 'en'.\nProszę wybrać język. Dla polskiego wpisz 'pl'.\n");
            string language = Console.ReadLine().ToLower();
            return language;
        }

        private static void AppInfo()
        {
            string text = $"Console Game 'Guess the Number' \nCreated by: Zuzia M.";
            WritelineColorText(ConsoleColor.Magenta, text);
            Console.WriteLine();
        }

        private static string GetUserName(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{text}");
            Console.ResetColor();
            string username = Console.ReadLine();
            Console.WriteLine();
            return username;
        }

        private static void GreetUserPL(string username)
        {
            string text = $"Witaj, {username}! Zagrajmy w grę. Zasady są proste.\nMusisz zgadnąć liczbę.. A więc zacznijmy!";
            WritelineColorText(ConsoleColor.Blue, text);
        }
        private static void GreetUserEN(string username)
        {
            string text = $"Hello, {username}! Let's play the game. The rules are simple.\nYou have to guess the number. So let's start!";
            WritelineColorText(ConsoleColor.Blue, text);
        }
        static void WritelineColorText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        #endregion
    }
}
