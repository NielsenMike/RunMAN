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
        private Explorer700 explorer700;
        public Resources Resources { get; }
        public CollisonDetection CollisonDetection { get; }
        private bool running;
        private List<GameObject> gameObjects;

        public Game(Explorer700 exp)
        {
            running = false;
            explorer700 = exp;
            Resources = new Resources();
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

        public void CreateRunMan(RunMan runMan)
        {
            gameObjects.Add(runMan);
            gameObjects.Add(runMan.BoxCollider);
            CollisonDetection.RegisterBoxCollider(runMan.BoxCollider);
        }
        
        public void CreateStone(Stone stone)
        {
            gameObjects.Add(stone);
            gameObjects.Add(stone.BoxCollider);
            CollisonDetection.RegisterBoxCollider(stone.BoxCollider);
        }
        
        public void CreateGameObject(GameObject gameObject)
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
            while (running)
            {
                BeginScene();
                Update();
                Draw();
                EndScene();
                Thread.Sleep(160);
            }
            EndScene();
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
            explorer700.Display.Update();
        }

        private void EndScene()
        {
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