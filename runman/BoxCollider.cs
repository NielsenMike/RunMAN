using System.Drawing;

namespace runman
{
    public class BoxCollider : GameObject
    {
        private GameObject owner;
        public Rectangle Rectangle { get; private set; }
        
        public BoxCollider(GameObject gameObject)
        {
            owner = gameObject;
            Rectangle = new Rectangle(owner.Position.X, 
                owner.Position.Y, 
                owner.GraphicImage.Width,
                owner.GraphicImage.Height);
        }

        public override void Update()
        {
            Rectangle = new Rectangle(owner.Position.X, 
                owner.Position.Y, 
                owner.GraphicImage.Width,
                owner.GraphicImage.Height);
        }
    }
}