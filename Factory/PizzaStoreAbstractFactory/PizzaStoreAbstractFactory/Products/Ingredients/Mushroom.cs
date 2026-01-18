using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class Mushroom : IVeggies
{
    public string toString()
    {
        return "Mushroom";
    }
}
