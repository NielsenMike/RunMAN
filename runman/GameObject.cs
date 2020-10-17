using System.Drawing;

namespace runman
{
    public class GameObject
    {
        public Point Position { get; set; }
        public Image GraphicImage { get; set; }
        public BoxCollider BoxCollider { get; }

        public GameObject()
        {
            Position = Point.Empty;
            GraphicImage = null;
            BoxCollider = null;
        }

        public GameObject(Point position, Image graphicImage)
        {
            this.Position = position;
            this.GraphicImage = graphicImage;
        }

        public void Update()
        {
            
        }

        public void CreateBoxCollider()
        {
            
        }
    }
}