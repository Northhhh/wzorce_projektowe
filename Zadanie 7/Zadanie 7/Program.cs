using System;
using System.Collections.Generic;

namespace Zadanie_7
{
    interface IHandler
    {
        void HandleRequest(string ticketType, string inquiry);
    }

    class ConcreteHandlerTech : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleRequest(string ticketType, string inquiry)
        {
            if(ticketType == "tech")
            {
                Console.WriteLine("Twoje pytanie jest obsługiwane przez dział techniczny");
            }
            else if (successor != null)
            {
                successor.HandleRequest(ticketType, inquiry);
            }
        }
    }

    class ConcreteHandlerAccounting : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleRequest(string ticketType, string inquiry)
        {
            if (ticketType == "accounting")
            {
                Console.WriteLine("Twoje pytanie jest obsługiwane przez dział rozliczeń");
            }
            else if (successor != null)
            {
                successor.HandleRequest(ticketType, inquiry);
            }
        }
    }

    class ConcreteHandlerOther : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleRequest(string ticketType, string inquiry)
        {
            Console.WriteLine("Twoje pytanie jest obsługiwane przez dział zapytań ogólnych");
        }
    }

    class Client
    {

        static void Main(string[] args)
        {
            ConcreteHandlerTech handlerTech = new ();
            ConcreteHandlerAccounting handlerAccounting = new();
            ConcreteHandlerOther handlerOther = new();

            handlerTech.SetSuccessor(handlerAccounting);
            handlerAccounting.SetSuccessor(handlerOther);

            List<string[]> tickets = new List<string[]> { 
                new string[] { "tech", "Potrzebuję pomocy z komputerem" },
                new string[] { "other", "Brakuje kawy w ekspresie" },
                new string[] { "accounting", "Grażynko, nabij mi tą fakturę" },
            };

            foreach(string[] ticket in tickets)
            {
                Console.WriteLine("Twoje pytanie: " + ticket[1]);
                handlerTech.HandleRequest(ticket[0], ticket[1]);
            }

        }
    }
}
