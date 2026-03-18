using KurbanBarista.Domian.Element;
using KurbanBarista;
using KurbanBarista.Drinks;

namespace KurbanBarista.Actions;

public abstract class Actions : IElement
{
    public abstract string DisplayName {get;}
    public abstract void Execute(Drink drink);
}