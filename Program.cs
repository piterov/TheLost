using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player(new List<object>(), 100, 60, (float)80.99);
            BodyGame(ref player);
        }

        public static void BodyGame(ref Player player)
        {
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine($"\nЗдоровье: {player.Health}," +
                    $" Броня: {player.Secure}," +
                    $" Настроение: {player.Mood}," +
                    $" Деньги: ${player.Money}");
                Console.Write("Что делать? (1 - Сражаться, 2 - Поесть, 3 - Гардероб, 4 - Купить, 5 - выйти) ");
                int ask = Convert.ToByte(Console.ReadLine());

                if (ask == 1)
                    player.Battle();
                else if (ask == 2)
                    player.Eat();
                else if (ask == 3)
                    player.GetThing();
                else if (ask == 4)
                    Buy(ref player, ref Flag);
                else if (ask == 5)
                    Flag = false;
                else
                    Console.WriteLine("Введите число от 1 до 4!");
            }
        }

        public static void Buy(ref Player player, ref bool Flag)
        {
            while (Flag)
            {
                Console.Write("\nЧто хотите купить? (1 - одежда, 2 - еда, 3 - выйти из магазина) ");
                int askbuy = Convert.ToInt32(Console.ReadLine());
                if (askbuy == 1)
                {
                    player.BuyThings();
                }
                else if (askbuy == 2)
                {
                    player.BuyFood();
                }
                else if (askbuy == 3)
                {
                    Flag = false;
                    BodyGame(ref player);
                }
                else Console.WriteLine("Введите число от 1 до 3!");
            }
        }
    }
}
