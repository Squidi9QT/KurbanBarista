using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;
using KurbanBarista.Actions;

Console.WriteLine("===Kurban Barista-Лучшее Кофе!!!===");
Console.WriteLine("(абсолютно непредвзятое мнение)");

Drink myCoffee = new Drink {Name = "Эспрессо"};
Water water = new Water(50);
CoffeeBean beans = new CoffeeBean(15);

Console.WriteLine("\n --Исходные ингредиенты--");
Console.WriteLine(water.DisplayName);
Console.WriteLine(beans.DisplayName);

BoilAction boil = new BoilAction(water);
GrindAction grind = new GrindAction(beans);

AddAction addWater = new AddAction(water);
AddAction addCoffee = new AddAction(beans);

Console.WriteLine("\n --Готовится--");

boil.Execute(myCoffee);
grind.Execute(myCoffee);

addCoffee.Execute(myCoffee);
addWater.Execute(myCoffee);

Console.WriteLine("\n=== Ваш  напиток ===");
Console.WriteLine($"Название: {myCoffee.Name}");
Console.WriteLine($"Общая масса: {myCoffee.TotalWeight} г.");
Console.WriteLine($"Итоговая температура: {myCoffee.CurrentTemp}°C");

Console.WriteLine("Состав:");
foreach (var ingredient in myCoffee.Ingredients)
{
    Console.WriteLine($"-{ingredient.DisplayName}");
}