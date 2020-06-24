using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    public class MyModel<T>
    {
        public T Current { get; set; }
        public MyModel<T> Next { get; set; }
        public MyModel<T> Last { get; set; }
        public MyModel<T> FirstNext { get; set; }

        public MyModel()
        {
        }
    }
}
