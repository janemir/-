using System;

class Program
{
    static char[,] board = new char[3, 3]; // Игровое поле 3x3
    static char currentPlayer = 'X'; // Текущий игрок

    static void Main(string[] args)
    {
        InitializeBoard(); // Инициализация игрового поля
        PlayGame();        // Начало игры
    }

    // Инициализация пустого игрового поля
    static void InitializeBoard() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                board[i, j] = ' '; // Все клетки изначально пустые
            }
        }
    }

    // Функция печати игрового поля
    static void PrintBoard() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--|---|--");
        }
    }

    // Проверка корректности хода (ветка Inputcorrectness)
    static bool IsValidMove(int row, int col) 
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ';
    }

    // Проверка наличия победителя (ветка Win)
    static bool CheckWin() 
    {
        // Проверка горизонталей и вертикалей
        for (int i = 0; i < 3; i++) 
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) return true;
        }

        // Проверка диагоналей
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer) return true;

        return false;
    }

    // Проверка на ничью (ветка Draw)
    static bool CheckDraw() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (board[i, j] == ' ') return false; // Если есть пустая клетка, это не ничья
            }
        }
        return true; // Все клетки заполнены
    }

    // Основная логика игры
    static void PlayGame() 
    {
        bool gameOver = false;

        while (!gameOver) 
        {
            PrintBoard(); // Вывод игрового поля
            int row, col;
            bool validMove = false;

            // Проверка корректного ввода (Inputcorrectness)
            while (!validMove) 
            {
                Console.WriteLine($"Ход игрока {currentPlayer}. Введите строку и столбец (0, 1 или 2):");
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());

                if (IsValidMove(row, col)) 
                {
                    board[row, col] = currentPlayer; // Игрок может сделать ход только в пустую клетку
                    validMove = true;

                    // Проверка на победу (ветка Win)
                    if (CheckWin()) 
                    {
                        PrintBoard();
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                        gameOver = true;
                    }

                     // Проверка на ничью (ветка Draw)
                    else if (CheckDraw()) 
                    {
                        PrintBoard();
                        Console.WriteLine("Ничья!");
                        gameOver = true;
                    }

                    else 
                    {
                        // Логика смены игрока (ветка Rules)
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    }

                } 
                else 
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                }
            }
            
        }
    }
}
