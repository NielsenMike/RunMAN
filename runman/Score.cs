using System;
using System.Diagnostics;
namespace runman

{
    public class Score
    {
        InputHandler handler;
        private long scorevalue = 0;
        Stopwatch Timer = new Stopwatch();

        public long Scorevalue {
            set
            {
                scorevalue = value;
            }
            get
            {
                return scorevalue;
            }
        }

        public Score()
        {
            handler.ReceiveInput += HandleEvent;
        }

        public void HandleEvent(object source, string arg)
        {
            if(arg == "Start")
            {
                UpdateScore();
            }
            if(arg == "Reset")
            {
                PrintScore();
            }
        }

        public void UpdateScore()
        {
            Timer.Start();
        }

        public void PrintScore()
        {
            Timer.Stop();
            scorevalue = Timer.ElapsedMilliseconds;
            scorevalue = scorevalue / 100;
            Console.WriteLine("Final Score was: " + Scorevalue + ". Congratulations!");
        }
    }
}
