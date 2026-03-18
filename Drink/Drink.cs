using KurbanBarista.Ingredients;

namespace KurbanBarista.Drinks;

public class Drink
{
    public string Name {get; set;} = "Неизвестный напиток";

    public List<Ingredient> Ingredients {get;} = new List<Ingredient>();

    public double TotalWeight {get; private set;}
    public double CurrentTemp {get; private set;}

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
        RecalculatePhysics();
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
}