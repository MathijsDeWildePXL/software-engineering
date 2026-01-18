using PizzaStoreSimpleFactory.Pizzas.Abstractions;
using PizzaStoreSimpleFactory.Pizzas;

namespace PizzaStoreSimpleFactory;

public class PizzaStore
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza;

        if (type == "cheese")
            pizza = new CheesePizza();
        else if (type == "pepperoni")
            pizza = new PepperoniPizza();
        else
            throw new ArgumentException("Unknown pizza type");

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}
