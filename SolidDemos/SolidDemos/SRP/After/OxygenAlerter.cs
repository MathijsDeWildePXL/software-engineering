using System;

namespace SolidDemos.SRP.After
{
    public class OxygenAlerter
    {
        public void ShowLowOxygenAlert(OxygenMeter meter)
        {
            Console.WriteLine($"Oxygen low ({meter.OxygenSaturation:F1}%)");
        }
    }
}
