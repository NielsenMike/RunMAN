using System.Drawing;

namespace runman
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public Image GraphicImage { get; set; }

        public GameObject()
        {
            Position = Point.Empty;
            GraphicImage = null;
        }

        public GameObject(Point position, Image graphicImage)
        {
            this.Position = position;
            this.GraphicImage = graphicImage;
        }

        public abstract void Update();
    }
}