using System;
using System.Threading;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Facade Pattern!");

            WashMachineTest();
        }

        private static void WashMachineTest()
        {
            IWashMachineFactory washMachineFactory = new WashMachineFactory();

            IWashMachine washMachine = new WashMachine(new Heater(), new Engine(), new Pump());
            
            washMachine.Start();
        }
    }

    public interface IWashMachineFactory
    {
        IWashMachine Create(WashKind kind);
    }

    public class WashMachineFactory : IWashMachineFactory
    {
        private void SportWashMachine(IWashMachine washMachine)
        {
            washMachine.SetTemperature(20);
            washMachine.SetRotationSpeed(1200);
            
        }

        private void EverydayWashMachine(IWashMachine washMachine)
        {
            washMachine.SetTemperature(30);
            washMachine.SetRotationSpeed(900);
            
        }

        public IWashMachine Create(WashKind kind)
        {
            IWashMachine washMachine = new WashMachine(new Heater(), new Engine(), new Pump());

            switch (kind)
            {
                case WashKind.Sport: SportWashMachine(washMachine); break;
                case WashKind.Everyday: EverydayWashMachine(washMachine); break;

            }

            return washMachine;
        }
    }

    public enum WashKind
    {
        Sport,
        Everyday
    }
}

// Facade
public interface IWashMachine
{
    void SetTemperature(byte temperature);
    void SetRotationSpeed(int rotationSpeed);
    void Start();
    void Stop();
}

public class WashMachine : IWashMachine
{
    public WashMachine(Heater heater, Engine engine, Pump pump)
    {
        Heater = heater;
        Engine = engine;
        Pump = pump;
        Locked = false;
    }

    public Heater Heater { get; set; }
    public Engine Engine { get; set; }
    public Pump Pump { get; set; }

    public bool Locked { get; set; }

    public void SetRotationSpeed(int rotationSpeed)
    {
        this.Engine.RotationSpeed = 200;
    }

    public void SetTemperature(byte temperature)
    {
        int maxTemp = 30;

        if (temperature > maxTemp)
        {
            Console.WriteLine($"Błąd - nastawiona temperaturę większą od {maxTemp} st. C");
            return;
        }

        this.Heater.Temperature = temperature;
    }

    public void Start()
    {
        // Włączenie blokady
        this.Locked = true;
        Console.WriteLine("Włączenie blokady");

        // pobiera wodę
        this.Pump.Direction = Direction.In;
        this.Pump.Start();

        Thread.Sleep(TimeSpan.FromSeconds(1));

        this.Pump.Stop();

        // podgrzewa wodę
        this.Heater.On();

        // obraca bęben 

        this.Engine.RotateRight();

        Thread.Sleep(TimeSpan.FromSeconds(1));

        this.Engine.RotateLeft();

        Thread.Sleep(TimeSpan.FromSeconds(1));

        Stop();


    }

    public void Stop()
    {
        // zakończenie cyklu prania

        this.Engine.Stop();
        this.Engine.RotationSpeed = 0;

        this.Heater.Off();

        // wypompowanie wody

        this.Pump.Direction = Direction.Out;
        this.Pump.Start();


        this.Pump.Stop();

        // Zwolnienie blokady
        this.Locked = false;
        Console.WriteLine("Zwolnienie blokady");


    }
}

public class Pump
{
    public bool Enabled { get; private set; }

    public Direction Direction { get; set; }


    public void Start()
    {
        Enabled = true;
        Console.WriteLine($"Pump started {Direction}");
    }

    public void Stop()
    {
        Enabled = false;
        Console.WriteLine("Pump stopped");
    }
}

public enum Direction
{
    In,
    Out
}

public class Engine
{
    public bool Running { get; private set; }

    public int RotationSpeed { get; set; }

    public void RotateRight()
    {
        Running = true;
        Console.WriteLine($"Engine rotating {RotationSpeed} right ");
    }

    public void RotateLeft()
    {
        Running = true;
        Console.WriteLine($"Engine rotating {RotationSpeed} left");
    }

    public void Stop()
    {
        Running = false;
        Console.WriteLine("Engine stopped");
    }
}

public class Heater
{
    private bool heating;

    public byte Temperature { get; set; }

    public void On()
    {
        heating = true;
        Console.WriteLine("Heater on");
    }

    public void Off()
    {
        heating = false;
        Console.WriteLine("Heater off");

    }


}

