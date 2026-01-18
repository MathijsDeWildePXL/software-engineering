using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class RedPepper : IVeggies
{
    public string toString()
    {
        return "Red Pepper";
    }
}
