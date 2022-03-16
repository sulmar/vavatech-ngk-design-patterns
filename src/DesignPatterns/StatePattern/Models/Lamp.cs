using Stateless;
using System;
using System.Diagnostics;
using System.Timers;

namespace StatePattern
{
    // PM> Install-Package Stateless
    // https://github.com/dotnet-state-machine/stateless

    public class Lamp
    {
        public LampState State
        {
            get
            {
                return stateMachine.State;
            }
        }

        private StateMachine<LampState, LampTrigger> stateMachine;

        private Timer timer;

       
        // http://www.webgraphviz.com
        // https://dreampuf.github.io/GraphvizOnline

        public string Graph => Stateless.Graph.UmlDotGraph.Format(stateMachine.GetInfo());

        public Lamp()
        {
            stateMachine = new StateMachine<LampState, LampTrigger>(LampState.Off);

            stateMachine.Configure(LampState.Off)
                .Permit(LampTrigger.PushDown, LampState.On);

            stateMachine.Configure(LampState.On)
                .OnEntry(() => StartTimer(), "StartTimer")
                .Permit(LampTrigger.PushUp, LampState.Off)
                .Permit(LampTrigger.TimeElapsed, LampState.Off)
                .Permit(LampTrigger.PushDown, LampState.Blinking)
                .OnExit(() => StopTimer(), "StopTimer");

            stateMachine.Configure(LampState.Blinking)
                .Ignore(LampTrigger.PushDown)
                .Permit(LampTrigger.PushUp, LampState.On)
                .Permit(LampTrigger.TimeElapsed, LampState.Off);


            stateMachine.OnTransitioned(t => Trace.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination}"));

            SetTimer();
        }

        private void StartTimer() => timer.Enabled = true;
        private void StopTimer() => timer.Enabled = false;

        private void SetTimer()
        {
            timer = new Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            stateMachine.Fire(LampTrigger.TimeElapsed);
        }

        public void PushDown() => stateMachine.Fire(LampTrigger.PushDown);
        public bool CanPushDown => stateMachine.CanFire(LampTrigger.PushDown);


        public void PushUp()
        {
            stateMachine.Fire(LampTrigger.PushUp);
        }

        public bool CanPushUp => stateMachine.CanFire(LampTrigger.PushUp);

        public enum LampTrigger
        {
            PushDown,
            PushUp,
            TimeElapsed
        }

        public enum LampState
        {
            On,
            Off,
            Blinking
        }

    }

}
