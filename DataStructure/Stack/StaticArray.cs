namespace DataStructure.Stack
{
    internal class StaticArray<T> : IStack<T>
    {
        private T[] list = new T[5];
        private int count = -1;
        public int Count { get; private set; }

        public void Clear()
        {
            list = new T[5];
            Count = 0;
        }

        public T Peek()
        {
            return list[count];
        }

        public T Pop()
        {
            if (count == -1) throw new Exception("Empty Stack!");

            var value = list[count];
            count--;
            Count--;
            return value;

        }

        public void Push(T item)
        {
            if (count > 4)
            {
                return;
            }

            if (item == null)
            {
                throw new ArgumentNullException();
            }
            count++;
            Count++;
            list[count] = item;
        }
    }
}
