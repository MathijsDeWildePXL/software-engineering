using ShippingCalculator.Before;   // Before refactoring
// using ShippingCalculator.After; // After refactoring
using ShippingCalculator.Model;

namespace ShippingCalculator;

class Program
{
    static void Main(string[] args)
    {
        var shippingCalculatorService = new ShippingCalculatorService();
        ShippingViaUPSCosts425(shippingCalculatorService);
        ShippingViaBPostCosts300(shippingCalculatorService);
        ShippingViaPostNLCosts350(shippingCalculatorService);
        Console.ReadKey(); // wait to terminate console
    }

    private static void ShippingViaPostNLCosts350(ShippingCalculatorService shippingCalculatorService)
    {
        var order = new Order();
        order.Origin = CreateOriginAddress();
        order.Destination = CreateDestinationAddress();
        order.ShippingMethod = ShippingOptions.PostNL;

        Console.WriteLine($"Shipping via PostNL kost: {shippingCalculatorService.Calculate(order):0.00}");
    }

    private static void ShippingViaBPostCosts300(ShippingCalculatorService shippingCalculatorService)
    {
        var order = new Order();
        order.Origin = CreateOriginAddress();
        order.Destination = CreateDestinationAddress();
        order.ShippingMethod = ShippingOptions.BPost;

        Console.WriteLine($"Shipping via BPost kost: {shippingCalculatorService.Calculate(order):0.00}");
    }

    private static void ShippingViaUPSCosts425(ShippingCalculatorService shippingCalculatorService)
    {
        var order = new Order();
        order.Origin = CreateOriginAddress();
        order.Destination = CreateDestinationAddress();
        order.ShippingMethod = ShippingOptions.UPS;

        Console.WriteLine($"Shipping via UPS kost: {shippingCalculatorService.Calculate(order):0.00}");
    }

    private static Address CreateDestinationAddress()
    {
        return new Address
        {
            ContactName = "Fran Pepper",
            AddressLine1 = "Elfde-Liniestraat 24",
            City = "Hasselt",
            PostalCode = "3500",
            Country = "BE",
            Region = "Limburg"
        };
    }

    private static Address CreateOriginAddress()
    {
        return new Address
        {
            ContactName = "Samson",
            AddressLine1 = "De Pannelaan 68",
            City = "De Panne",
            PostalCode = "8660",
            Country = "BE",
            Region = "West-Vlaanderen"
        };
    }
}
