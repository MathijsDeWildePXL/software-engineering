using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasLights;

enum XMasLightState
{
    POWER_ON, POWER_OFF, BLINKING, STARLIGHT, WAVE, ALL_ON
}
public class XMasLight
{
    private XMasLightState _state;

    public XMasLight()
    {
        _state = XMasLightState.POWER_OFF;
        Console.WriteLine("*** PXL XMas lights 1.0 ***");
        printState(_state);
        Console.WriteLine();
    }

    public void SwitchPowerOn()
    {
        if (_state == XMasLightState.POWER_OFF)
        {
            _state = XMasLightState.POWER_ON; printState(_state); Console.WriteLine();
            _state = XMasLightState.ALL_ON; printState(_state); Console.WriteLine();
        }
    }

    public void PushMode()
    {
        Console.Write("switch from ... ");
        printState(_state);
        Console.Write(" to ");

        switch (_state)
        {
            case XMasLightState.ALL_ON:
                _state = XMasLightState.BLINKING;
                break;
            case XMasLightState.BLINKING:
                _state = XMasLightState.STARLIGHT;
                break;
            case XMasLightState.STARLIGHT:
                _state = XMasLightState.WAVE;
                break;
            case XMasLightState.WAVE:
                _state = XMasLightState.ALL_ON;
                break;
            default:
                Console.WriteLine("YOU CAN'T SWITCH MODE");
                break;
        }

        printState(_state);
        Console.WriteLine();
    }

    public void SwitchPowerOff()
    {
        _state = XMasLightState.POWER_OFF; printState(_state); Console.WriteLine();
    }

    private void printState(XMasLightState state)
    {
        switch (state)
        {
            case XMasLightState.POWER_ON:
                Console.Write("Power On!");
                break;
            case XMasLightState.POWER_OFF:
                Console.Write("Power Off!");
                break;
            case XMasLightState.BLINKING:
                Console.Write("Blinking lights!");
                break;
            case XMasLightState.STARLIGHT:
                Console.Write("Starlight!");
                break;
            case XMasLightState.WAVE:
                Console.Write("Wave pattern!");
                break;
            case XMasLightState.ALL_ON:
                Console.Write("All lights are on!");
                break;
            default:
                Console.Write("Error: unknown state");
                break;
        }
    }
}
