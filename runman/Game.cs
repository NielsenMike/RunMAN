using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using Explorer700Library;
using Unosquare.WiringPi;

namespace runman
{
    public class Game
    {
        public static int ScreenHeight = 64;
        public static int ScreenWidth = 128;
        private Explorer700 explorer700;
        public InputHandler InputHandler { get; }
        public Resources Resources { get; }
        public CollisonDetection CollisonDetection { get; }
        public Score Score { get; }
        private bool running;
        private List<GameObject> gameObjects;
        private Stopwatch gameWatch;

        private long frameMs = 160;
        private long currentMs = 0;


        public Game(Explorer700 exp)
        {
            running = true;
            explorer700 = exp;
            Resources = new Resources();
            Score = new Score();
            InputHandler = new InputHandler(exp);
            CollisonDetection = new CollisonDetection();
            gameObjects = new List<GameObject>();
            InitResources();
        }

        // Init new resources here!!
        private void InitResources()
        {
            Resources.Load("background.png", "background");
            Resources.Load("runman1.png", "runman1");
            Resources.Load("runman2.png", "rundman2");
            Resources.Load("stone.png", "stone");
        }
        
        
        public void CreateGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            foreach (Component c in gameObject.Components)
            {
                if (c != null && c.GetType() == typeof(BoxCollider))
                {
                    BoxCollider box = (BoxCollider) c;
                    CollisonDetection.Colliders.Add(box);
                }
            }
        }
        
        public void DestroyGameObjext(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
            foreach (Component c in gameObject.Components)
            {
                if (c != null && c.GetType() == typeof(BoxCollider))
                {
                    BoxCollider box = (BoxCollider) c;
                    CollisonDetection.Colliders.Remove(box);
                }
            }
        }

        public void Start()
        {
            Score.StartScore();
        }

        public void Stop()
        {
            explorer700.Buzzer.Beep(0);
            explorer700.Led1.Enabled = false;
            explorer700.Led2.Enabled = false;
            explorer700.Display.Clear();
            running = false;
        }

        public void Run()
        {
            BeginScene();
            Update();
            Draw();
            EndScene();
        }

        public bool IsRunning()
        {
            return running;
        }


        private void Update()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Update();
            }
            CollisonDetection.DetectCollison();
        }

        private void Draw()
        {
            foreach (GameObject g in gameObjects)
            {
                DebugDraw(g);
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
            gameWatch = Stopwatch.StartNew();
            currentMs = 0;
            explorer700.Display.Update();
        }

        private void EndScene()
        {
            gameWatch.Stop();
            currentMs = gameWatch.ElapsedMilliseconds;
            gameWatch.Reset();
            int frameTime = (int) (frameMs - currentMs);
            Thread.Sleep(frameTime > 0 ? frameTime : 0);
            explorer700.Display.Update();
        }

        private void DebugDraw(GameObject g)
        {
            Point screenPoint = new Point();
            if (g.GetType() == typeof(RunMan))
            {
                RunMan runMan = (RunMan) g;
                Point p = new Point(runMan.BoxCollider.Rectangle.X,
                    runMan.BoxCollider.Rectangle.Y);
                screenPoint = PositionToScreen(p, runMan.GraphicImage.Size);
            }
            else if (g.GetType() == typeof(Stone))
            {
                Stone stone = (Stone) g;
                Point p = new Point(stone.BoxCollider.Rectangle.X,
                    stone.BoxCollider.Rectangle.Y);
                screenPoint = PositionToScreen(p, stone.GraphicImage.Size);
            }
            explorer700.Display.Graphics.DrawRectangle(Pens.Black, 
                screenPoint.X,
                screenPoint.Y, 
                g.GraphicImage.Width, 
                g.GraphicImage.Height);
        }
        
    }
}