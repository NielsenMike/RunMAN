using System;
using System.Drawing;
using System.Threading;
using Explorer700Library;

namespace runman
{
    public class Programm
    {
        static void Main(string[] args)
        {
            Explorer700 explorer700 = new Explorer700();
            Game game = new Game(explorer700);
            
            Background backgorund = new Background(new Point(64,32), 
                game.Resources.GetResource("background"));
            
            RunMan runman = new RunMan(new Point(16,15), 
                game.Resources.GetResource("runman1"));
            
            Stone stone = new Stone(new Point(130,15), 
                game.Resources.GetResource("stone"));

            game.InputHandler.JumpEvent += runman.Jump;
            game.InputHandler.StartEvent += game.Start;
            game.InputHandler.StopEvent += game.Stop;
            game.InputHandler.StopEvent += runman.Reset;

            game.Start();
            game.CreateGameObject(backgorund);
            game.CreateGameObject(runman);
            game.CreateGameObject(stone);
            game.Run();
        }
    }
}