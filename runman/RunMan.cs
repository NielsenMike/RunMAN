using System;
using System.Drawing;

namespace runman
{
    public class RunMan : GameObject
    {
        public BoxCollider BoxCollider { get; }
        private bool jumping;
        int ground = 15;
        int maxHeight = 45;


        public RunMan(Point position, Image graphicImage) : base(position, graphicImage)
        {
           
            BoxCollider = new BoxCollider(this);
            jumping = false;

        }

        public override void Update()
        {
          
            if (jumping == true && Position.Y <= maxHeight)
            {
                int y = Position.Y + 5;
                Position = new Point(Position.X, y);

            }
            if (jumping == true && Position.Y >= maxHeight)
            {
                int y = Position.Y - 5;
                Position = new Point(Position.X, y);
            }
            if(jumping == true && Position.Y == ground)
            {
                jumping = false;
                Console.WriteLine("Jump Comlpete");
            }


        }

        public void Jump()
        {
            if(jumping == true)
            {
                Console.WriteLine("Cannot Double Jump...");
                return;
            }
            jumping = true;
            Console.WriteLine("Jumping");
        }


        public void reset()
        {
            int x = 16;
            int y = 15;
            Position = new Point(x, y);
        }



    }
}