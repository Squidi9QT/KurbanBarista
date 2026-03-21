using KurbanBarista.Drinks;

namespace KurbanBarista.Actions;

public class MixAction : Action
{
    public MixAction(IElement targetElement) : base(targetElement){}
    public override string DisplayName => $"Перемешать с {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
       Console.WriteLine($"[Действие...] Перемешываем напиток");

       if (drink.CurrentTemp > 30)
        {
            drink.HeatUp(drink.CurrentTemp - 2);
        }
    }
}