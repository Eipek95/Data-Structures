namespace DataStructure.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new List<T>();

        public void Clear()
        {
            if (list.Count == 0) throw new Exception("The Stack is already empty!");
            list.Clear();
            Count = 0;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Empty Stack!");
            return list[list.Count - 1];
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("Empty Stack!");

            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }

        public void Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            list.Add(item);
            Count++;
        }
    }
}
