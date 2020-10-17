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

            //Instantiate new InputHandler Object
            InputHandler inputHandler = new InputHandler(explorer700);

            //Instantiate new Score Object
            Score score = new Score(inputHandler);

            
            GameObject backgorund = new GameObject(new Point(64,32), 
                game.Resources.GetResource("background"));
            
            RunMan runman = new RunMan(new Point(16,16), 
                game.Resources.GetResource("runman1"));
            
            Stone stone = new Stone(new Point(40,16), 
                game.Resources.GetResource("stone"));
            
            game.Start();
            game.CreateGameObjext(backgorund);
            game.CreateGameObjext(runman);
            game.CreateGameObjext(stone);
            game.Run();
        }
    }
}