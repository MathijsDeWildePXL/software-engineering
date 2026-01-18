using System;
using SolidDemos.SRP;

namespace SolidDemos.SRP.Before
{
    public class OxygenMeter
    {
        public double OxygenSaturation { get; set; }

        public void ReadOxygenLevel()
        {
            using (MeterStream ms = new MeterStream("O2"))
            {
                int raw = ms.ReadByte();
                OxygenSaturation = (double)raw / 255 * 100;
            }
        }

        public bool OxygenLow()
        {
            return OxygenSaturation <= 75;
        }

        public void ShowLowOxygenAlert()
        {
            Console.WriteLine($"Oxygen low ({OxygenSaturation:F1}%)");
        }
    }
}
