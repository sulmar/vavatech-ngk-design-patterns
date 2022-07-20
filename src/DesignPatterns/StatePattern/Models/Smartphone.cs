using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Models
{
    public class Smartphone
    {
        public PhoneState state { get; set; }

        public void PressPowerOnButton()
        {
            if (state == PhoneState.Off)
            {
                state = PhoneState.On;
                return;
            }

            if (state == PhoneState.On)
            {
                state = PhoneState.Standby;
            }

            if (state == PhoneState.Standby)
            {
                state = PhoneState.Off;
            }
        }

        public void PressHomeButton()
        {            
            if (state == PhoneState.On)
            {
                Console.WriteLine("Hello");
                return;
            }

            if (state == PhoneState.Standby)
            {
                Console.WriteLine("Resume");                
            }
        }
    }

    // Abstract state
    public abstract class State
    {
        protected Smartphone phone;

        public abstract void PressPowerOnButton();
        public abstract void PressHomeButton();
    }

    public class OnState : State
    {
        public override void PressHomeButton()
        {
            throw new NotImplementedException();
        }

        public override void PressPowerOnButton()
        {
            phone.state = PhoneState.Standby;
        }
    }

    public enum PhoneState
    {
        On,
        Off,
        Standby
    }
}
