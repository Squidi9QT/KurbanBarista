using System.Linq.Expressions;
using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;

namespace KurbanBarista.Actions;

public class WhipAction : Action
{
     public WhipAction(Milk milk) : base(milk){}

    public override string DisplayName => $"Взбить: {TargetElement.DisplayName}";
    public override void Execute(Drink drink)
    {
        if (TargetElement is Milk milk)
        {
            Console.WriteLine($"[Действие] Взбиваем молоко капучинатором в густую пену...");
            milk.IsWhipped = true;
        }
    }
}
