namespace CoffeMachineApp.Domian.Ingredients;

public sealed class CoffeeBean : Ingredient
{
    public CoffeeBean (double weight) : base ("Кофейные зерна", weight){}
    public bool IsGround {get; set;} = false;
    public override string DisplayName => IsGround
        ? $"{Name} ({Weight} г.) [Перемолото]"
        : $"{Name} ({Weight} г.) [В зернах]";
}