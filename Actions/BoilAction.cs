using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;

namespace KurbanBarista.Actions;

public class BoilAction : Action
{
    public BoilAction(Water water) : base (water){}
    public override string DisplayName => $"Вскипятить: {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
        if (TargetElement is Water water)
        {
            Console.WriteLine($"[Действие] Нагреваем воду до кипения...");
            water.Temp = 100;
        }
    }
}
