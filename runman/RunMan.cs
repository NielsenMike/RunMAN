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
    }
}