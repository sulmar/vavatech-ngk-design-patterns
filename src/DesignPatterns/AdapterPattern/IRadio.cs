using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    // Abstract adapter
    public interface IRadioAdapter
    {
        void Send(byte channel, string message);
    }

    // Concrete adapter
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private MotorolaRadio radio;

        private string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();

            this.pincode = pincode;
        }

        public void Send(byte channel, string message)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }
    }

    // Concrete adapter
    public class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(byte channel, string message)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }
}
