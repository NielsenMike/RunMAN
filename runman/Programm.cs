using System;
using System.Drawing;
using Explorer700Library;

namespace runman
{
    public class Programm
    {
        static void Main(string[] args)
        {
            Explorer700 explorer700 = new Explorer700();
            Game game = new Game(explorer700);
            
            GameObject backgorund = new GameObject(new Point(64,32), 
                game.Resources.GetResource("background"));
            
            GameObject runman = new GameObject(new Point(16,16), 
                game.Resources.GetResource("runman1"));
            
            game.Start();
            game.CreateGameObjext(backgorund);
            game.CreateGameObjext(runman);
            game.Run();
        }
    }
}