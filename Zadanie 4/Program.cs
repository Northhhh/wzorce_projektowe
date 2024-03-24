using System;

namespace Adapter1
{
    interface ITarget
    {
        void GetArea();
    }

    class Square
    {
        private readonly double side;

        public Square(double sqSide)
        {
            this.side = sqSide;
        }

        public void GetArea()
        {
            Console.WriteLine("Obszar kwadratu wynosi " + Math.Pow(side, 2));
        }
    }

    class SquareAdapter : ITarget
    {
        private Square square;

        public SquareAdapter(Square square)
        {
            this.square = square;
        }

        public void GetArea()
        {
            square.GetArea();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(2.5);
            SquareAdapter squareAdapter = new SquareAdapter(square);

            squareAdapter.GetArea();
        }
    }
}
