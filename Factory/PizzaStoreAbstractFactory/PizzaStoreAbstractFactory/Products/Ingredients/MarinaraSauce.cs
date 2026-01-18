using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class MarinaraSauce : ISauce
{
    public string toString()
    {
        return "Marinara Sauce";
    }
}
