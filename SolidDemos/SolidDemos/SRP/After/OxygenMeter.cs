namespace SolidDemos.SRP.After
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
    }
}
