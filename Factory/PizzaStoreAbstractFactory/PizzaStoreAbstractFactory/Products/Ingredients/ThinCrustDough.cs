using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class ThinCrustDough : IDough
{
    public string toString()
    {
        return "Thin Crust Dough";
    }
}
