using System;
using System.Collections.Generic;

namespace runman
{
    public class CollisonDetection
    {
        private List<BoxCollider> colliders = new List<BoxCollider>();

        public void RegisterBoxCollider(BoxCollider boxCollider)
        {
            colliders.Add(boxCollider);
        }

        public void DetectCollison()
        {
            foreach (BoxCollider box1 in colliders)
            {
                foreach (BoxCollider box2 in colliders)
                {
                    if (box1 != box2)
                    {
                        if (box1.Rectangle.X < box2.Rectangle.X + box2.Rectangle.Width &&
                            box1.Rectangle.X + box1.Rectangle.Width > box2.Rectangle.X &&
                            box1.Rectangle.Y < box2.Rectangle.Y + box2.Rectangle.Height &&
                            box1.Rectangle.Y + box1.Rectangle.Height > box2.Rectangle.Y) 
                        {
                            Console.WriteLine("Collison");
                        }
                    }
                }
            }
        }
        
    }
}