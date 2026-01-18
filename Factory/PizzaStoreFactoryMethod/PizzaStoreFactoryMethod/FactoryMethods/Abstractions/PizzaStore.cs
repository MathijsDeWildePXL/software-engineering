using PizzaStoreFactoryMethod.Pizzas.Abstractions;

namespace PizzaStoreFactoryMethod.FactoryMethods.Abstractions;

public abstract class PizzaStore
{
    protected abstract Pizza? CreatePizza(string type);
    public Pizza? OrderPizza(string type)
    {
        var pizza = CreatePizza(type);
        if (pizza == null)
        {
            Console.WriteLine($"Sorry, we don't have {type} pizza.");
            return null;
        }
        Console.WriteLine($"--- Making a {pizza.Name} ---");
        
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}
