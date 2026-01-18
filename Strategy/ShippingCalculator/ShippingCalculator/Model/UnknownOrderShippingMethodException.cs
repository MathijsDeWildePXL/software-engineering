using System;
using System.Runtime.Serialization;

namespace ShippingCalculator.Model
{
    [Serializable]
    class UnknownOrderShippingMethodException : Exception
    {
        public UnknownOrderShippingMethodException()
        {
        }

        public UnknownOrderShippingMethodException(string message) : base(message)
        {
        }

        public UnknownOrderShippingMethodException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownOrderShippingMethodException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}