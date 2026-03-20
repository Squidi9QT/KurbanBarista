namespace KurbanBarista.Ingredients;

public sealed class CoffeeBean : Ingredient
{
    public CoffeeBean (double weight) : base ("Кофе", weight, 22){}
    public bool IsGround {get; set;} = false;
    public override string DisplayName => IsGround
        ? $"{Name} ({Weight} г.) [Перемолото]"
        : $"{Name} ({Weight} г.) [В зернах]";
}