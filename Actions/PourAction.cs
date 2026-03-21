using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;

namespace KurbanBarista.Actions;

public class PourAction : Action
{
    public PourAction(Water water) : base(water){}
    public override string DisplayName =>$"Пролить: {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
        if(TargetElement is Water water)
        {
            Console.WriteLine($"[Действие...] Проливаем воду ({water.Temp}°C)");
            drink.AddIngredient(water);
        }
    }
}
