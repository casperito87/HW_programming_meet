int WriteMsg(string msg)
{
    Console.Write(msg);
    string inputText = Console.ReadLine();
    int inputValue = Convert.ToInt32(inputText);
    return inputValue;
}

void PrintNto1(int ValueN)
{
    if (ValueN > 1)
    {
        Console.Write(ValueN + ", ");
        ValueN--;
        PrintNto1(ValueN);
    }
    else
    {
        Console.Write("1");
        return;
    }
}

int[] InputValues(string msg, string[] sepataror)
{
    Console.Write(msg);
    string inputText = Console.ReadLine();
    string[] Values = inputText.Split(sepataror, StringSplitOptions.None);
    int[] NumericValues = new int[3];
    int count = 0;
    foreach (var word in Values)
    {
        NumericValues[count] = Convert.ToInt32(word);
        count++;
    }
    NumericValues[2] = count;
    return NumericValues;
}


int[] DefineLargerNumber(int[] NumericValues)
{
    int tempValue = 0;
    if (NumericValues[0] > NumericValues[1])
    {
        tempValue = NumericValues[0];
        NumericValues[0] = NumericValues[1];
        NumericValues[1] = tempValue;
    }

    return NumericValues;
}

void SumBetweenValues(int[] Values, int sum)
{
    if (Values[2] > 2)
    {
        Console.WriteLine("Нужно было ввести только 2 числа!");
    }
    else
    {
        if (Values[0] <= Values[1])
        {
            sum += Values[0];
            Values[0]++;
            SumBetweenValues(Values, sum);
        }
        else
        {
            Console.WriteLine("Сумма элементов в промежутке между заданными числами равна " + sum);
            return;
        }
    }
}

bool CheckPositiveNumbers(int[] Values)
{
    if (Values[2] > 2)
    {
        Console.WriteLine("Нужно было ввести только 2 числа!");
        return false;
    }
    else
    {
        if (Values[0] < 0 || Values[1] < 0)
        {
            Console.WriteLine("Одно из введенных значений отрицательное! ");
            return false;
        }
        else
        {
            return true;
        }
    }
}

int AckermanFunction(int m, int n)
{
    if (m == 0)
        return n + 1;
    else
        if ((m != 0) && (n == 0))
        return AckermanFunction(m - 1, 1);
    else
        return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
}

//Решение задач
int NumberTask = WriteMsg("Введите номер задачи, которую хотите проверить: ");

switch (NumberTask)
{
    case 64:
        {
            int ValueN = WriteMsg("Задайте значение N и я выведу все натуральные числа в промежутке от N до 1: ");
            PrintNto1(ValueN);
            break;
        }

    case 66:
        {
            int[] array = InputValues("Введите через пробел или запятую 2 числа и я посчитаю сумму натуральных элементов в промежутке этих чисел: ", new string[] { ", ", " ", "," });
            int[] NumArray = DefineLargerNumber(array);
            SumBetweenValues(NumArray, 0);
            break;
        }

    case 68:
        {
            int[] array = InputValues("Введите 2 неотрицательных числа для вычисления функции Аккермана через зпт или пробел: ", new string[] { ", ", " ", "," });
            if (CheckPositiveNumbers(array))
            {
                int m = array[0];
                int n = array[1];
                int res = AckermanFunction(m, n);
                Console.WriteLine("А(m,n) = " + res);
            }
            break;
        }

    default:
        {
            Console.WriteLine("Тили-тили, трали-вали");
            Console.WriteLine("Это мы не проходили, это нам не задавали");
            Console.WriteLine("Па-рам-пам-пам, Па-рам-пам-пам...");
            break;
        }
}
