namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MinesweeperMain
    {
        private static void Main()
        {
            const int MaxTurns = 35;
            string command = string.Empty;
            char[,] gameField = GenerateGameField();
            char[,] mines = GenerateMines();
            int pointsCounter = 0;
            bool isDead = false;
            byte winnersQuantity = 6;
            List<Ranking> winners = new List<Ranking>(winnersQuantity);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            bool isWiner = false;
            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play minesweeper Try your luck and guess the fields with no mine on them." +
                    "The command 'top' shows you the ranking, 'restart' starts new game, 'exit' end your game. Good luck!");
                    RevealGameField(gameField);
                    isNewGame = false;
                }

                Console.Write("Input row and column: ");
                command = Console.ReadLine().Trim();
                byte maxCommandLength = 3;
                if (command.Length >= maxCommandLength)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetRanking(winners);
                        break;
                    case "restart":
                        gameField = GenerateGameField();
                        mines = GenerateMines();
                        RevealGameField(gameField);
                        isDead = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                ChangeTurn(gameField, mines, row, column);
                                pointsCounter++;
                            }

                            if (MaxTurns == pointsCounter)
                            {
                                isWiner = true;
                            }
                            else
                            {
                                RevealGameField(gameField);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isDead)
                {
                    RevealGameField(mines);
                    Console.Write("\nHrrrrrr! You died like a hero with {0} points. Type your nickname: ", pointsCounter);
                    string nickname = Console.ReadLine();
                    Ranking currentScore = new Ranking(nickname, pointsCounter);
                    if (winners.Count < 5)
                    {
                        winners.Add(currentScore);
                    }
                    else
                    {
                        for (int currentWinner = 0; currentWinner < winners.Count; currentWinner++)
                        {
                            if (winners[currentWinner].Points < currentScore.Points)
                            {
                                winners.Insert(currentWinner, currentScore);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Ranking firstScore, Ranking secondScore) => secondScore.Player.CompareTo(firstScore.Player));
                    winners.Sort((Ranking firstScore, Ranking secondScore) => secondScore.Points.CompareTo(firstScore.Points));
                    GetRanking(winners);

                    gameField = GenerateGameField();
                    mines = GenerateMines();
                    pointsCounter = 0;
                    isDead = false;
                    isNewGame = true;
                }

                if (isWiner)
                {
                    Console.WriteLine("\nCongratulations! You have found 35 cells without shedding any blood!");
                    RevealGameField(mines);
                    Console.WriteLine("Type your name: ");
                    string name = Console.ReadLine();
                    Ranking points = new Ranking(name, pointsCounter);
                    winners.Add(points);
                    GetRanking(winners);
                    gameField = GenerateGameField();
                    mines = GenerateMines();
                    pointsCounter = 0;
                    isWiner = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void GetRanking(List<Ranking> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Player, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The ranking is empty!\n");
            }
        }

        private static void ChangeTurn(char[,] gameField, char[,] mines, int row, int column)
        {
            char surroundingMinesCounter = CountSurroundingMines(mines, row, column);
            mines[row, column] = surroundingMinesCounter;
            gameField[row, column] = surroundingMinesCounter;
        }

        private static void RevealGameField(char[,] board)
        {
            int fieldRows = board.GetLength(0);
            int fieldColumns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int currentRow = 0; currentRow < fieldRows; currentRow++)
            {
                Console.Write("{0} | ", currentRow);
                for (int currentColumn = 0; currentColumn < fieldColumns; currentColumn++)
                {
                    Console.Write(string.Format("{0} ", board[currentRow, currentColumn]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int currentRow = 0; currentRow < boardRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < boardColumns; currentColumn++)
                {
                    board[currentRow, currentColumn] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateMines()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] gameField = new char[fieldRows, fieldColumns];
            for (int currentRows = 0; currentRows < fieldRows; currentRows++)
            {
                for (int currentColumns = 0; currentColumns < fieldColumns; currentColumns++)
                {
                    gameField[currentRows, currentColumns] = '-';
                }
            }

            List<int> mines = new List<int>();
            byte numberOfMine = 15;
            while (mines.Count < numberOfMine)
            {
                Random random = new Random();
                int newMine = random.Next(50);
                if (!mines.Contains(newMine))
                {
                    mines.Add(newMine);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / fieldColumns;
                int row = mine % fieldColumns;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = fieldColumns;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static char CountSurroundingMines(char[,] gameField, int currentRow, int currentColumn)
        {
            int surroundingMinesCount = 0;
            int fieldRows = gameField.GetLength(0);
            int fieldColumns = gameField.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (gameField[currentRow - 1, currentColumn] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentRow + 1 < fieldRows)
            {
                if (gameField[currentRow + 1, currentColumn] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (gameField[currentRow, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentColumn + 1 < fieldColumns)
            {
                if (gameField[currentRow, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (gameField[currentRow - 1, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < fieldColumns))
            {
                if (gameField[currentRow - 1, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentColumn - 1 >= 0))
            {
                if (gameField[currentRow + 1, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentColumn + 1 < fieldColumns))
            {
                if (gameField[currentRow + 1, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            return char.Parse(surroundingMinesCount.ToString());
        }

        public class Ranking
        {
            private string name;
            private int points;

            public Ranking()
            {
            }

            public Ranking(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Player
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }
    }
}