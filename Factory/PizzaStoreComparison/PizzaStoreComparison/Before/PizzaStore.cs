using System;

namespace PizzaStoreComparison.Before
{
    // PROBLEM: Direct instantiation - tight coupling, hard to extend
    
    public abstract class Pizza
    {
        public string Name { get; set; } = "";
        public string Dough { get; set; } = "";
        public string Sauce { get; set; } = "";

        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.WriteLine($"  Tossing dough: {Dough}");
            Console.WriteLine($"  Adding sauce: {Sauce}");
        }

        public void Bake()
        {
            Console.WriteLine("  Baking for 25 minutes at 350°");
        }

        public void Cut()
        {
            Console.WriteLine("  Cutting the pizza into diagonal slices");
        }

        public void Box()
        {
            Console.WriteLine("  Placing pizza in official PizzaStore box");
        }
    }

    public class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            Name = "Cheese Pizza";
            Dough = "Regular Crust";
            Sauce = "Marinara Pizza Sauce";
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza()
        {
            Name = "Pepperoni Pizza";
            Dough = "Crust";
            Sauce = "Marinara sauce";
        }
    }

    public class VeggiePizza : Pizza
    {
        public VeggiePizza()
        {
            Name = "Veggie Pizza";
            Dough = "Crust";
            Sauce = "Marinara sauce";
        }
    }

    // PROBLEM: PizzaStore is tightly coupled to concrete pizza classes
    public class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            // ❌ Direct instantiation - violates Open/Closed Principle
            if (type == "cheese")
                pizza = new CheesePizza();
            else if (type == "pepperoni")
                pizza = new PepperoniPizza();
            else if (type == "veggie")
                pizza = new VeggiePizza();
            else
                throw new ArgumentException("Unknown pizza type");

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }

    // Problems:
    // ❌ Adding new pizza types requires modifying PizzaStore
    // ❌ Can't easily have different pizza styles (NY, Chicago)
    // ❌ Tight coupling between store and concrete pizza classes
}
