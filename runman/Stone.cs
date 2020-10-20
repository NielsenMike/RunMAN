using System.Drawing;

namespace runman
{
    public class Stone : GameObject
    {
        public BoxCollider BoxCollider { get; }
        private int speed = 8;
        Game Game { get; }
       
        
        public Stone(Point position, Image graphicImage) : base(position, graphicImage)
        {
            BoxCollider = new BoxCollider(this);
        }

        public override void Update()
        {
            int x = Position.X - speed;
            Position = new Point(x, Position.Y);

           
            if (Position.X < 0)
            {
                this.Game.DestroyGameObjext(this);
            }
        }


        
    }
}