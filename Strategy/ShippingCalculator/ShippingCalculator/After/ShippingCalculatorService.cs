using System;
using ShippingCalculator.Model;

namespace ShippingCalculator.After
{
    // Strategy Pattern Implementation
    
    // Strategy Interface
    public interface IShippingStrategy
    {
        double Calculate(Order order);
    }

    // Concrete Strategies
    public class BPostShipping : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 3.00;
        }
    }

    public class UPSShipping : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 4.25;
        }
    }

    public class PostNLShipping : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 3.50;
        }
    }

    // Context - uses strategy
    public class ShippingCalculatorService
    {
        private readonly Dictionary<ShippingOptions, IShippingStrategy> _strategies;

        public ShippingCalculatorService()
        {
            // Initialize strategies
            _strategies = new Dictionary<ShippingOptions, IShippingStrategy>
            {
                { ShippingOptions.BPost, new BPostShipping() },
                { ShippingOptions.UPS, new UPSShipping() },
                { ShippingOptions.PostNL, new PostNLShipping() }
            };
        }

        public double Calculate(Order order)
        {
            if (_strategies.TryGetValue(order.ShippingMethod, out var strategy))
            {
                return strategy.Calculate(order);
            }
            
            throw new UnknownOrderShippingMethodException();
        }

        // Alternative approach: allow setting strategy dynamically
        public double CalculateWithStrategy(Order order, IShippingStrategy strategy)
        {
            return strategy.Calculate(order);
        }
    }

    // Benefits:
    // ✅ Easy to add new shipping methods (just create new strategy class)
    // ✅ No switch statement - follows Open/Closed Principle
    // ✅ Each shipping method encapsulated in its own class
    // ✅ Strategies are interchangeable at runtime
}
