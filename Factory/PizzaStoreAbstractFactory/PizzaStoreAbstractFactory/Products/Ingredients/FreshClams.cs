using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class FreshClams : IClams
{
    public string toString()
    {
        return "Fresh Clams from Long Island Sound";
    }
}
