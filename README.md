# 🎯 Number Guessing Game in C#

A fun and interactive **Number Guessing Game** built in C#. The goal is to guess a randomly generated number within a chosen range. Players can choose between three difficulty levels, and the game will track the best scores for each player.

## 📌 Features

- ✅ **Random Number Generation** – The game picks a random number each round.
- ✅ **Difficulty Levels** – Choose between:
  - **Easy** (1-10)
  - **Medium** (1-50)
  - **Hard** (1-100)
- ✅ **Player Name Input** – Players are asked to enter their name before starting.
- ✅ **Score Tracking** – Displays the number of attempts taken to guess the number.
- ✅ **Leaderboard** – Saves best scores and attempts in a `leaderboard.txt` file.
- ✅ **Replay Option** – Players can replay without restarting the application.
- ✅ **Sorted Leaderboard** – Leaderboard shows the best scores (lowest attempts) first.

## 🚀 How to Play

1️⃣ **Run the game** in any C# environment (e.g., Visual Studio, .NET CLI).  
2️⃣ **Enter your name** when prompted.  
3️⃣ **Choose a difficulty level**:  
   - Easy (1-10)  
   - Medium (1-50)  
   - Hard (1-100)  
4️⃣ **Guess the number** based on hints:  
   - 📉 Too low! Try again.  
   - 📈 Too high! Try again.  
   - 🎉 When you guess it right, the number of attempts is recorded.  
5️⃣ **Replay** the game without restarting the program.

## 🛠 Installation & Setup

### **1. Clone the Repository**
```sh
git clone https://github.com/yourusername/NumberGuessingGame.git
cd NumberGuessingGame
dotnet run
