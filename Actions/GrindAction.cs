using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;

namespace KurbanBarista.Actions;

public class GrindAction : Action
{
    public GrindAction(CoffeeBean bean) : base(bean){}
    public override string DisplayName => $"Перемолоть: {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
        if (TargetElement is CoffeeBean bean)
        {
            Console.WriteLine($"[Действие] Кофемолка жужжит...");
            bean.IsGround = true;
        }
    }
}