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
        Water water = new Water(50);
        new BoilAction(water).Execute(myDrink);
        new AddAction(water).Execute(myDrink);
        break;

        case "2":
        CoffeeBean beans = new CoffeeBean(15);
        new GrindAction(beans).Execute(myDrink);
        new AddAction(beans).Execute(myDrink);
        break;

        case "3":
        Milk milk = new Milk(50);

        Console.Write("Взбить молоко? [1-да 0-нет]: ");
        if (Console.ReadLine()=="1")
            {
                new WhipAction(milk).Execute(myDrink);
            }

        Console.Write("Подогреть молоко? [1-да 0-нет]: ");
        if (Console.ReadLine()=="1")
            {
                Console.Write("[Действие] Нагреваем молоко...");
                milk.Temp = 60;
            }

        new AddAction(milk).Execute(myDrink);
        break;

        case "4":
        new AddAction(new Ice(30)).Execute(myDrink);
        break;

        case "5":
        new AddAction(new Syrup("Карамельный", 15)).Execute(myDrink);
        break;

        case "6":
        new AddAction(new Syrup("Клубничный", 15)).Execute(myDrink);
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
Console.WriteLine("\nСостав:");
foreach (var ingredient in myDrink.Ingredients)
{
    Console.WriteLine($" * {ingredient.DisplayName}");
}
Console.WriteLine("===============================");
Console.WriteLine("Спасибо, что выбрали нас!");

Console.ResetColor();