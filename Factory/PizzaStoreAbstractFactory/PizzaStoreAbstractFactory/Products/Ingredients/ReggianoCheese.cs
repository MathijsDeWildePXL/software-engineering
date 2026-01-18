using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class ReggianoCheese : ICheese
{
    public string toString()
    {
        return "Reggiano Cheese";
    }
}
