using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory;

public class SlicedPepperoni : IPepperoni
{
    public string toString()
    {
        return "Sliced Pepperoni";
    }
}
