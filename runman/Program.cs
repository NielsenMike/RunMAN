using System.Drawing;
using System.IO;
using System.Reflection;
using Explorer700Library;

namespace runman
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("runman.Ressources.background.png");
            Image image = Image.FromStream(imageStream);
            
            
            Explorer700 explorer700 = new Explorer700();

            explorer700.Display.Update();
            explorer700.Display.Graphics.DrawImage(image, new Point(128,64));
            explorer700.Display.Update();
        }
    }
}