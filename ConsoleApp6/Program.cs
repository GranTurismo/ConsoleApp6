using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> a = new MyList<int>();
            a.Add(100);
            a.Add(99); 
            a.Add(98);
            a.Add(97); 
            a.Add(96);
            a.Add(95);
            a.Add(94);
            a.Add(93);
            foreach (var item in a)
                Console.WriteLine(item);
            a.GetEnumerator().Reset();
            foreach (var item in a)
                Console.WriteLine(item);
        }
    }

    class MyList<T> : IEnumerable<T>
    {
        MyEnumerator<T> Enumerator { get; set; }
        public void Add(T obj) => Enumerator.Add(obj);

        public MyList() => Enumerator = new MyEnumerator<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerator;
        }
    }

    class MyEnumerator<T> : IEnumerator<T>
    {
        MyModel<T> my = new MyModel<T>();

        private MyModel<T> first;
        public T Current => my.Current;

        object IEnumerator.Current => Current;

        public void Add(T obj)
        {
            GetLast().Next = new MyModel<T>() { Current = obj };
        }
        public MyEnumerator()
        {
            my.Next = new MyModel<T>();
            first = new MyModel<T>() { Next=my.Next };
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (my.Next is null)
                return false;
            my.Current = my.Next.Current;
            my.Next = my.Next.Next;
            return true;
        }

        public void Reset()
        {
            my = first;
        }

        private MyModel<T> GetLast()
        {
            int i = 0;
            MyModel<T> cur=my;
            while(cur.Next!=null)
            {
                cur = cur.Next;
                i++;
            }
            return cur;
        }
    }
}
