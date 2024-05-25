using System;
using System.Collections.Generic;

namespace Zadanie_8
{
    interface IHandler
    {
        void HandleLog(string logType, string message);
    }

    class ConcreteHandlerInfo : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleLog(string logType, string message)
        {
            if (logType == "info")
            {
                Console.WriteLine("INFO: " + message);
            }
            else if (successor != null)
            {
                successor.HandleLog(logType, message);
            }
        }
    }

    class ConcreteHandlerWarning : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleLog(string logType, string message)
        {
            if (logType == "warning")
            {
                Console.WriteLine("OSTRZEŻENIE: " + message);
            }
            else if (successor != null)
            {
                successor.HandleLog(logType, message);
            }
        }
    }

    class ConcreteHandlerError : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleLog(string logType, string message)
        {
            Console.WriteLine("BŁĄD: " + message);
        }
    }

    class Client
    {

        static void Main(string[] args)
        {
            ConcreteHandlerInfo handlerInfo = new();
            ConcreteHandlerWarning handlerWarning = new();
            ConcreteHandlerError handlerError = new();

            handlerInfo.SetSuccessor(handlerWarning);
            handlerWarning.SetSuccessor(handlerError);

            List<string[]> logs = new List<string[]> {
                new string[] { "info", "Pouczająca informacja" },
                new string[] { "error", "Wystąpił bardzo poważny błąd" },
                new string[] { "warning", "Ostrzegam!" },
            };

            foreach (string[] log in logs)
            {
                handlerInfo.HandleLog(log[0], log[1]);
            }
        }
    }
}
