using PizzaStoreFactoryMethod.FactoryMethods;
using PizzaStoreFactoryMethod.FactoryMethods.Abstractions;
using PizzaStoreFactoryMethod.Pizzas.Abstractions;

PizzaStore nyStore = new NYPizzaStore();
Pizza? pizza = nyStore.OrderPizza("cheese");
if (pizza != null)
{
    Console.WriteLine($"Ethan ordered a {pizza?.Name}.");
    Console.WriteLine();
}

pizza = nyStore.OrderPizza("pepperoni");
if (pizza != null)
{
    Console.WriteLine($"Joel ordered a {pizza?.Name}.");
    Console.WriteLine();
}

pizza = nyStore.OrderPizza("clam");
if (pizza != null)
{
    Console.WriteLine($"Joel ordered a {pizza?.Name}.");
    Console.WriteLine();
}  
