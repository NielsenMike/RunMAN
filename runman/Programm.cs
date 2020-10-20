using System;
using System.Drawing;
using System.Threading;
using Explorer700Library;
using System.Diagnostics;
using System.Collections;


namespace runman
{
    public class Programm
    {
        private Explorer700 explorer700;
        public Game Game { get; }
        private Background background;
        private RunMan runman;
        private Stone stone;
        public Stopwatch stoneTimer;
        private long lastelapsed;
        public ArrayList stones = new ArrayList();
        public Programm() 
        {
            explorer700 = new Explorer700();
            Game = new Game(explorer700);
            
            background = new Background(new Point(64,32), 
                Game.Resources.GetResource("background"));
            
            runman = new RunMan(new Point(16,15), 
                Game.Resources.GetResource("runman1"));

             stone = new Stone(new Point(130, 15),
                Game.Resources.GetResource("stone"));
        }

        public void CreateRandomStone()
        {
            stoneTimer.Stop();
            lastelapsed = stoneTimer.ElapsedMilliseconds;
            if(lastelapsed > 2000)
            {
                Game.CreateGameObject(stone);
                stoneTimer.Reset();
                stoneTimer.Start();
            } else
            {
                stoneTimer.Start();
            }
        }

        public void InitGame()
        {
            stones.Add(stone);
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
            programm.stoneTimer = Stopwatch.StartNew();
            programm.stoneTimer.Start();
            while (programm.Game.IsRunning())
            {
                programm.Game.Run();
                programm.CreateRandomStone();
            }
        }
    }
}