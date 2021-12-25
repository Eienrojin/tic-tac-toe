char[,] playField =
{
    { '#', '#', '#' },
    { '#', '#', '#' },
    { '#', '#', '#' }
};
bool isPlaysCross = false;
bool isGameOver = false;

int heigth = playField.GetLength(0);
int weigth = playField.GetLength(1);

//Вся логика начинается отсюда
MainMenu();

for (;;)
{
    DefalthField();
    PrintField();
    InitNum();
    VictoryLogic();

    if (isGameOver == true)
    {
        Console.Clear();
        MainMenu();
        DefalthField();
    }
}
//И заканчивается здесь

void MainMenu()
{
    for (; ; )
    {
        isGameOver = false;
        int menuChoice = 0;
        string menuTitle = @"  _______         ______              ______         
 /_  __(_)____   /_  __/___ ______   /_  __/___  ___ 
  / / / / ___/    / / / __ `/ ___/    / / / __ \/ _ \
 / / / / /__     / / / /_/ / /__     / / / /_/ /  __/
/_/ /_/\___/    /_/  \__,_/\___/    /_/  \____/\___/ 
                                                     ";

        Console.Write(menuTitle);
        Console.WriteLine("\n");

        Console.WriteLine("Добро пожаловать в крестики нолики!" + "\n1. Начать игру" + "\n2. Выйти из игры");
        menuChoice = int.Parse(Console.ReadLine());

        if (menuChoice == 1)
        {
            Console.Clear();
            break;
        }

        if (menuChoice == 2)
            Environment.Exit(0);
    }


}
void DefalthField()
{
    char[,] playField =
    {
    { '#', '#', '#' },
    { '#', '#', '#' },
    { '#', '#', '#' }
    };
}
void PrintField()
{
    Console.Clear();
    Console.Write($" \t");

    for (int i = 0; i <= 2; i++)
    {
        Console.Write($"{i}\t");
    }
    Console.WriteLine();

    for (int i = 0; i < heigth; i++)
    {
        Console.Write($"{i}\t");
        for (int j = 0; j < weigth; j++)
        {
            Console.Write($"{playField[i, j]}\t");
        }
        Console.WriteLine("\n\n\n");
    }
}
void InitNum()
{
    if (isPlaysCross == true)
    {
        Console.WriteLine("Сейчас ход крестиков");
    }
    else
    {
        Console.WriteLine("Сейчас ход ноликов");
    }

    int y = -1; 
    int x = -1;

    for (; ; )
    {
        try
        {
            Console.Write("Введите столб: ");
            y = int.Parse(Console.ReadLine());
            Console.Write("Введите строку: ");
            x = int.Parse(Console.ReadLine());
        } catch (FormatException)
        {
            Console.WriteLine("Не правильная расстановка, повторите ещё раз.");
        }
        if (y > 2 || x > 2 || y < 0 || x < 0)
        {
            Console.WriteLine("Не правильная расстановка, повторите ещё раз.");
        }
        else
        {
            break;
        }
    }


    if (isPlaysCross == true)
    {
        playField[y, x] = 'X';
        isPlaysCross = false;
    }
    else
    {
        playField[y, x] = 'O';
        isPlaysCross = true;
    }
}
void VictoryLogic()
{
    int charZeroCounter = 0;
    int charCrossCounter = 0;

    for (int i = 0; i < heigth; i++)
    {
        //Логика вычисления победы для строк
        for (int j = 0; j < weigth; j++)
        {
            //Сброс очков при переходе на следующую строку
            charZeroCounter = 0;
            charCrossCounter = 0;

            if (playField[i, j] == 'O')
            {
                charZeroCounter++;
            }
            else
            {
                charZeroCounter = 0;
            }

            if (playField[i, j] == 'X')
            {
                charCrossCounter++;
            }
            else
            {
                charCrossCounter = 0;
            }
        }

        //Логика вычисления победы для столбцов
        for (int j = 0; j < weigth; j++)
        {
            if (playField[j, i] == 'O')
            {
                charZeroCounter++;
            }
            else
            {
                charZeroCounter = 0;
            }

            if (playField[j, i] == 'X')
            {
                charCrossCounter++;
            }
            else
            {
                charCrossCounter = 0;
            }

            if (charZeroCounter == 3)
            {
                VictoryMessage("Zero");
            }
            if (charCrossCounter == 3)
            {
                VictoryMessage("Cross");
            }
        }

        if (charZeroCounter == 3)
        {
            VictoryMessage("Zero");
        }
        if (charCrossCounter == 3)
        {
            VictoryMessage("Cross");
        }
    }

    //Логика вычисления победы по диагонали
    //Проверка ноликов
    if (playField[0, 0] == 'O' & playField[1, 1] == 'O' & playField[2, 2] == 'O')
    {
        VictoryMessage("Zero");
    }
    if (playField[2, 0] == 'O' & playField[1, 1] == 'O' & playField[0, 2] == 'O')
    {
        VictoryMessage("Zero");
    }
    //Проверка крестиков
    if (playField[0, 0] == 'X' & playField[1, 1] == 'X' & playField[2, 2] == 'X')
    {
        VictoryMessage("Zero");
    }
    if (playField[2, 0] == 'X' & playField[1, 1] == 'X' & playField[0, 2] == 'X')
    {
        VictoryMessage("Zero");
    }
}
void VictoryMessage(string player)
{
    if (player == "Zero")
    {
        Console.WriteLine("Нолики победили!" + "\nНажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
        isGameOver = true;
    }
    if (player == "Cross")
    {
        Console.WriteLine("Крестики победили!" + "\nНажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
        isGameOver = true;
    }
}