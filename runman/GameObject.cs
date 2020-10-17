using System.Collections.Generic;
using System.Drawing;

namespace runman
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public Image GraphicImage { get; set; }
        
        public List<Component> Components { get; }

        public GameObject()
        {
            Position = Point.Empty;
            GraphicImage = null;
            Components = new List<Component>();
        }

        public GameObject(Point position, Image graphicImage)
        {
            this.Position = position;
            this.GraphicImage = graphicImage;
            Components = new List<Component>();
        }

        public abstract void Update();
    }
}