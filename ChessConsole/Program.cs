using System;

namespace ChessConsole
{
    public class Program
    {
        static ChessGame game;
        static void Main(string[] args)
        {

            Console.WriteLine("Select which game mode you want:\n\n[1] - Chess\n\n[2] - Chess960\n\n");
			int mode = 0;
            do
            {
                try
                {
                    Console.WriteLine("Choose Your Game Mode");
					mode = int.Parse(Console.ReadLine());
                }
                catch
                {
					mode = 0;
                }
			} while (!(mode == 1 || mode == 2));
            

            Console.Clear();
            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();

            game = new ChessGame(mode);

            do
            {
                game.Draw(graphics);
                graphics.SwapBuffers();
                game.Update();
            } while (game.Running);

            Console.Read();
        }
    }
}
