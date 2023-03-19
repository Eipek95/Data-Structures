namespace DataStructure.Stack
{
    public class Stack<T>
    {
        private readonly IStack<T> _stack;
        public int Count => _stack.Count;

        public Stack(StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                _stack = new ArrayStack<T>();
            }
            else if (type == StackType.LinkedList)
            {
                _stack = new LinkedListStack<T>();
            }
            else
            {
                _stack = new StaticArray<T>();
            }
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }
        public void Push(T item)
        {
            _stack.Push(item);
        }

        public void Clear()
        {
            _stack.Clear();
        }
    }
}
