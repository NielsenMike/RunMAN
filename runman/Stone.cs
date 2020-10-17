using System.Drawing;

namespace runman
{
    public class Stone : GameObject
    {
        public BoxCollider BoxCollider { get; }
        public Stone(Point position, Image graphicImage) : base(position, graphicImage)
        {
            BoxCollider = new BoxCollider(this);
        }

        public override void Update()
        {
        }
    }
}