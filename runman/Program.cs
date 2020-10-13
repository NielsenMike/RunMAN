using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using Explorer700Library;
using Unosquare.WiringPi;

namespace runman
{
    class Program
    {
        static void Main(string[] args)
        {
            var resNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            
            Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("runman.res.background.png");
            Image image = Image.FromStream(imageStream);

            Explorer700 explorer700 = new Explorer700();
            
            
            if(image == null)
                Console.WriteLine("is null");

            explorer700.Display.Update();
            explorer700.Display.Graphics.DrawImage(image, new Point(0,0));
            explorer700.Display.Graphics.DrawString("Hello",new Font(new FontFamily("arial"), 8, FontStyle.Regular), Brushes.Chocolate, new PointF(5, 50));
            explorer700.Display.Update();
            
            Thread.Sleep(1000);
            explorer700.Display.Clear();
        }
    }
}