namespace Matrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        private const byte PossibleDirections = 8;

        public static void Main()
        {
            Console.Write("Enter a matrix size in range [0-100]: ");
            int number = int.Parse(Console.ReadLine());
            while (number < 0 || number > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number. The number must be in range [0-100].");
                number = int.Parse(Console.ReadLine());
            }

            var matrix = BuildWalkInMatrix(number);

            PrintMatrix(matrix);
        }

        private static void ChangeDirection(ref int initialHorizontalDirection, ref int initialVerticalDirection)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] verticalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;
            for (int count = 0; count < PossibleDirections; count++)
            {
                if (horizontalDirections[count] == initialHorizontalDirection &&
                    verticalDirections[count] == initialVerticalDirection)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == PossibleDirections - 1)
            {
                initialHorizontalDirection = horizontalDirections[0];
                initialVerticalDirection = verticalDirections[0];
                return;
            }

            initialHorizontalDirection = horizontalDirections[currentDirection + 1];
            initialVerticalDirection = verticalDirections[currentDirection + 1];
        }

        private static bool CheckForAvailableDirections(int[,] matrix, int row, int column)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] verticalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < PossibleDirections; i++)
            {
                if (row + horizontalDirections[i] >= matrix.GetLength(0) || row + horizontalDirections[i] < 0)
                {
                    horizontalDirections[i] = 0;
                }

                if (column + verticalDirections[i] >= matrix.GetLength(0) || column + verticalDirections[i] < 0)
                {
                    verticalDirections[i] = 0;
                }
            }

            for (int i = 0; i < PossibleDirections; i++)
            {
                if (matrix[row + horizontalDirections[i], column + verticalDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNewStartingCell(int[,] matrix, out int row, out int column)
        {
            row = 0;
            column = 0;
            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < matrix.GetLength(0); currentColumn++)
                {
                    if (matrix[currentRow, currentColumn] == 0)
                    {
                        row = currentRow;
                        column = currentColumn;
                        return;
                    }
                }
            }
        }

        public static int[,] BuildWalkInMatrix(int number)
        {
            int matrixSize = number;
            int[,] matrix = new int[matrixSize, matrixSize];
            int currentNumber = 1;
            int maxNumber = matrixSize * matrixSize;
            int row = 0;
            int column = 0;
            int horizontalDirection = 1;
            int verticalDirection = 1;
            while (currentNumber <= maxNumber)
            {
                matrix[row, column] = currentNumber;
                if (!CheckForAvailableDirections(matrix, row, column))
                {
                    FindNewStartingCell(matrix, out row, out column);
                    currentNumber++;
                    horizontalDirection = 1;
                    verticalDirection = 1;
                    continue;
                }

                while (row + horizontalDirection >= matrixSize || row + horizontalDirection < 0 ||
                    column + verticalDirection >= matrixSize || column + verticalDirection < 0 ||
                    matrix[row + horizontalDirection, column + verticalDirection] != 0)
                {
                    ChangeDirection(ref horizontalDirection, ref verticalDirection);
                }

                row += horizontalDirection;
                column += verticalDirection;
                currentNumber++;
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            var matrixSize = matrix.GetLength(0);
            Console.WriteLine("Square matrix of {0} x {0} cells:", matrixSize);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int column = 0; column < matrixSize; column++)
                {
                    Console.Write("{0,4}", matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}