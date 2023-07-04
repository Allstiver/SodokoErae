using System;

namespace ConsoleSudokoo
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 0;
            do
            {
                Console.Write("Choose an option:   (1.new-game / 2.exit) : ");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Random rnd = new Random();
                    int[][] board = new int[9][];
                    for (int i = 0; i < 9; i++)
                    {
                        board[i] = new int[9];
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (checkindex(i, j))
                            {
                                board[i][j] = 0;
                            }
                            else
                            {
                                bool ex = false;
                                do
                                {
                                    for (int k = 0; k < 9; k++)
                                    {
                                        if (k != j && board[i][k] == board[i][j])
                                            ex = true;
                                    }
                                    for (int k = 0; k < 9; k++)
                                    {
                                        if (k != i && board[k][j] == board[i][j])
                                            ex = true;
                                    }
                                    if (ex)
                                    {
                                        ex = false;
                                        board[i][j] = rnd.Next(1, 9);
                                    }
                                    else
                                        ex = true;
                                } while (!ex);
                            }
                        }
                    }
                    printsudoku(board);
                    Console.WriteLine();
                    while (checkwin(board) == false)
                    {
                        int x, y;
                        int value;
                        Console.Write("Enter X Y Value : ");
                        string ip = Console.ReadLine();
                        string[] datasplit = ip.Split();
                        if (datasplit.Length == 3)
                        {
                            x = int.Parse(datasplit[0]);
                            y = int.Parse(datasplit[1]);
                            value = int.Parse(datasplit[2]);
                            if (checkindex(x, y))
                                solvesudoku(board, x, y, value);
                        }
                        Console.Clear();
                        printsudoku(board);
                    }
                    Console.WriteLine();
                    Console.WriteLine("You Solved Sudoku");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("would you like to quit or not?   (1.Yes / 2.No) : ");
                    h = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("good bay");
                }
                Console.Clear();
            } while (h != 1);
        }

        static void printsudoku(int[][] arr)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
            Console.Write("|   |");
            for (int i = 0; i < 9; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" {0}", i);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" |");
            }
            Console.WriteLine();
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
            for (int i = 0; i < 9; i++)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" {0}", i);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" |");
                for (int j = 0; j < 9; j++)
                {
                    if (arr[i][j] != 0)
                    {
                        bool ex = false;
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != j && arr[i][k] == arr[i][j])
                                ex = true;
                        }
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != i && arr[k][j] == arr[i][j])
                                ex = true;
                        }
                        if (ex)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (checkindex(i, j) == false)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" {0} ", arr[i][j]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static bool checkindex(int x, int y)
        {
            if ((x == 0 && (y == 0 || y == 1)) ||
                (x == 1 && (y == 3 || y == 8)) ||
                (x == 2 && (y == 4 || y == 6)) ||
                (x == 3 && (y == 1 || y == 8)) ||
                (x == 4 && (y == 3 || y == 4)) || 
                (x == 5 && (y == 2 || y == 6)) ||
                (x == 6 && (y == 0 || y == 5)) || 
                (x == 7 && y == 7) || 
                (x == 8 && (y == 2 || y == 5)))
                return false;
            return true;
        }
        static void solvesudoku(int[][] arr, int x, int y, int value)
        {
            if (value <= 9 & value >= 0)
            {
                arr[x][y] = value;
            }
        }
        static bool checkwin(int[][] arr)
        {
            bool ex = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (arr[i][j] == 0)
                        ex = false;
                }
            }
            if (ex)
            {
                ex = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != j && arr[i][k] == arr[i][j])
                                ex = true;
                        }
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != i && arr[k][j] == arr[i][j])
                                ex = true;
                        }
                    }
                }
                if (ex == false)
                    return true;
            }
            return false;
        }
    }
}
