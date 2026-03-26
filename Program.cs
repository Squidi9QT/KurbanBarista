using KurbanBarista.Drinks;
using KurbanBarista.Ingredients;
using KurbanBarista.Actions;
using System.Runtime.CompilerServices;

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("===Kurban Barista-Лучшее Кофе!!!===");
Console.WriteLine("  (абсолютно непредвзятое мнение)  ");
Console.ResetColor();

List<Drink> currentOrder = new List<Drink>();
bool isAppRunning = true;

while (isAppRunning)
{
    Console.WriteLine("\n==================================");
    Console.WriteLine("          ГЛАВНОЕ МЕНЮ            ");
    Console.WriteLine("==================================");
    Console.WriteLine($"В корзине напитков: {currentOrder.Count}");
    Console.WriteLine("1 - Создать новый напиток");
    Console.WriteLine("2 - Посмотреть корзину");
    Console.WriteLine("3 - Изменить название напитка");
    Console.WriteLine("4 - Удалить напиток из корзины");
    Console.WriteLine("0 - Оплатить заказ и выдать общий чек");
    Console.Write("Ваш выбор: ");

    string mainChoice = Console.ReadLine()!;

    switch (mainChoice)
    {
        case "1":
            Drink myDrink = new Drink();
            bool isOrdering = true;
            while (isOrdering)
            {
                Console.WriteLine($"\n---Конструктор напитка: {myDrink.Name} ({myDrink.CurrentTemp}°C, {myDrink.TotalWeight} г.)---");
                Console.WriteLine("1 - Вскипятить и пролить воду через фильтр (250г)");
                Console.WriteLine("2 - Перемолоть и добавить кофе (15г)");
                Console.WriteLine("3 - Налить молоко (выбрать температуру и пенку)");
                Console.WriteLine("4 - Добавить лёд (30г)");
                Console.WriteLine("5 - Добавить и перемешать Карамельный сироп (15г)");
                Console.WriteLine("6 - Добавить и перемешать Клубничный сироп (15г)");
                Console.WriteLine("0 - Завершить!");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine()!;

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
                        if (Console.ReadLine() == "1")
                        {
                            myDrink.ApplyAction(new WhipAction(milk));
                        }

                        Console.Write("Подогреть молоко? [1-да 0-нет]: ");
                        if (Console.ReadLine() == "1")
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
                if (!string.IsNullOrWhiteSpace(customName)) myDrink.SetCustomName(customName);
            }

            if (myDrink.TotalWeight > 0)
            {
                Console.WriteLine($"\nТекущая температура напитка: {myDrink.CurrentTemp}°C");
                Console.WriteLine("Подогреть перед выдачей? (1 - да, 0 - нет):");
                if (Console.ReadLine() == "1") myDrink.HeatUp(80);

                currentOrder.Add(myDrink);
                Console.WriteLine($"\n{myDrink.Name} успешно добавлен в корзину!");
            }
            else
            {
                Console.WriteLine("\nВы ничего не добавили в чашку! Напиток отменен.");
            }
            break;

        case "2":
            Console.WriteLine("\n--- ВАША КОРЗИНА ---");
            if (currentOrder.Count == 0) Console.WriteLine("Корзина пуста.");
            else
            {
                for (int i = 0; i < currentOrder.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentOrder[i].Name} ({currentOrder[i].TotalWeight}г, {currentOrder[i].CurrentTemp}°C)");
                }
            }
            break;

        case "3":
            if (currentOrder.Count == 0)
            {
                Console.WriteLine("\nКорзина пуста, нечего изменять.");
                break;
            }

            Console.WriteLine("\nКакой напиток переименовать?");
            for (int i = 0; i < currentOrder.Count; i++)
                Console.WriteLine($"{i + 1}. {currentOrder[i].Name}");
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int updateIndex) && updateIndex > 0 && updateIndex <= currentOrder.Count)
            {
                Console.Write("Введите новое название: ");
                string newName = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    currentOrder[updateIndex - 1].SetCustomName(newName);
                    Console.WriteLine("Название успешно обновлено!");
                }
            }
            else Console.WriteLine("Неверный номер.");
            break;

        case "4":
            if (currentOrder.Count == 0)
            {
                Console.WriteLine("\nКорзина пуста, нечего удалять.");
                break;
            }

            Console.WriteLine("\nКакой напиток удалить?");
            for (int i = 0; i < currentOrder.Count; i++)
                Console.WriteLine($"{i + 1}. {currentOrder[i].Name}");
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int deleteIndex) && deleteIndex > 0 && deleteIndex <= currentOrder.Count)
            {
                string deletedName = currentOrder[deleteIndex - 1].Name;
                currentOrder.RemoveAt(deleteIndex - 1);
                Console.WriteLine($"{deletedName} удален из корзины.");
            }
            else Console.WriteLine("Неверный номер.");
            break;

        case "0":
            isAppRunning = false;
            break;

        default:
            Console.WriteLine("Нет такого пункта. Попробуйте снова.");
            break;
    }
}


Console.WriteLine("\n===============================");
Console.WriteLine("        ВАШ ГОТОВЫЙ ЗАКАЗ      ");
Console.WriteLine("===============================");

if (currentOrder.Count == 0)
{
    Console.WriteLine("Вы ничего не заказали.");
}
else
{
    for (int i = 0; i < currentOrder.Count; i++)
    {
        Drink d = currentOrder[i];
        Console.WriteLine($"\n--- Напиток {i + 1}: {d.Name} ---");
        Console.WriteLine($"Масса: {d.TotalWeight} г. | Температура: {d.CurrentTemp}°C");

        Console.WriteLine("Рецепт:");
        for (int step = 0; step < d.RecipeSteps.Count; step++)
        {
            Console.WriteLine($"  {step + 1}. {d.RecipeSteps[step]}");
        }

        Console.WriteLine("Состав:");
        foreach (var ing in d.Ingredients)
        {
            Console.WriteLine($"  * {ing.DisplayName}");
        }
    }
}

Console.WriteLine("=====================================");
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Спасибо, что выбрали Kurban Barista! ");
