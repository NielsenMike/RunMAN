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
        public Programm()
        {
            explorer700 = new Explorer700();
            Game = new Game(explorer700);
            
            background = new Background(new Point(64,32), 
                Game.Resources.GetResource("background"));
            
            runman = new RunMan(new Point(16,15), 
                Game.Resources.GetResource("runman1"));
        }

        public void CreateRandomStone()
        {
            // Here Create stones
        }

        public void InitGame()
        {
            Game.CreateGameObject(background);
            Game.CreateGameObject(runman);
        }

        public void InitEvents()
        {
            Game.InputHandler.JumpEvent += runman.Jump;
            Game.InputHandler.StartEvent += Game.Start;
            Game.InputHandler.StopEvent += Game.Stop;
            
            Game.CollisonDetection.CollisionEvent += () =>
            {
                runman.Reset();
                Game.Score.PrintScore();
            };
        }

        static void Main(string[] args)
        {
            Programm programm = new Programm();
            programm.InitEvents();
            programm.InitGame();
            programm.Game.Start();
            while (programm.Game.IsRunning())
            {
                programm.Game.Run();
                programm.CreateRandomStone();
            }
        }
    }
}