using System;
using ShippingCalculator.Model;

namespace ShippingCalculator.Before
{
    class ShippingCalculatorService
    {
        public ShippingCalculatorService()
        {
        }

        public double Calculate(Order order)
        {
            switch (order.ShippingMethod)
            {
                case ShippingOptions.BPost:
                    return CalculateForBPost(order);

                case ShippingOptions.UPS:
                    return CalculateForUPS(order);

                case ShippingOptions.PostNL:
                    return CalculateForPostNL(order);

                default:
                    throw new UnknownOrderShippingMethodException();

            }
        }

        private double CalculateForPostNL(Order order)
        {
            return 3.50;
        }

        private double CalculateForUPS(Order order)
        {
            return 4.25;
        }

        private double CalculateForBPost(Order order)
        {
            return 3.00;
        }
    }
}