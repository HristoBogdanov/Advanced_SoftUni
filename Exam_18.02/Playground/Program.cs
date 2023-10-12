using System;

class MainClass
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int moves = 0;
        int opponentsTouched = 0;
        char[,] playground = new char[n, m];
        int playerRow = 0;
        int playerCol = 0;

        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                char current = row[j][0];
                playground[i, j] = current;
                if (current == 'B')
                {
                    playerRow = i;
                    playerCol = j;
                }
            }
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "Finish")
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {moves}");
                break;
            }

            int newRow = playerRow;
            int newCol = playerCol;
            switch (command)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
            }

            if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= m)
            {
                continue;
            }

            char newPosition = playground[newRow, newCol];
            if (newPosition == 'O')
            {
                continue;
            }

            moves++;

            if (newPosition == 'P')
            {
                opponentsTouched++;
                playground[newRow, newCol] = '-';
            }

            playerRow = newRow;
            playerCol = newCol;

            if (opponentsTouched == 3)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {moves}");
                break;
            }
        }
    }
}