using System;
using System.Drawing;

namespace runman
{
    public class RunMan : GameObject
    {
        public BoxCollider BoxCollider { get; }
        private bool jumping;
        private bool up;
        private bool down;
        int ground = 15;
        int maxHeight = 50;


        public RunMan(Point position, Image graphicImage) : base(position, graphicImage)
        {
            BoxCollider = new BoxCollider(this);
            jumping = false;
            up = false;
            down = false;
            Reset();
        }

        public override void Update()
        {
            if(jumping == true)
            {
                if (Position.Y <= maxHeight && up == true)
                {
                    int y = Position.Y + 10;
                    Position = new Point(Position.X, y);
                    if(Position.Y >= maxHeight)
                    {
                        up = false;
                        down = true;
                    }
                }
                else if (down == true)
                {
                    int y = Position.Y - 10;
                    Position = new Point(Position.X, y);
                    if(Position.Y <= ground)
                    {
                        down = false;
                        jumping = false;
                    }
                }

            }
            BoxCollider.Update();
        }

        public void Jump()
        {
            if(jumping == true)
            {
                return;
            }
            jumping = true;
            up = true;
        }


        public void Reset()
        {
            int x = 16;
            int y = 15;
            Position = new Point(x, y);
        }
    }
}