using System;
using Explorer700Library;

namespace runman
{
    public class InputHandler
    {
        private Explorer700 explorer700;

        public delegate void InputEventHandler(object source, string args);
        public event InputEventHandler ReceiveInput;

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
                this.CenterKeyPressed();
            }
            else if (key.Keys == Keys.Up)
            {
                this.UpKeyPressed();
            }
            else if (key.Keys == Keys.Right)
            {
                this.RightKeyPressed();
            }
        }

        //HandleEvent - Center Key Pressed
        private void CenterKeyPressed()
        {
            //Shutting down the Mainframe :)
            explorer700.Buzzer.Beep(1000);
            explorer700.Led1.Enabled = false;
            explorer700.Led2.Enabled = false;
            explorer700.Display.Clear();

            //Fire Event To Subscribers
            ReceiveInput?.Invoke(this, "Reset");


            Console.WriteLine("Center Key Pressed: Event Fired");
        }


        //HandleEvent - Up Key Pressed
        private void UpKeyPressed()
        {
            //Fire Event to Runman
            ReceiveInput?.Invoke(this, "Jump");

            Console.WriteLine("Up Key Pressed: Event Fired");

        }


        //HandleEvent - Right Key Pressed
        private void RightKeyPressed()
        {
            //Fire Event to Subscribers
            ReceiveInput?.Invoke(this, "Start");

            Console.WriteLine("Right Key Pressed: Event Fired");

        }
    }
}
