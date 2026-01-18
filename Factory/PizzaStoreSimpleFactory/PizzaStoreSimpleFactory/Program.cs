// See https://aka.ms/new-console-template for more information
using PizzaStoreSimpleFactory;
using PizzaStoreSimpleFactory.Pizzas.Abstractions;

PizzaStore store = new PizzaStore();
Pizza pizza = store.OrderPizza("cheese");
Console.WriteLine($"We ordered a {pizza.Name}");

pizza = store.OrderPizza("pepperoni");
Console.WriteLine($"We ordered a {pizza.Name}");
