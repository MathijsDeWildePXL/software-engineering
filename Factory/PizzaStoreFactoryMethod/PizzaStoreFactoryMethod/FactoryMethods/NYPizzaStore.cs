using PizzaStoreFactoryMethod.FactoryMethods.Abstractions;
using PizzaStoreFactoryMethod.Pizzas.Abstractions;
using PizzaStoreFactoryMethod.Products.Pizzas;

namespace PizzaStoreFactoryMethod.FactoryMethods;

public class NYPizzaStore : PizzaStore
{
    protected override Pizza? CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new NYStyleCheesePizza(),
            "pepperoni" => new NYStylePepperoniPizza(),
            _ => null
        };
    }
}
