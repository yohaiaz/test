using System;

namespace helloworld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe!");

            GameBoard gb = new GameBoard();

            gb.Reset();

            while (!gb.IsOver()) {
                Console.WriteLine(gb.WhoseTurnItIs());

                Console.Write("enter x: ");
                ConsoleKeyInfo x = Console.ReadKey();

                Console.Write("\n enter y: ");
                ConsoleKeyInfo y = Console.ReadKey();

                Console.WriteLine(gb.Play(ToInt(x.KeyChar), ToInt(y.KeyChar)));

                Console.WriteLine(gb.Display());
            }
        }

        static int ToInt(char c)
        {
            return (int)(c - '0');
        }
    }
}
