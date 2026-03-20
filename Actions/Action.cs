using KurbanBarista.Drinks;

namespace KurbanBarista.Actions;

public abstract class Action : IElement
{
    public IElement TargetElement {get; private set;}

    protected Action(IElement targetElement)
    {
        TargetElement = targetElement;
    }

    public abstract string DisplayName {get;}
    public abstract void Execute(Drink drink);
}