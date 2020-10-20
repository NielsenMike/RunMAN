using System;
using System.Drawing;
using System.Threading;
using Explorer700Library;

namespace runman
{
    public class Programm
    {
        private Explorer700 explorer700;
        public Game Game { get; }
        private Background background;
        private RunMan runman;
        private Stone stone;
        public Programm()
        {
            explorer700 = new Explorer700();
            Game = new Game(explorer700);
            
            background = new Background(new Point(64,32), 
                Game.Resources.GetResource("background"));
            
            runman = new RunMan(new Point(16,15), 
                Game.Resources.GetResource("runman1"));
            
            stone = new Stone(new Point(128,15), 
                Game.Resources.GetResource("stone"));
        }

        public void CreateRandomStone()
        {
            
        }

        public void InitGame()
        {
            Game.CreateGameObject(background);
            Game.CreateGameObject(runman);
            Game.CreateGameObject(stone);
        }

        public void InitEvents()
        {
            Game.InputHandler.JumpEvent += runman.Jump;
            Game.InputHandler.StartEvent += Game.Start;
            Game.InputHandler.StopEvent += Game.Stop;
            
            Game.CollisonDetection.CollisionEvent += (GameObject g, GameObject other) =>
            {
                if (g.GetType() == typeof(RunMan) && other.GetType() == typeof(Stone))
                {
                    runman.Reset();
                    Game.DestroyGameObjext(stone);
                    Game.Score.PrintScore();
                }
            };
        }

        static void Main(string[] args)
        {
            Programm programm = new Programm();
            programm.InitEvents();
            programm.InitGame();
            while (programm.Game.IsRunning())
            {
                programm.Game.Run();
                programm.CreateRandomStone();
            }
            programm.Game.Stop();
        }
    }
}