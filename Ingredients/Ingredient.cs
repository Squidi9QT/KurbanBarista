using KurbanBarista.Element;

namespace KurbanBarista.Ingredients;

// пока пусто

public abstract class Ingredient : IElement
{
    protected Ingredient (string name, double weight, double temp)
    {
        Name = name;
        Weight = weight;
        Temp = temp;
    }

    public string Name {get; protected set;}
    public double Weight {get; set;}
    public double Temp {get; set;}
    public virtual string DisplayName => $"{Name} ({Weight} г., {Temp}°C)";
}