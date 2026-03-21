using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;

namespace KurbanBarista.Actions;

public class  AddAction : Action
{
    public AddAction(Ingredient ingredient) : base(ingredient){}

    public override string DisplayName => $"Добавить: {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
        if (TargetElement is Ingredient ingredient)
        {
            Console.WriteLine($"[Действие] Добавляем {ingredient.Name} в чашку...");
            drink.AddIngredient(ingredient);
        }
    }
}