int[] array = new int[] {};

void OutputArr(int[] arr)
{
    foreach (var i in arr)
    {
        Console.Write(i);
        Console.Write(" ");
    }
    Console.Write("\n");
}

int Sum(int[] arr)
{
    int value = 0;
    foreach (var i in arr)
        value += i;

    return value;
}

int MaximumElement(int[] arr)
{
    int value = 0;
    foreach (var i in arr)
    {
        if (i > value)
            value = i;
    }
    
    return value;
}

int SecondMaximumElement(int[] arr)
{
    int value = 0, secondValue = 0;
    foreach (var i in arr)
    {
        if (i > value)
            value = i;
        if (i > secondValue && i != value)
            secondValue = i;
    }
    
    return secondValue;
}

int NumberUniqueElement(int[] arr)
{
    int number = 0;
    Dictionary<int, int> temp = new Dictionary<int, int>();

    foreach (var i in arr)
    {
        if (!temp.TryAdd(i, 1))
            temp[i]++;
    }

    foreach (var i in temp)
    {
        if (i.Value == 1)
            number++;
    }
    
    return number;
}

int FirstUniqueElement(int[] arr)
{
    int number = 0;
    Dictionary<int, int> temp = new Dictionary<int, int>();

    foreach (var i in arr)
    {
        if (!temp.TryAdd(i, 1))
            temp[i]++;
    }

    foreach (var i in temp)
    {
        if (i.Value == 1)
        {
            number = i.Key;
            break;
        }
    }
    
    return number;
}

void SwapMaxMinElement(ref int[] arr)
{
    int max = Int32.MinValue, min = Int32.MaxValue;
    int indexMax = 0, indexMin = 0;
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (max < arr[i])
        {
            max = arr[i];
            indexMax = i;
        } 
        if (min > arr[i])
        {
            min = arr[i];
            indexMin = i;
        }
    }

    arr[indexMin] = max;
    arr[indexMax] = min;
}

void SwapFirstLastElement(ref int[] arr)
{
    (arr[^1], arr[0]) = (arr[0], arr[^1]);
}

void SortAscending(ref int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
        for (int j = i; j != -1; j--)
            if (arr[i] < arr[j])
            { 
                (arr[i], arr[j]) = (arr[j], arr[i]);
                i--;
            }
}

void SortDescending(ref int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    for (int j = i; j != -1; j--)
        if (arr[i] > arr[j])
        { 
            (arr[i], arr[j]) = (arr[j], arr[i]);
            i--;
        }
}

void EvenOdd(ref int[] arr)
{
    List<int> list = new List<int>();
    foreach (var i in arr)
        if (i % 2 == 0)
            list.Add(i);
    
    foreach (var i in arr)
        if (i % 2 != 0)
            list.Add(i);
    
    list.CopyTo(arr);
}

void Menu()
{
    while (true)
    {
        OutputArr(array);
        Console.WriteLine("""
                          1.The sum of all the numbers.
                          2.The maximum element.
                          3.The second maximum element.
                          4.The number of unique element.
                          5.The first unique element.
                          6.Swap maximum and minimum elements.
                          7.Swap first and last elements.
                          8.Sort in ascending order.
                          9.Sort in descending order.
                          10.Move all the even elements of the array to the beginning, and the odd ones to the end.
                          11.Exit
                          """);
        var str = Console.ReadLine();
        Console.Clear();
        switch (str)
        {
            case "1":
                Console.Write("The sum of all the numbers: ");
                Console.WriteLine(Sum(array));
                break;
            case "2": 
                Console.Write("The maximum element: ");
                Console.WriteLine(MaximumElement(array));
                break;
            case "3": 
                Console.Write("The second maximum element: ");
                Console.WriteLine(SecondMaximumElement(array));
                break;
            case "4":
                Console.Write("The number of unique element: ");
                Console.WriteLine(NumberUniqueElement(array));
                break;
            case "5": 
                Console.Write("The first unique element: ");
                Console.WriteLine(FirstUniqueElement(array));
                break;
            case "6": 
                Console.WriteLine("New array: ");
                SwapMaxMinElement(ref array);
                break;
            case "7": 
                Console.WriteLine("New array: ");
                SwapFirstLastElement(ref array);
                break;
            case "8": 
                Console.WriteLine("Sort in ascending: ");
                SortAscending(ref array);
                break;
            case "9": 
                Console.WriteLine("Sort in descending: ");
                SortDescending(ref array);
                break;
            case "10": 
                Console.WriteLine("New array: ");
                EvenOdd(ref array);
                break;
            case "11": return;
            default: 
                Console.WriteLine("Incorrect value!");
                break;
        }
    }
}

int lengthInt;
while (true)
{ 
    Console.Write("Input length array: "); 
    var length = Console.ReadLine();
    try
    { 
        lengthInt = Convert.ToInt32(length);
        break;
    }
    catch
    {
        Console.Clear();
        Console.WriteLine("Incorrect value!");
    }
}

Array.Resize(ref array,  lengthInt);
var rand = new Random();
for (int i = 0; i < lengthInt; i++)
    array[i] = rand.Next(10);

Menu();
