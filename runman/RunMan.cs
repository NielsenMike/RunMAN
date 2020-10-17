using System;
using System.Drawing;

namespace runman
{
    public class RunMan : GameObject
    {
        public BoxCollider BoxCollider { get; }
        
        public RunMan(Point position, Image graphicImage) : base(position, graphicImage)
        {
            BoxCollider = new BoxCollider(this);
        }

        public override void Update()
        {
            int x = Position.X + 1;
            Position = new Point(x, Position.Y);
        }

        public void Jump(object source, string args)
        {
            Console.WriteLine("Jump");
        }
    }
}