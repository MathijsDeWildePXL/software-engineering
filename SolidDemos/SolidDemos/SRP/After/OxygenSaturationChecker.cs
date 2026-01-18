namespace SolidDemos.SRP.After
{
    public class OxygenSaturationChecker
    {
        public bool OxygenLow(OxygenMeter meter)
        {
            return meter.OxygenSaturation <= 75;
        }
    }
}
