using System;
using System.Collections.Generic;

namespace Singleton_2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBuffer buffer = PrintBuffer.GetInstance();
            buffer.AddTask("First task", "Lorem ipsum 111111111");
            buffer.AddTask("Second task", "Lorem ipsum 22222222");
            buffer.AddTask("Third task", "Lorem ipsum 333333333");

            buffer.PrintTasks();
        }
    }

    class PrintBuffer
    {
        private static PrintBuffer _instance = new PrintBuffer();
        private readonly List<string[]> _data;

        private PrintBuffer()
        {
            _data = new List<string[]>();
        }

        public static PrintBuffer GetInstance()
        {
            if (_instance is null)
                _instance = new PrintBuffer();
            return _instance;
        }

        public void AddTask(string name, string content)
        {
            _data.Add(new string[] { name, content });
        }

        public void PrintTasks()
        {
            foreach (var data in _data)
            {
                Console.WriteLine("--- Task: {0} ---", data[0]);
                Console.WriteLine(data[1]);
            }

            _data.Clear();
        }
    }
}
