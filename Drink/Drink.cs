using KurbanBarista.Ingredients;
using KurbanBarista.Actions;

namespace KurbanBarista.Drinks;

public class Drink
{
    public string Name {get; set;} = "Пустая чашка";

    public List<Ingredient> Ingredients {get;} = new List<Ingredient>();
    public List<string> RecipeSteps {get;} = new List<string>();

    public double TotalWeight {get; private set;}
    public double CurrentTemp {get; private set;}
    public bool NeedsCustomName{get; private set;} = false;

    public void ApplyAction(KurbanBarista.Actions.Action action)
    {
        action.Execute(this);
        RecipeSteps.Add(action.DisplayName);
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
        RecalculatePhysics();
        UpdateName();
    }

    public void SetCustomName(string newName)
    {
        Name = newName;
        NeedsCustomName = false;
    }

    public void HeatUp(double targetTemp)
    {
        if(CurrentTemp < targetTemp)
        {
            CurrentTemp = targetTemp;
        }
    }

    private void RecalculatePhysics()
    {
        double totalWeight = 0;
        double weightedTempSum = 0;

        foreach (var ing in Ingredients)
        {
            totalWeight += ing.Weight;
            weightedTempSum += (ing.Weight * ing.Temp);
        }
        TotalWeight = totalWeight;
        if (totalWeight > 0)
        {
            CurrentTemp = Math.Round(weightedTempSum / totalWeight, 1);
        }
    }
    private void UpdateName()
    {
        bool hasCoffee = false;
        bool hasMilk = false;
        bool hasIce = false;
        bool hasWater = false;

        List<string> uniqueSuryp = new List<string>();

        foreach (var ing in Ingredients)
        {
            if (ing is CoffeeBean) hasCoffee = true;
            if (ing is Milk) hasMilk = true;
            if (ing is Ice) hasIce = true;
            if (ing is Water) hasWater = true;

            if (ing is Syrup syrup && !uniqueSuryp.Contains(syrup.Flavor))
            {
                uniqueSuryp.Add(syrup.Flavor);
            }
        }

        if (uniqueSuryp.Count > 1 || Ingredients.Count > 10)
        {
            NeedsCustomName = true;
            Name = "Авторский микс";
            return;
        }
        else
        {
            NeedsCustomName = false;
        }

        string syrupFlavor = uniqueSuryp.Count == 1 ? uniqueSuryp[0] : "";
        string baseName = "Пустая чашка";

        if(hasCoffee)
        {
            if (hasIce && hasMilk) baseName = "Айс-латте";
            else if (hasIce) baseName = "Айс-кофе";
            else if (hasMilk) baseName = "Капучино";
            else baseName = "Эспрессо";
        }

        else
        {
            if (hasMilk)
            {
                baseName = (syrupFlavor != "" || hasIce) ? "Молочный коктель" : "Стакан молока";
            }
            else if (hasWater)
            {
                baseName = (syrupFlavor != "") ? "Лимонад" : (hasIce ? "Вода со льдом" : "Вода");
            }
            else if (hasIce && syrupFlavor != "")
            {
                baseName = "Фруктовый лед";
            }
            else if (syrupFlavor != "")
            {
                baseName = "Сироп в стакане";
            }
        }

        if (!string.IsNullOrEmpty(syrupFlavor))
        {
            string fullName = $"{syrupFlavor} {baseName.ToLower()}";
            Name = char.ToUpper(fullName[0]) + fullName.Substring(1);
        }

        else
        {
            Name = baseName;
        }
    }
}
// Арут одобрил 