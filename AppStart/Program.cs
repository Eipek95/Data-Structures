using DataStructure.LinkedList.SinglyLinkedList;

namespace AppStart
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var list = new SinglyLinkedList<int>(new int[] { 23, 44, 11, 22 });
            list.Remove(11);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
        private static void RemoveAtFirstAndLastByLinkedList()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            var list = new SinglyLinkedList<int>(initial);
            list.ToList().ForEach(x => Console.WriteLine(x));
            list.RemoveFirst();
            list.RemoveLast();
            list.ToList().ForEach(x => Console.Write(x + " "));

        }

        private static void LinkedListByLinq()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedlist = new SinglyLinkedList<int>(initial);
            linkedlist.Where(x => x % 2 == 1).ToList().ForEach(x => Console.WriteLine(x + " "));
            linkedlist.Where(x => x > 5).ToList().ForEach(x => Console.Write(x + "  "));
            Console.ReadKey();
        }

        private static void CollectionMethod()
        {
            var arr = new char[] { 'a', 'b', 'c' };
            var list = new List<char>(arr);
            list.AddRange(new char[] { 'd', 'e', 'f' });
            var linkedList = new SinglyLinkedList<char>(list);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
        private static void linkedListProcess()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(1);//head düğümleri ekledik
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);//3 2 1 4 5
            linkedList.AddAfter(linkedList.Head.Next, 32);//3 2 32  1 4 5
            linkedList.AddAfter(linkedList.Head.Next.Next, 33);//3 2 32 33  1 4 5

            var newNode = new SinglyLinkedListNode<int>(6);
            newNode.Next = null;

            linkedList.AddAfter(linkedList.Head.Next.Next, newNode);//3 2 32 6 1 4 5

            var reqNode = linkedList.Head.Next.Next;
            linkedList.AddBefore(reqNode, 10);//3  2 10 32 6  1 4 5



            var newNode2 = new SinglyLinkedListNode<int>(21);
            newNode2.Next = null;
            linkedList.AddBefore(linkedList.Head, newNode2);// 3 21 2 10 32 6 1 4 5


            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }

}
