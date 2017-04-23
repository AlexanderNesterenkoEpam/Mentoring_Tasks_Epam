using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task2_1_2_Collections
{
    class CompareCollections
    {
        private ArrayList _arrayList = new ArrayList();
        private LinkedList<int> _linkedList = new LinkedList<int>();
        private Stack<int> _stack = new Stack<int>();
        private Queue<int> _queue = new Queue<int>();
        private Hashtable _hashtable = new Hashtable();
        private Dictionary<int, int> _dictionary = new Dictionary<int, int>();

        private int _elementsCount;

        public CompareCollections(int elementsCount)
        {
            _elementsCount = elementsCount;
            InitializeCollections(elementsCount);
        }

        public string Compare()
        {
            string report = TestAdd() + TestFind() + TestDelete();
            return report;
        }

        private string TestAdd()
        {
            string report = "";
            int value = _elementsCount + 1;
            const string separator = "==============================================================\n";
            report += separator + "Add element : All numbers in millisecondes\n" + separator;
            long arrayListTime = GetOperationMillisecondes(() => _arrayList.Add(value));
            long linkedListAddFirstTime = GetOperationMillisecondes(() => _linkedList.AddFirst(value));
            long linkedListAddLastTime = GetOperationMillisecondes(() => _linkedList.AddFirst(value));
            report += string.Format("\nArrayList: {0}\nLinkedList, AddFirst: {1}\nLinkedList, AddLast: {2}\n", arrayListTime, linkedListAddFirstTime, linkedListAddLastTime);

            long stackTime = GetOperationMillisecondes(() => _stack.Push(value));
            long queueTime = GetOperationMillisecondes(() => _queue.Enqueue(value));
            report += string.Format("\nStack: {0}\nQueue: {1}\n", stackTime, queueTime);

            long hashTableTime = GetOperationMillisecondes(() => _hashtable.Add(value, value));
            long dictionaryTime = GetOperationMillisecondes(() => _dictionary.Add(value, value));
            report += string.Format("\nHashtable: {0}\nDictionary: {1}\n\n", hashTableTime, dictionaryTime);
            return report;
        }

        private string TestFind()
        {
            string report = "";
            int value = _elementsCount / 2;
            const string separator = "==============================================================\n";
            report += separator + "Find element : All numbers in millisecondes\n" + separator;
            long arrayListTime = GetOperationMillisecondes(() => _arrayList.Contains(value));
            long linkedListTime = GetOperationMillisecondes(() => _linkedList.Contains(value));
            report += string.Format("\nArrayList: {0}\nLinkedList: {1}\n", arrayListTime, linkedListTime);

            long stackTime = GetOperationMillisecondes(() => _stack.Contains(value));
            long queueTime = GetOperationMillisecondes(() => _queue.Contains(value));
            report += string.Format("\nStack: {0}\nQueue: {1}\n", stackTime, queueTime);

            long hashTableTime = GetOperationMillisecondes(() => _hashtable.ContainsValue(value));
            long dictionaryTime = GetOperationMillisecondes(() => _dictionary.ContainsValue(value));
            report += string.Format("\nHashtable: {0}\nDictionary: {1}\n\n", hashTableTime, dictionaryTime);
            return report;
        }

        private string TestDelete()
        {
            string report = "";
            int value = _elementsCount / 2;
            const string separator = "==============================================================\n";
            report += separator + "Delete element : All numbers in millisecondes\n" + separator;
            long arrayListTime = GetOperationMillisecondes(() => _arrayList.Remove(value));
            long linkedListTime = GetOperationMillisecondes(() => _linkedList.Remove(value));
            report += string.Format("\nArrayList: {0}\nLinkedList: {1}\n", arrayListTime, linkedListTime);

            long stackTime = GetOperationMillisecondes(() => _stack.Pop());
            long queueTime = GetOperationMillisecondes(() => _queue.Dequeue());
            report += string.Format("\nStack: {0}\nQueue: {1}\n", stackTime, queueTime);

            long hashTableTime = GetOperationMillisecondes(() => _hashtable.Remove(value));
            long dictionaryTime = GetOperationMillisecondes(() => _dictionary.Remove(value));
            report += string.Format("\nHashtable: {0}\nDictionary: {1}\n", hashTableTime, dictionaryTime);
            return report;
        }

        private long GetOperationMillisecondes(Action operation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            operation.Invoke();
            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }

        private void InitializeCollections(int elementsCount)
        {
            int value;
            for (int i = 0; i < elementsCount; i++)
            {
                value = i;
                _arrayList.Add(value);
                _linkedList.AddLast(value);
                _stack.Push(value);
                _queue.Enqueue(value);
                _hashtable.Add(i, value);
                _dictionary.Add(i, value);
            }
        }
    }
}
