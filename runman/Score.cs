using System;
using System.Diagnostics;
namespace runman

{
    public class Score
    {
        private long scorevalue;
        private Stopwatch Timer;

        public Score()
        {
            Timer = Stopwatch.StartNew();
            scorevalue = 0;
        }

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

        public void StartScore()
        {
            Timer.Start();
        }

        public void PrintScore()
        {
            Timer.Stop();
            scorevalue = Timer.ElapsedMilliseconds;
            scorevalue = scorevalue / 100;
            Console.WriteLine("Final Score was: " + Scorevalue + ". Congratulations!");
            scorevalue = 0;
            Timer.Reset();
        }
    }
}
