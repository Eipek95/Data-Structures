using DataStructure.LinkedList.SinglyLinkedList;

namespace DataStructure.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public void Clear()
        {
            if (Count == 0) throw new Exception("The Stack is already empty!");
            list.RemoveAll();
            Count = 0;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Empty Stack!");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("Empty Stack!");
            var temp = list.RemoveFirst();
            Count--;
            return temp;

        }

        public void Push(T item)
        {
            if (item == null) throw new ArgumentNullException();

            list.AddFirst(item);
            Count++;
        }
    }
}
