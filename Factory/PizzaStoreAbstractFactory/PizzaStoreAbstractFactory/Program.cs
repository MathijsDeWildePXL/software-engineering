using PizzaStoreAbstractFactory;
using PizzaStoreAbstractFactory.Products.Pizzas;

PizzaStore nyStore = new NYPizzaStore();

Pizza pizza = nyStore.OrderPizza("cheese");
Console.WriteLine($"Ethan ordered a {pizza.Name}\n");
