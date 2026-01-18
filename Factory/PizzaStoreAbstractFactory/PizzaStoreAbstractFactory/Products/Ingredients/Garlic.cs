using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class Garlic : IVeggies
{
    public string toString()
    {
        return "Garlic";
    }
}
