#pragma warning disable
// задание 1

//string path = @"..\..\..\data12.txt";
//var file = File.Create(path);
//file.Close();
//using (StreamWriter sw = new(path))
//{
//    sw.Write("привет\nмир\nкак дела?\nя люблю C#\n");
//}
//string[] lines = File.ReadAllLines(path);
//FixedStack<string> stack = new(lines.Length);
//foreach (string line in lines)
//{
//    stack.Push(line);
//}

//// а)
//Console.WriteLine("Содержимое стека:\n" + stack);

//// б)
//string shortest = null;
//int shortestIndex = -1;
//int shortestLength = int.MaxValue;
//int i = stack.Count - 1;
//while (stack.Count > 0)
//{
//    string current = stack.Pop();
//    if (current.Length < shortestLength)
//    {
//        shortest = current;
//        shortestIndex = i;
//        shortestLength = current.Length;
//    }
//    i--;
//}
//Console.WriteLine("Самая короткая строка: " + shortest);
//Console.WriteLine("Ее индекс: " + shortestIndex);
//Console.WriteLine("Длина строки: " + shortestLength);

//// в)
//MinStack stack1 = new(lines.Length);
//foreach (string line in lines)
//{
//    stack1.Push(line);
//}
//string min = stack1.GetMin();
//Console.WriteLine("Самая короткая строка: " + min);
//Console.WriteLine("Ее индекс: " + shortestIndex);
//Console.WriteLine("Длина строки: " + min.Length);

//// г)
//MinStackG<string> stack2 = new MinStackG<string>();
//foreach (string line in lines)
//{
//    stack2.Push(line);
//}
//string min2 = stack2.GetMin();
//Console.WriteLine("Самая короткая строка: " + min2);
//Console.WriteLine("Ее индекс: " + stack2.GetMinIndex());
//Console.WriteLine("Длина строки: " + min2.Length);


// 2 задание

//Console.WriteLine("Вводите строки");
//string input = Console.ReadLine();
//while (input != "")
//{
//    Console.WriteLine(CheckBrackets(input));
//    input = Console.ReadLine();
//}
//string CheckBrackets(string str)
//{
//    MinStack stack = new(str.Length);
//    MinStack indexes = new(str.Length);
//    for (int i = 0; i < str.Length; i++)
//    {
//        char c = str[i];
//        if (c == '(' | c == '[' | c == '{')
//        {
//            stack.Push(c.ToString());
//            indexes.Push((i + 1).ToString());
//        }
//        else if (c == ')' | c == ']' | c == '}')
//        {
//            if (stack.Count == 0)
//            {
//                return (i + 1).ToString();
//            }
//            string top = stack.Pop();
//            indexes.Pop();
//            if (c == ')' & top != "(" | c == ']' & top != "[" | c == '}' & top != "{")
//                return (i + 1).ToString();
//        }
//    }
//    if (stack.Count > 0)
//        return (indexes.Peek());
//    return "YES";
//}


// задание 3

// а1)
Console.WriteLine("Введите строку:");
string input = Console.ReadLine();
MyQueue queue = new();

for (int i = 0; i < input.Length; i++)
{
    char ch = input[i];
    if (ch >= 'A' & ch <= 'Z')
        queue.Enqueue(ch.ToString());
    else if (ch == '*')
        Console.Write(queue.Dequeue() + " ");
}
Console.WriteLine();

// а2)
Console.WriteLine("Введите строку:");
string input1 = Console.ReadLine();
Queue<char> queue1 = new();

for (int i = 0; i < input1.Length; i++)
{
    char ch = input1[i];
    if (ch >= 'A' & ch <= 'Z')
        queue1.Enqueue(ch);
    else if (ch == '*')
        Console.Write(queue1.Dequeue() + " ");
}
Console.WriteLine();

// б1)
MyQueue queue2 = new();
string path = @"..\..\..\data12.txt";
using (StreamWriter sw = new(path))
{
    sw.Write("привет\nмир\nкак дела?\nя люблю C#\nкак найти работу?\nда\nнет\nне знаю\n");
}
using (StreamReader sr = new StreamReader(path))
{
    string? line;
    while ((line = sr.ReadLine()) != null)
    {
        queue2.Enqueue(line);
    }
}

int max_index = 0;
for (int i = 1; i < queue2.Count; i++)
{
    if (queue2.ElementAt(i).Length > queue2.ElementAt(max_index).Length)
        max_index = i;
}

for (int i = 0; i < max_index; i++)
{
    string item = queue2.Dequeue();
    queue2.Enqueue(item);
}

while (!queue2.IsEmpty())
    Console.WriteLine(queue2.Dequeue());



