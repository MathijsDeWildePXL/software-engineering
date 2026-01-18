using System;

namespace SolidDemos.SRP
{
    public class MeterStream : IDisposable
    {
        private string _meterType;

        public MeterStream(string meterType)
        {
            _meterType = meterType;
        }

        public void Dispose()
        {
            //TODO
        }

        internal int ReadByte()
        {
            return 0; //TODO
        }
    }
}