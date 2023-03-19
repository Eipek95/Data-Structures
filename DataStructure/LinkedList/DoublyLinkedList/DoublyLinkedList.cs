using System.Collections;

namespace DataStructure.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        private bool isHeadNull => Head == null ? true : false;
        private bool isTailNull => Tail == null ? true : false;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }//kuyruk

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (!isHeadNull)
            {
                Head.Prev = newNode;
            }
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;
            if (Tail == null)
            {
                Tail = Head;
            }
        }
        public void AddLast(T value)
        {
            if (Tail == null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;

            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }

        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();
            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Prev = refNode;
                newNode.Next = null;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if (refNode != Tail)
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;

                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
            }
            else
            {
                newNode.Prev = refNode;
                newNode.Next = null;

                refNode.Next = newNode;
                Tail = newNode;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null || newNode == null) throw new ArgumentNullException();
            if (Head == null) throw new ArgumentNullException();


            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = null;
                refNode.Prev = newNode;

                newNode.Prev = null;
                newNode.Next = refNode;

                Head = newNode;
                Tail = refNode;
                return;
            }
            if (refNode != Tail && refNode == Head)
            {
                AddFirst(newNode.Value);

            }
            else if (refNode == Tail)
            {
                refNode.Prev.Next = newNode;
                newNode.Prev = refNode.Prev;
                newNode.Next = refNode;
                refNode.Next = null;
            }
            else
            {
                refNode.Prev.Next = newNode;
                newNode.Prev = refNode.Prev;
                newNode.Next = refNode;
                refNode = refNode.Next.Next;
            }
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new ArgumentNullException();
            var temp = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }
        public T RemoveLast()
        {
            if (isTailNull)
                throw new ArgumentNullException();
            var temp = Tail.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            return temp;

        }

        public void RemoveInBetween(T value)
        {
            if (isHeadNull) throw new Exception("Empty list");
            if (Head == Tail)
            {
                if (Head.Value.Equals(value))
                {
                    RemoveFirst();
                }
                return;
            }
            else if (Tail.Value.Equals(value))
            {
                RemoveLast();
                return;
            }

            //en az iki eleman varsa
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    //current -> ilk eleman
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    //current -> son eleman
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    //current -> arada bir pozisyonda
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }
        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}
