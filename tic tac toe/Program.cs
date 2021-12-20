char[,] playField =
{
    { '#', '#', '#' },
    { '#', '#', '#' },
    { '#', '#', '#' }
};
bool isPlaysCross = false;

int heigth = playField.GetLength(0);
int weigth = playField.GetLength(1);

for (; ; )
{
    DefalthField();
    PrintField();
    InitNum();
    VictoryLogic();
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

    int y = 0; 
    int x = 0;

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
void VictoryMessage(string player)
{
    if (player == "Zero")
    {
        Console.WriteLine("Нолики победили!");
    }
    if (player == "Cross")
    {
        Console.WriteLine("Крестики победили!");
    }
}
void VictoryLogic()
{
    int charZeroCounter = 0;
    int charCrossCounter = 0;

    //Логика вычисления победы (здесь для строк)
    for (int i = 0; i < heigth; i++)
    {
        for (int j = 0; j < weigth; j++)
        {
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

            if (charZeroCounter == 3)
            {
                VictoryMessage("Zero");
            }
            if (charCrossCounter == 3)
            {
                VictoryMessage("Cross");
            }
        }

        //Логика вычисления победы для столбцов
        for (int j = 0; j < weigth; j++)
        {
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

            if (charZeroCounter == 3)
            {
                VictoryMessage("Zero");
            }
            if (charCrossCounter == 3)
            {
                VictoryMessage("Cross");
            }
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