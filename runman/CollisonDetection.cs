using System;
using System.Collections.Generic;

namespace runman
{
    public class CollisonDetection
    {
        public delegate void OnCollison(GameObject boxCollider, GameObject other);
        
        public event OnCollison CollisionEvent;
        
        public List<BoxCollider> Colliders { get;}

        public CollisonDetection()
        {
            Colliders = new List<BoxCollider>();
        }

        public void RegisterBoxCollider(BoxCollider boxCollider)
        {
            Colliders.Add(boxCollider);
        }

        public void DetectCollison()
        {
            foreach (BoxCollider box1 in Colliders.ToArray())
            {
                foreach (BoxCollider box2 in Colliders.ToArray())
                {
                    if (box1 != box2)
                    {
                        if (box1.Rectangle.X < box2.Rectangle.X + box2.Rectangle.Width &&
                            box1.Rectangle.X + box1.Rectangle.Width > box2.Rectangle.X &&
                            box1.Rectangle.Y < box2.Rectangle.Y + box2.Rectangle.Height &&
                            box1.Rectangle.Y + box1.Rectangle.Height > box2.Rectangle.Y) 
                        {
                            CollisionEvent?.Invoke(box1.owner, box2.owner);
                        }
                    }
                }
            }
        }
        
    }
}