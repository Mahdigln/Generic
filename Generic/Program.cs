
    public interface IHuman
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    public class Person : IHuman
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    public class GenericCollection<T> where T : IHuman, new()
    {
        static T[] genericCollection = new[] { new T(), new T(), new T() };

        public static void DoArray()
        {
            foreach (T obj in genericCollection)
            {
                System.Console.WriteLine("Array - Value: {0}", obj);
            }

        }

        // Access items by index
        public static void DoList()
        {
            IList<T> arr = new List<T>(genericCollection);
            arr.Add(new T());
            foreach (T obj in arr)
            {
                System.Console.WriteLine("ArrayList - Value: {0}", obj.Name);

            }

        }
        public static void DoList(ICollection<T> collections)
        {
            foreach (T obj in collections)
            {
                System.Console.WriteLine("ArrayList - Name: {0}, Age {1}", obj.Name, obj.Age);
            }

        }
        // Store items as key/value pairs for quick look-up by key  
        public static void DoTable<TKey>() where TKey : new()
        {
            Dictionary<TKey, T> table = new Dictionary<TKey, T>()
            {
                {new TKey(), new T() },
                {new TKey(), new T() },
                {new TKey(), new T() }
            };
            table.Add(new TKey(), new T());
            foreach (KeyValuePair<TKey, T> item in table)
            {
                System.Console.WriteLine("Hashtable - Key: {0}, Value {1}", item.Key, item.Value);
            }
        }

        // A sorted collection
        public static void DoSortedList<TKey>() where TKey : struct
        {
            SortedList<TKey, T> list = new SortedList<TKey, T>()
            {
                {new TKey(), new T() },
                {new TKey(), new T() },
                {new TKey(), new T() }
            };
            list.Add(new TKey(), new T());
            foreach (KeyValuePair<TKey, T> item in list)
            {
                System.Console.WriteLine("SortedList - Key: {0}, Value {1}", item.Key, item.Value);
            }
        }

        // Use items first-in-first-out (FIFO)  
        public static void DoQueue()
        {
            Queue<T> queue = new Queue<T>(genericCollection);
            queue.Enqueue(new T());
            while (queue.Count > 0)
            {
                T obj = queue.Dequeue();
                System.Console.WriteLine("Queue --> Dequeue: {0}", obj);
            }
        }

        // Use items last-in-first-out (LIFO)  
        public static void DoStack()
        {
            Stack<T> stack = new Stack<T>(genericCollection);
            stack.Push(new T());
            while (stack.Count > 0)
            {
                T obj = stack.Pop();
                System.Console.WriteLine("Stack --> Pop: {0}", obj);
            }
        }
    }
class Program
{
    static void Main(string[] args)
    {
        //GenericCollection<User>.DoArray();
        GenericCollection<Person>.DoList(new List<Person>()
            {
                new Person(){Name = "Sajad", Age = 34},
                new Person(){Name = "Mohammad", Age = 29},
                new Person(){Name = "Maryam", Age = 18},
            });
        

        Console.WriteLine("Press enter key to exit ...");
        Console.ReadLine();
    }
}