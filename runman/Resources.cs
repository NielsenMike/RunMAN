using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace runman
{
    public class Resources
    {

        private Dictionary<String, Image> resourceDictionary;

        public Resources()
        {
            resourceDictionary = new Dictionary<string, Image>();
        }

        public Image GetResource(String id)
        {
            Image image = resourceDictionary[id];
            return image;
        }
        
        public bool Load(String filename, String id)
        {
            Stream imageStream = 
                Assembly.GetExecutingAssembly().GetManifestResourceStream("runman.res." + filename);
            Image image = Image.FromStream(imageStream);
            if (image == null)
            {
                Console.WriteLine("WARNING: Resources:Load - Could not load image: " + filename);
                return false;
            }
            resourceDictionary.Add(id, image);
            return true;
        }
    }
}