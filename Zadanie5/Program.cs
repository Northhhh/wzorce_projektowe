using System;

namespace Zadanie5
{
    public interface ILegacyLogger
    {
        void Log(string message);
    }

    public interface INewLogger
    {
        void Log(string message);
    }

    public class NewLogger : INewLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class NewLoggerAdapter : ILegacyLogger
    {
        private readonly INewLogger _newLogger;

        public NewLoggerAdapter(INewLogger newLogger)
        {
            _newLogger = newLogger;
        }

        public void Log(string message)
        {
            _newLogger.Log(message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            INewLogger newLogger = new NewLogger();
            ILegacyLogger adapter = new NewLoggerAdapter(newLogger);

            adapter.Log("Przykładowa wiadomość");
            adapter.Log("Wystąpił problem!");
            adapter.Log("Uwaga, potencjalny problem!");
        }
    }
}
