using System;

namespace BridgePattern
{
    // Abstract Implementor
    public interface ILedTV
    {
        void SwitchOn();
        void SwitchOff();
        void SetChannel(byte number);
    }

    // Concrete Implementor A
    public class SamsungLedTV : ILedTV
    {
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Samsung: Switch Off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Samsung: Switch On");
        }
    }

    // Concrete Implementor B
    public class SonyLedTV : ILedTV
    {
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Sony: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Sony: Switch Off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Sony: Switch On");
        }
    }

    // Abstraction
    public abstract class AbstractRemoteControl
    {
        // Implementor
        protected ILedTV ledTv;

        protected AbstractRemoteControl(ILedTV ledTv)
        {
            this.ledTv = ledTv;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(byte channelNumber);
    }

    public class InfraredRemoteControl : AbstractRemoteControl
    {
        public InfraredRemoteControl(ILedTV ledTv) : base(ledTv)
        {
        }

        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }
        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }
        public override void SetChannel(byte channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }

    public class BluetoothRemoteControl : AbstractRemoteControl
    {
        public BluetoothRemoteControl(ILedTV ledTv) : base(ledTv)
        {
        }

        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }
        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }
        public override void SetChannel(byte channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }
}
