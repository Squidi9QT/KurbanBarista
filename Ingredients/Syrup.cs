namespace KurbanBarista.Ingredients;

public sealed class Syrup : Ingredient
{
    public Syrup (string flavor, double weight) : base($"Сироп '{flavor}'", weight, 22)
    {
        Flavor = flavor;
    }
    public string Flavor {get;}
}