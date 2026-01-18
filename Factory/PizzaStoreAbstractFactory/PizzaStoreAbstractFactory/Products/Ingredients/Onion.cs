using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class Onion : IVeggies
{
    public string toString()
    {
        return "Onion";
    }
}
