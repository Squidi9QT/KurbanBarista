using KurbanBarista.Element;
using KurbanBarista.Drinks;

namespace KurbanBarista.Actions;

public abstract class Actions : IElement
{
    public IElement TargetElement {get; private set;}

    protected Actions(IElement targetElement)
    {
        TargetElement = targetElement;
    }

    public abstract string DisplayName {get;}
    public abstract void Execute(Drink drink);
}