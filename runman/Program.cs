using System;
using System.Drawing;
using System.Threading;
using Explorer700Library;
using Unosquare.WiringPi;

namespace runman
{
    class Program
    {
        static void Main(string[] args)
        {
            Explorer700 explorer700 = new Explorer700();
            Image background = Image.FromFile("/res/background.png");
            
            explorer700.Display.Update();
            explorer700.Display.Graphics.DrawImage(background, new Point(128,64));
            explorer700.Display.Update();
        }
    }
}