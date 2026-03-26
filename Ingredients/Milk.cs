namespace KurbanBarista.Ingredients;

public sealed class Milk : Ingredient
{
    public Milk (double weight, bool isLactoseFree = false)
        : base(isLactoseFree ? "Бузлактозное молоко" : "Молоко", weight, 20)
    {
        IsLactoseFree = isLactoseFree;
    }

    public bool IsLactoseFree {get;}
    public bool IsWhipped {get; set;} = false;
    public override string DisplayName
    {
        get
        {
            string tempStatus = Temp > 40 ? "Горячее" : "Холодное";
            string foamStatus = IsWhipped ? "C пенкой" : "Без пенки";
            return $"{Name}({Weight} г.) [{tempStatus}, {foamStatus}]";
        }
    }

}