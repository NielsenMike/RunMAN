using System.Drawing;

namespace runman
{
    public class GameObject
    {
        public Point position { get; set; }
        public Image graphicImage;

        public GameObject()
        {
            position = Point.Empty;
            graphicImage = null;
        }

        public GameObject(Point position, Image graphicImage)
        {
            this.position = position;
            this.graphicImage = graphicImage;
        }
    }
}