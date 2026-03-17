using CoffeMachineApp.Domian.Element;

namespace CoffeMachineApp.Domian.Ingredients;

// пока пусто

public abstract class Ingredient : IElement
{
    protected Ingredient (string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name {get; protected set;}
    public double Weight {get; set;}
    public virtual string DisplayName => $"{Name} ({Weight} г.)";
}