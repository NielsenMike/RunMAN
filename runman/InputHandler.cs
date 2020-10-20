using System;
using Explorer700Library;

namespace runman
{
    public class InputHandler
    {
        private Explorer700 explorer700;
        public delegate void InputKeyPressed();
        public event InputKeyPressed JumpEvent;
        public event InputKeyPressed StopEvent;
        public event InputKeyPressed StartEvent;

        public InputHandler(Explorer700 exp)
        {
            explorer700 = exp;
            explorer700.Joystick.JoystickChanged += HandleEvent;
        }

        //HandleEventGeneral
        private void HandleEvent(object sender, KeyEventArgs key)
        {
            if(key.Keys == Keys.Center)
            {
                StopEvent?.Invoke();
            }
            else if (key.Keys == Keys.Up)
            {
                JumpEvent?.Invoke();
            }
            else if (key.Keys == Keys.Right)
            {
                StartEvent?.Invoke();
            }
        }
    }
}
