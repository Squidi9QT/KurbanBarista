using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;
using KurbanBarista.Actions;

Console.WriteLine("===Kurban Barista-Лучшее Кофе!!!===");
Console.WriteLine("(абсолютно непредвзятое мнение)");

Drink myDrink = new Drink();

bool isOrdering = true;
while(isOrdering)
{
    Console.WriteLine($"\n ||| Текущий напиток: {myDrink.Name} ({myDrink.CurrentTemp}°C, {myDrink.TotalWeight} г.) |||");
    Console.WriteLine("Что добавим в чашку?");

    Console.WriteLine("1 - Добавить воду (Кипяток, 50г)");
    Console.WriteLine("2 - Перемолоть и добавить кофе (15г)");
    Console.WriteLine("3 - Налить молоко (выбрать температуру и пенку)");
    Console.WriteLine("4 - Добавить лёд (30г)");
    Console.WriteLine("5 - Добавить Карамельный сироп (15г)");
    Console.WriteLine("6 - Добавить Клубничный сироп (15г)");
    Console.WriteLine("0 - Выдать чек!");
    Console.Write("Ваш выбор: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
        Water water = new Water(50);
        new BoilAction(water).Execute(myDrink);
        new AddAction(water).Execute(myDrink);
        break;
    }
}