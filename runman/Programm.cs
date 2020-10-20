using System;
using System.Drawing;
using System.Threading;
using Explorer700Library;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace runman
{
    public class Programm
    {
        private Explorer700 explorer700;
        public Game Game { get; }
        private Background background;
        private RunMan runman;
        public GameObject gameObject { get; }
        public Stopwatch stoneTimer;
        private long lastelapsed;
        public List<Stone> stones = new List<Stone>();

        private bool startGame = false;
        
        public Programm() 
        {
            explorer700 = new Explorer700();
            Game = new Game(explorer700);
            
            background = new Background(new Point(64,32), 
                Game.Resources.GetResource("background"));
            
            runman = new RunMan(new Point(16,15), 
                Game.Resources.GetResource("runman1"));
            
            Game.CreateGameObject(background);
            Game.CreateGameObject(runman);

        }

        public void CreateRandomStone()
        {
            Random r = new Random((int)stoneTimer.ElapsedMilliseconds);
            int randomtime = r.Next(1000, 2500);
            stoneTimer.Stop();
            lastelapsed = stoneTimer.ElapsedMilliseconds;
            if(lastelapsed >= randomtime)
            {
                Stone stone = new Stone(new Point(130, 15),
                Game.Resources.GetResource("stone"));
                stones.Add(stone);
                Game.CreateGameObject(stone);
                stoneTimer.Reset();
                stoneTimer.Start();
            } else
            {
                stoneTimer.Start();
            }
        }

        public void DeleteStones()
        {
            foreach(Stone s in stones)
            {
                Game.DestroyGameObjext(s);
            }
            stones.Clear();
        }

        public bool HasStarted()
        {
            return startGame;
        }

        public void InitEvents()
        {
            Game.InputHandler.JumpEvent += runman.Jump;
            Game.InputHandler.StopEvent += Game.Stop;
            Game.InputHandler.StartEvent += () =>
            {
                startGame = true;
                Game.Score.StartScore();
            };
            Game.CollisonDetection.CollisionEvent += (GameObject g, GameObject other) =>
            {
                if (g.GetType() == typeof(RunMan) && other.GetType() == typeof(Stone))
                {
                    startGame = false;
                    runman.Reset();
                    DeleteStones();
                    Game.Score.PrintScore();
                }
            };
        }

        static void Main(string[] args)
        {
            Programm programm = new Programm();
            programm.InitEvents();
            programm.stoneTimer = Stopwatch.StartNew();
            programm.stoneTimer.Start();
            while (programm.Game.IsRunning())
            {
                programm.Game.Run();
                if (programm.HasStarted())
                {
                    programm.CreateRandomStone();
                }
            }
            programm.Game.Stop();
        }
    }
}