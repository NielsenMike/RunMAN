using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using Explorer700Library;
using Unosquare.WiringPi;

namespace runman
{
    class Game
    {
        public static int ScreenHeight = 64;
        public static int ScreenWidth = 128;
        public Resources Resources { get; private set; }
        private Explorer700 explorer700;
        private bool running;
        private List<GameObject> gameObjects;

        private long frameMilliSec = 160;


        public Game(Explorer700 exp)
        {
            running = false;
            explorer700 = exp;
            gameObjects = new List<GameObject>();
            InitResources();
        }

        // Init new resources here!!
        private void InitResources()
        {
            Resources = new Resources();
            Resources.Load("background.png", "background");
            Resources.Load("runman1.png", "runman1");
            Resources.Load("runman2.png", "rundman2");
            Resources.Load("stone.png", "stone");
        }

        public void CreateGameObjext(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        
        public void DestroyGameObjext(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public void Start()
        {
            running = true;
        }

        public void Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (running)
            {
                watch.Start();
                long elapsedMs = 0;

                BeginScene();
                Update();
                Draw();
                EndScene();

                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                watch.Reset();

                int timeLeft = (int)(frameMilliSec - elapsedMs);
                Thread.Sleep(timeLeft);
            }
            EndScene();
        }


        private void Update()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Update();
            }
        }

        private void Draw()
        {
            foreach (GameObject g in gameObjects)
            {
                explorer700.Display.Graphics.DrawImage(g.GraphicImage,
                    PositionToScreen(g.Position, g.GraphicImage.Size));
            }
        }

        public static Point PositionToScreen(Point position, Size imageSize)
        {
            return new Point(
                position.X - imageSize.Width / 2, 
                ((position.Y - ScreenHeight) * -1) - imageSize.Height / 2);
        }
        
        private void BeginScene()
        {
            explorer700.Display.Update();
        }

        private void EndScene()
        {
            explorer700.Display.Update();
        }
    }
}