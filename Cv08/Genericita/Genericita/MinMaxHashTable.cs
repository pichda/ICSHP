using System;
using System.Collections.Generic;

namespace GenericExercise.Tests
{

    class MinMaxHashTable<TKey, TValue> where TKey : IComparable
    {
        internal struct Prvek<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public int Count { get; set; }
        public LinkedList<Prvek<TKey, TValue>>[] items;
        private int size;
        private int maximum;
        private int minimum;

        


        public int Maximum
        {
            get { if (Count != 0) { return maximum; } throw new InvalidOperationException(); }
            set { maximum = value; }
        }
        public int Minimum
        {
            get { if (Count != 0) { return minimum; } throw new InvalidOperationException(); }
            set { minimum = value; }
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }



        public MinMaxHashTable(int capacity)
        {
            Count = 0;
            this.items = new LinkedList<Prvek<TKey, TValue>>[capacity];
            maximum = 0;
            minimum = 0;
            size = capacity;
        }
        public MinMaxHashTable()
        {
            Count = 0;
            this.items = new LinkedList<Prvek<TKey, TValue>>[20];
            maximum = 0;
            minimum = 0;
            size = 20;
        }

        public Prvek<TKey, TValue>[] this[int indexMin, int indexMax]
        {
            get
            {
                return Range(indexMin, indexMax);
            }
        }

        public void Add(TKey key, TValue value)
        {

            int pozice = GetArrayPosition(key);

            LinkedList<Prvek<TKey, TValue>> linkedList = items[pozice];

            if (linkedList == null)
            {
                linkedList = new LinkedList<Prvek<TKey, TValue>>();
                items[pozice] = linkedList;
            }

            Prvek<TKey, TValue> prvek = new Prvek<TKey, TValue>() { Key = key, Value = value };

            if (linkedList.Count == 0)
            {
                linkedList.AddFirst(prvek);
            }
            else
            {
                if (Contains(key))
                {
                    throw new ArgumentException();
                }
                items[pozice].AddFirst(prvek);
            }

            if (Convert.ToInt32(key) < minimum)
            {
                minimum = Convert.ToInt32(key);
            }
            if (Convert.ToInt32(key) > maximum)
            {
                maximum = Convert.ToInt32(key);
            }
            Count++;
        }

        public bool Contains(TKey key)
        {
            if (Count == 0)
            {
                return false;
            }
            else
            {
                int pozice = GetArrayPosition(key);

                if (items[pozice] == null)
                {
                    return false;
                }

                LinkedListNode<Prvek<TKey, TValue>> aktualni = items[pozice].First;
                while (aktualni!=null)
                {
                    if (aktualni.Value.Key.Equals(key))
                    {
                        return true;
                    }
                    aktualni = aktualni.Next;
                }
                return false;
            }
        }

        public TValue Get(TKey key)
        {

            if (Count == 0)
            {
                throw new KeyNotFoundException();
            }

            int pozice = GetArrayPosition(key);

            if (items[pozice]==null)
            {
                throw new KeyNotFoundException();
            }

            LinkedListNode<Prvek<TKey, TValue>> aktualni = items[pozice].First;
            while (aktualni != null)
            {
                if (aktualni.Value.Key.Equals(key))
                {
                    return aktualni.Value.Value;
                }
                aktualni = aktualni.Next;
            }
            throw new KeyNotFoundException();
        }

        public TValue Remove(TKey key)
        {
            if (Count == 0)
            {
                throw new KeyNotFoundException();
            }

            int pozice = GetArrayPosition(key);

            if (items[pozice]==null)
            {
                throw new KeyNotFoundException();
            }

            LinkedListNode<Prvek<TKey, TValue>> aktualni = items[pozice].First;
            while (aktualni != null)
            {
                if (aktualni.Value.Key.Equals(key))
                {
                    TValue val = aktualni.Value.Value;
                    items[pozice].Remove(aktualni);
                    Count--;
                    return val;
                }
            }
            throw new KeyNotFoundException();

        }

        public Prvek<TKey, TValue>[] Range(int min, int max)
        {
            if (Count > 0)
            {
                int velikostRange = 0;
                for (int i = min; i < max+1; i++)
                {
                    velikostRange += items[i].Count;
                }

                Prvek<TKey, TValue>[] range = new Prvek<TKey, TValue>[velikostRange];
                int index = 0;

                for (int i = min; i < max+1; i++)
                {
                    LinkedListNode<Prvek<TKey, TValue>> aktualni = items[i].First;
                    while (aktualni != null)
                    {
                        range[index] = aktualni.Value;
                        index++;
                        aktualni = aktualni.Next;
                    }
                }
                return range;
            }
            return null;
        }

        public Prvek<TKey, TValue>[] SortedRange(int min, int max)
        {
            Prvek<TKey, TValue>[] range = Range(min, max);

            for (int i = 0; i < range.Length - 1; i++)
            {
                for (int j = 0; j < range.Length - i - 1; j++)
                {
                    if (range[j + 1].Key.CompareTo(range[j].Key) < 0)
                    {
                        Prvek<TKey, TValue> tmp = range[j + 1];
                        range[j + 1] = range[j];
                        range[j] = tmp;
                    }
                }
            }
            return range;
        }
    }
}