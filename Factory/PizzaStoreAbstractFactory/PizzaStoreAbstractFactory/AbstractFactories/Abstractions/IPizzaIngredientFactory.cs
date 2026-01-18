using PizzaStoreAbstractFactory.Products.Ingredients.Abstractions;

namespace PizzaStoreAbstractFactory.AbstractFactories.Abstractions;

public interface IPizzaIngredientFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ICheese CreateCheese();
    IVeggies[] CreateVeggies();
    IPepperoni CreatePepperoni();
    IClams CreateClam();
}