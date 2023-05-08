public class MinStack
{
    private FixedStack<string> stack = new(n);
    private FixedStack<string> minstack = new(n);
    private static int n = 10;

    public MinStack(int length)
    {
        n = length;
    }
    public MinStack() : this(10) { }
    public int Count => stack.Count;

    public void Push(string item)
    {
        stack.Push(item);
        if (minstack.Count == 0 || item.Length.CompareTo(minstack.Peek().Length) <= 0)
            minstack.Push(item);
    }
    public string Pop()
    {
        string item = stack.Pop();
        if (item.Equals(minstack.Peek()))
            minstack.Pop();
        return item;
    }
    public string Peek() { return stack.Peek(); }
    public string GetMin()
    {
        if (minstack.Count == 0)
            throw new InvalidOperationException("Стек пуст");
        return minstack.Peek();
    }
}





