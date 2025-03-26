using System;
using System.IO;

class NumberGuessingGame
{
   static string leaderboardFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "leaderboard.txt");


    static void Main()
    {
        Console.WriteLine(" Welcome to the Number Guessing Game! ");

        bool playAgain = true;
        while (playAgain)
        {
            PlayGame();
            Console.Write("\nDo you want to play again? (y/n): ");
            playAgain = Console.ReadLine().Trim().ToLower() == "y";
        }

        Console.WriteLine("\n Leaderboard (Best Scores):");
        DisplayLeaderboard();
        Console.WriteLine("\nThanks for playing! 🎮");
    }

    static void PlayGame()
    {
        Console.Write("\n Enter your name: ");
        string playerName = Console.ReadLine()?.Trim();
        playerName = string.IsNullOrEmpty(playerName) ? "Anonymous" : playerName;

        int maxNumber = ChooseDifficulty();
        Random random = new Random();
        int secretNumber = random.Next(1, maxNumber + 1);
        int attempts = 0;
        int userGuess = 0;

        Console.WriteLine($"\n I've picked a number between 1 and {maxNumber}. Try to guess it!");

        while (true)
        {
            Console.Write("Enter your guess: ");
            if (!int.TryParse(Console.ReadLine(), out userGuess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;

            if (userGuess < secretNumber)
                Console.WriteLine(" Too low! Try again.");
            else if (userGuess > secretNumber)
                Console.WriteLine("Too high! Try again.");
            else
            {
                Console.WriteLine($" Congratulations, {playerName}! You guessed it in {attempts} attempts.");
                SaveScore(playerName, attempts);
                break;
            }
        }
    }

    static int ChooseDifficulty()
    {
        Console.WriteLine("\nChoose a difficulty level: \n1. Easy (1-10) \n2. Medium (1-50) \n3. Hard (1-100)");

        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
            {
                return choice switch
                {
                    2 => 50,
                    3 => 100,
                    _ => 10,
                };
            }
            Console.WriteLine(" Invalid input! Please enter 1, 2, or 3.");
        }
    }

    static void SaveScore(string playerName, int attempts)
    {
        try
        {
            // Ensure the directory exists
            string directory = Path.GetDirectoryName(leaderboardFile);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Append score to the leaderboard file
            File.AppendAllText(leaderboardFile, $"{playerName} - {attempts} attempts\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving score: {ex.Message}");
        }
    }


    static void DisplayLeaderboard()
    {
        if (!File.Exists(leaderboardFile))
        {
            Console.WriteLine("No scores recorded yet.");
            return;
        }

        string[] scores = File.ReadAllLines(leaderboardFile);

        if (scores.Length == 0)
        {
            Console.WriteLine("No scores recorded yet.");
            return;
        }

        Array.Sort(scores, (a, b) =>
        {
            int aAttempts = ExtractAttempts(a);
            int bAttempts = ExtractAttempts(b);
            return aAttempts.CompareTo(bAttempts);
        });

        foreach (string score in scores)
            Console.WriteLine($"⭐ {score}");
    }

    static int ExtractAttempts(string scoreLine)
    {
        string[] parts = scoreLine.Split('-');
        if (parts.Length < 2) return int.MaxValue;

        string attemptsPart = parts[1].Trim().Split(' ')[0];
        return int.TryParse(attemptsPart, out int attempts) ? attempts : int.MaxValue;
    }
}
