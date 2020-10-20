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
            stoneTimer.Stop();
            lastelapsed = stoneTimer.ElapsedMilliseconds;
            if(lastelapsed > 2000)
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

        public void InitEvents()
        {
            Game.InputHandler.JumpEvent += runman.Jump;
            Game.InputHandler.StopEvent += Game.Stop;
            Game.InputHandler.StartEvent += () =>
            {
                CreateRandomStone();
                Game.Score.StartScore();
            };
            Game.CollisonDetection.CollisionEvent += (GameObject g, GameObject other) =>
            {
                if (g.GetType() == typeof(RunMan) && other.GetType() == typeof(Stone))
                {
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
            programm.Game.Start();
            programm.stoneTimer = Stopwatch.StartNew();
            programm.stoneTimer.Start();
            while (programm.Game.IsRunning())
            {
                programm.Game.Run();
                programm.CreateRandomStone();
            }
            programm.Game.Stop();
        }
    }
}