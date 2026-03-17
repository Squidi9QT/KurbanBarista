namespace CoffeMachineApp.Domian.Ingredients;

public sealed class Syrup : Ingredient
{
    public Syrup (string flavor, double weight) : base($"Сироп '{flavor}'", weight)
    {
        Flavor = flavor;
    }
    public string Flavor {get;}
}