using DataStructure.Stack;

class Program
{
    static void Main(string[] args)
    {
        var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
        var stack1 = new DataStructure.Stack.Stack<char>();//dynamic array
        var stack2 = new DataStructure.Stack.Stack<char>(StackType.LinkedList);//singlylinkedlist
        var stack3 = new DataStructure.Stack.Stack<char>(StackType.StaticArray);
        foreach (char c in charset)
        {
            Console.WriteLine(c);
            stack1.Push(c);
            stack2.Push(c);
            stack3.Push(c);
        }
        Console.WriteLine($"Stack1.Peek: {stack1.Peek()} + Stack2.Peek: {stack2.Peek()} + Stack3.Peek: {stack3.Peek()}");
        Console.WriteLine($"Stack1.Count: {stack1.Count} + Stack2.Count: {stack2.Count} + Stack3.Count: {stack3.Count}");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Pop: {stack1.Pop()} + Stack2.pop: {stack2.Pop()} + Stack3.pop: {stack3.Pop()} ");
        Console.WriteLine($"Stack1.Count: {stack1.Count} + Stack2.Count: {stack2.Count} + Stack3.Count: {stack3.Count} ");




    }
}