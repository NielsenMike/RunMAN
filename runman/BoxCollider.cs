using System.Drawing;

namespace runman
{
    public class BoxCollider
    {
        private GameObject gameObject;
        public Rectangle Rectangle { get; }
        
        public BoxCollider(GameObject g)
        {
            gameObject = g;
            Rectangle = new Rectangle(gameObject.Position.X, 
                gameObject.Position.Y, 
                gameObject.GraphicImage.Width,
                gameObject.GraphicImage.Height);
        }
        
        
        
    }
}