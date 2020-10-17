using System.Drawing;

namespace runman
{
    public class BoxCollider : Component
    {
        private GameObject owner;
        public Rectangle Rectangle { get; private set; }

        public BoxCollider(GameObject gameObject)
        {
            owner = gameObject;
            owner.Components.Add(this);
            Rectangle = new Rectangle(owner.Position.X, 
                owner.Position.Y, 
                owner.GraphicImage.Width,
                owner.GraphicImage.Height);
        }

        public void Update()
        {
            Rectangle = new Rectangle(owner.Position.X, 
                owner.Position.Y, 
                owner.GraphicImage.Width,
                owner.GraphicImage.Height);
        }
    }
}