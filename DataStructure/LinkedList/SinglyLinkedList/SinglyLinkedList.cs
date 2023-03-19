using System.Collections;

namespace DataStructure.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList()
        {
        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null ? true : false;

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (isHeadNull)//liste bossa
            {
                Head = newNode;
                return;
            }


            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentException();
            }

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null || newNode == null)
            {
                throw new ArgumentException();
            }
            if (isHeadNull)
            {
                AddFirst(newNode.Value);
                return;
            }
            var current = Head;
            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new NotImplementedException("The reference node is not in this list");
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null) throw new ArgumentException();
            if (isHeadNull) throw new NotImplementedException();
            if (node == Head) { AddFirst(value); return; }

            SinglyLinkedListNode<T> tempNode = null;
            var current = Head;
            try
            {
                for (SinglyLinkedListNode<T> n = current; n != node; tempNode = n, n = n.Next) ;

                SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);
                newNode.Next = tempNode.Next;
                tempNode.Next = newNode;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            try
            {
                if (refNode == null || newNode == null) throw new NotImplementedException();
                if (isHeadNull) throw new NotImplementedException();
                if (refNode == Head) { AddFirst(newNode.Value); return; }

                SinglyLinkedListNode<T> tempNode = null;
                var current = Head;

                for (SinglyLinkedListNode<T> n = current; n != refNode; tempNode = n, n = n.Next) ;

                newNode.Next = tempNode.Next;
                tempNode.Next = newNode;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Underflow! Nothing to remove.");
            }
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }
        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }

        public void Remove(T value)
        {
            if (isHeadNull) throw new Exception("Underflow! Nothing to remove.");
            if (value == null) throw new ArgumentNullException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            do
            {
                //son eleman mı
                if (current.Value.Equals(value))
                {
                    if (current.Next == null)
                    {
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }

                    else
                    {
                        //head
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        //ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;

                        }
                    }

                }
                //kaydırma işlemleri prev ve current sırasıyla devam edip birbirini izliyor
                prev = current;
                current = current.Next;
            } while (current != null);

            throw new ArgumentException("The value could not be found in the list!");
        }

        public void RemoveAll()
        {
            if (isHeadNull) throw new Exception("Underflow! Nothing to remove.");
            Head = null;

        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
