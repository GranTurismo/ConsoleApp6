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
            a.Add(99); a.Add(98);
            a.Add(97); a.Add(96);
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
        public T Current => my.Current;

        object IEnumerator.Current => my.Current;

        public void Add(T obj)
        {
            my.Last.Next = new MyModel<T>() { Current = obj };
            my.Last = my.Last.Next;
        }
        public MyEnumerator()
        {
            my.Next = new MyModel<T>();
            my.Last = my.Next;
            my.FirstNext = new MyModel<T>() { Current = my.Current, Next = my.Next, };
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (my.Next.Next is null)
                return false;
            my.Current = my.Next.Current;
            my.Next = my.Next.Next;
            return true;
        }

        public void Reset()
        {
            my.Next = my.FirstNext;
            my.Current = my.FirstNext.Current;
        }
    }
}
