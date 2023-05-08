#pragma warning disable
class MinStackG<T> where T : IComparable<T>
{
    private Stack<T> _stack = new Stack<T>();
    private Stack<int> _minIndexStack = new Stack<int>();
    private int _minIndex = -1;
    private int _index = -1;

    public int Count => _stack.Count;

    public void Push(T item)
    {
        _index++;
        _stack.Push(item);
        if (typeof(T) == typeof(string))
        {
            if (_minIndex == -1 || item.ToString().Length <= _stack.ElementAt(Count - 1 - _minIndex).ToString().Length)
            {
                _minIndex = _index;
                _minIndexStack.Push(_minIndex);
            }
        }
        else
        {
            if (_minIndex == -1 || item.CompareTo(_stack.ElementAt(_minIndex)) < 0)
            {
                _minIndex = _index;
                _minIndexStack.Push(_minIndex);
            }
        }
    }

    public T Pop()
    {
        T item = _stack.Pop();
        _index--;
        if (_index < _minIndexStack.Peek())
        {
            _minIndexStack.Pop();
            _minIndex = _minIndexStack.Count > 0 ? _minIndexStack.Peek() : -1;
        }
        return item;
    }

    public T Peek()
    {
        return _stack.Peek();
    }

    public T GetMin()
    {
        if (_minIndex == -1)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        return _stack.ElementAt(Count - 1 - _minIndex);
    }

    public int GetMinIndex()
    {
        if (_minIndex == -1)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        return _minIndex;
    }
}