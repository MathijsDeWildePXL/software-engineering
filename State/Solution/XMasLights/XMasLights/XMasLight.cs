using System;

namespace XMasLights.States
{
    // State Pattern Implementation - AFTER Refactoring
    
    // State Interface
    public interface ILightState
    {
        void SwitchPowerOn();
        void SwitchPowerOff();
        void PushMode();
        string GetStateName();
    }

    // Context - XMasLight
    public class XMasLight
    {
        public ILightState PowerOffState { get; }
        public ILightState PowerOnState { get; }
        public ILightState AllOnState { get; }
        public ILightState BlinkingState { get; }
        public ILightState StarlightState { get; }
        public ILightState WaveState { get; }

        public ILightState CurrentState { get; set; }

        public XMasLight()
        {
            PowerOffState = new PowerOffState(this);
            PowerOnState = new PowerOnState(this);
            AllOnState = new AllOnState(this);
            BlinkingState = new BlinkingState(this);
            StarlightState = new StarlightState(this);
            WaveState = new WaveState(this);

            CurrentState = PowerOffState;
            Console.WriteLine("*** PXL XMas lights 1.0 (State Pattern) ***");
            PrintState();
            Console.WriteLine();
        }

        public void SwitchPowerOn() => CurrentState.SwitchPowerOn();
        public void SwitchPowerOff() => CurrentState.SwitchPowerOff();
        public void PushMode() => CurrentState.PushMode();

        public void PrintState()
        {
            Console.Write(CurrentState.GetStateName());
        }
    }

    // Concrete States
    public class PowerOffState : ILightState
    {
        private readonly XMasLight _light;

        public PowerOffState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            _light.CurrentState = _light.PowerOnState;
            _light.PrintState();
            Console.WriteLine();
            _light.CurrentState = _light.AllOnState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void SwitchPowerOff()
        {
            Console.WriteLine("Already powered off!");
        }

        public void PushMode()
        {
            Console.WriteLine("YOU CAN'T SWITCH MODE - Power is off!");
        }

        public string GetStateName() => "Power Off!";
    }

    public class PowerOnState : ILightState
    {
        private readonly XMasLight _light;

        public PowerOnState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            Console.WriteLine("Already powered on!");
        }

        public void SwitchPowerOff()
        {
            _light.CurrentState = _light.PowerOffState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void PushMode()
        {
            Console.WriteLine("Transitioning to default mode...");
            _light.CurrentState = _light.AllOnState;
        }

        public string GetStateName() => "Power On!";
    }

    public class AllOnState : ILightState
    {
        private readonly XMasLight _light;

        public AllOnState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            Console.WriteLine("Already powered on!");
        }

        public void SwitchPowerOff()
        {
            _light.CurrentState = _light.PowerOffState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void PushMode()
        {
            Console.Write("switch from ... ");
            _light.PrintState();
            Console.Write(" to ");
            _light.CurrentState = _light.BlinkingState;
            _light.PrintState();
            Console.WriteLine();
        }

        public string GetStateName() => "All lights are on!";
    }

    public class BlinkingState : ILightState
    {
        private readonly XMasLight _light;

        public BlinkingState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            Console.WriteLine("Already powered on!");
        }

        public void SwitchPowerOff()
        {
            _light.CurrentState = _light.PowerOffState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void PushMode()
        {
            Console.Write("switch from ... ");
            _light.PrintState();
            Console.Write(" to ");
            _light.CurrentState = _light.StarlightState;
            _light.PrintState();
            Console.WriteLine();
        }

        public string GetStateName() => "Blinking lights!";
    }

    public class StarlightState : ILightState
    {
        private readonly XMasLight _light;

        public StarlightState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            Console.WriteLine("Already powered on!");
        }

        public void SwitchPowerOff()
        {
            _light.CurrentState = _light.PowerOffState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void PushMode()
        {
            Console.Write("switch from ... ");
            _light.PrintState();
            Console.Write(" to ");
            _light.CurrentState = _light.WaveState;
            _light.PrintState();
            Console.WriteLine();
        }

        public string GetStateName() => "Starlight!";
    }

    public class WaveState : ILightState
    {
        private readonly XMasLight _light;

        public WaveState(XMasLight light)
        {
            _light = light;
        }

        public void SwitchPowerOn()
        {
            Console.WriteLine("Already powered on!");
        }

        public void SwitchPowerOff()
        {
            _light.CurrentState = _light.PowerOffState;
            _light.PrintState();
            Console.WriteLine();
        }

        public void PushMode()
        {
            Console.Write("switch from ... ");
            _light.PrintState();
            Console.Write(" to ");
            _light.CurrentState = _light.AllOnState;
            _light.PrintState();
            Console.WriteLine();
        }

        public string GetStateName() => "Wave pattern!";
    }
}
