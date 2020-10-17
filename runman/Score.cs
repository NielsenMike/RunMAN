using System;
namespace runman
{
    public class Score
    {
        public Score(InputHandler inputHandler)
        {
            inputHandler.ReceiveInput += HandleEvent;
        }


        private void HandleEvent(object source, string args)
        {

        }
    }
}
