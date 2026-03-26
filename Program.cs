using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;
using KurbanBarista.Actions;

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;

Console.WriteLine("===Kurban Barista-Лучшее Кофе!!!===");
Console.WriteLine("  (абсолютно непредвзятое мнение)  ");

Console.ResetColor();

Drink myDrink = new Drink();
bool isOrdering = true;
while(isOrdering)
{
    Console.WriteLine($"\nТекущий напиток: {myDrink.Name} ({myDrink.CurrentTemp}°C, {myDrink.TotalWeight} г.)");
    Console.WriteLine("Что добавим в чашку?");

    Console.WriteLine("1 - Добавить воду (Кипяток, 50г)");
    Console.WriteLine("2 - Перемолоть и добавить кофе (15г)");
    Console.WriteLine("3 - Налить молоко (выбрать температуру и пенку)");
    Console.WriteLine("4 - Добавить лёд (30г)");
    Console.WriteLine("5 - Добавить Карамельный сироп (15г)");
    Console.WriteLine("6 - Добавить Клубничный сироп (15г)");
    Console.WriteLine("0 - Выдать чек!");
    Console.Write("Ваш выбор: ");

    string choice = Console.ReadLine()!;
    Console.WriteLine();

    switch (choice)
    {
        case "1":
        Water water = new Water(250);
        myDrink.ApplyAction(new BoilAction(water));
        myDrink.ApplyAction(new PourAction(water));
        break;

        case "2":
        CoffeeBean beans = new CoffeeBean(15);
        myDrink.ApplyAction(new GrindAction(beans));
        myDrink.ApplyAction(new AddAction(beans));
        break;

        case "3":
        Milk milk = new Milk(50);

        Console.Write("Взбить молоко? [1-да 0-нет]: ");
        if (Console.ReadLine()=="1")
            {
                myDrink.ApplyAction(new WhipAction(milk));
            }

        Console.Write("Подогреть молоко? [1-да 0-нет]: ");
        if (Console.ReadLine()=="1")
            {
                Console.Write("[Действие] Нагреваем молоко...");
                milk.Temp = 67;
            }

        myDrink.ApplyAction(new AddAction(milk));
        break;

        case "4":
        myDrink.ApplyAction(new AddAction(new Ice(30)));
        break;

        case "5":
        Syrup caramel = new Syrup("Карамельный", 15);
        myDrink.ApplyAction(new AddAction(caramel));
        myDrink.ApplyAction(new MixAction(caramel));
        break;

        case "6":
        Syrup strawberry = new Syrup("Клубничный", 15);
        myDrink.ApplyAction(new AddAction(strawberry));
        myDrink.ApplyAction(new MixAction(strawberry));
        break;

        case "0":
        isOrdering = false;
        break;

        default:
        Console.WriteLine("Нет такого пункта");
        break;
    }
}

if (myDrink.NeedsCustomName)
{
    Console.WriteLine("\n[Бариста Курбан ашалел] Вы смешали слишком много вкусов!");
    Console.Write("Как назавете свой шедевр?");
    string customName = Console.ReadLine()!;

    if(!string.IsNullOrWhiteSpace(customName))
    {
        myDrink.SetCustomName(customName);
    }
}

if(myDrink.TotalWeight > 0)
{
    Console.WriteLine($"\nТекущая температура напитка: {myDrink.CurrentTemp}°C");
    Console.WriteLine("Что делаем с температурой?");
    Console.WriteLine("1 - Оставить как есть");
    Console.WriteLine("2 - Подогреть (до 80°C)");
    Console.Write("Ваш выбор:");

    if (Console.ReadLine() == "2")
    {
        Console.WriteLine("[Действие...]Вжжжж! Подогреваем ваш напиток!");
        myDrink.HeatUp(80);
    }

}

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;

Console.WriteLine("\n===============================");
Console.WriteLine("        ВАШ ГОТОВЫЙ ЗАКАЗ      ");
Console.WriteLine("===============================");
Console.WriteLine($"Название: {myDrink.Name}");
Console.WriteLine($"Общая масса: {myDrink.TotalWeight} г.");
Console.WriteLine($"Итоговая температура: {myDrink.CurrentTemp}°C");

Console.WriteLine("\nПошаговый рецепт приготовления:");
for (int i = 0; i < myDrink.RecipeSteps.Count; i++)
{
    Console.WriteLine($"{i+1}.{myDrink.RecipeSteps[i]}");
}

Console.WriteLine("\nСостав:");
foreach (var ingredient in myDrink.Ingredients)
{
    Console.WriteLine($" * {ingredient.DisplayName}");
}
Console.WriteLine("===============================");
Console.WriteLine("Спасибо, что выбрали нас!");

Console.ResetColor();