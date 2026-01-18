using System;

namespace PizzaStoreComparison.After
{
    // SOLUTION: Factory Method Pattern - delegate object creation to subclasses
    
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

    // Abstract Creator - defines factory method
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            // ✅ Call factory method to create pizza
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        // Factory Method - subclasses implement this
        protected abstract Pizza CreatePizza(string type);
    }

    // Concrete Creators - NY Style
    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            return type switch
            {
                "cheese" => new NYStyleCheesePizza(),
                "pepperoni" => new NYStylePepperoniPizza(),
                "veggie" => new NYStyleVeggiePizza(),
                _ => throw new ArgumentException("Unknown pizza type")
            };
        }
    }

    // Concrete Creators - Chicago Style
    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            return type switch
            {
                "cheese" => new ChicagoStyleCheesePizza(),
                "pepperoni" => new ChicagoStylePepperoniPizza(),
                "veggie" => new ChicagoStyleVeggiePizza(),
                _ => throw new ArgumentException("Unknown pizza type")
            };
        }
    }

    // Concrete Products - NY Style Pizzas
    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            Name = "NY Style Pepperoni Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
        }
    }

    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            Name = "NY Style Veggie Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
        }
    }

    // Concrete Products - Chicago Style Pizzas
    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
        }

        public new void Cut()
        {
            Console.WriteLine("  Cutting the pizza into square slices");
        }
    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            Name = "Chicago Style Pepperoni Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
        }

        public new void Cut()
        {
            Console.WriteLine("  Cutting the pizza into square slices");
        }
    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            Name = "Chicago Style Veggie Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
        }

        public new void Cut()
        {
            Console.WriteLine("  Cutting the pizza into square slices");
        }
    }

    // Benefits:
    // ✅ Easy to add new pizza styles (just create new PizzaStore subclass)
    // ✅ Each store creates its own style of pizzas
    // ✅ Follows Open/Closed Principle
    // ✅ Decouples pizza creation from pizza usage
}
