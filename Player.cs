using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class Player
    {
        public List<object> invertory = new List<object>();
        public int Health, Secure;
        public float Money;
        public Moods Mood;

        public Player(List<object> invertory, int Health, int Secure,
            float Money, Moods Mood = Moods.Нормальное)
        {
            this.invertory = invertory;
            this.Health = Health;
            this.Secure = Secure;
            this.Money = Money;
            this.Mood = Moods.Нормальное;
        }


        public void BuyThings()
        {
            Console.WriteLine("\nУ нас доступны из одежды: \n" +
                        $"1.{Objects.Майка.ToString()} - (+20 броня) - $21.86\n" +
                        $"2.{Objects.Шорты.ToString()} - (+25 броня) - $24.31\n" +
                        $"3.{Objects.Броня.ToString()} - (+100 броня) - $101.12\n");
            Console.Write("Что желаете купить? (Введите номер) ");
            int num_of_thing = Convert.ToInt32(Console.ReadLine());
            if (num_of_thing == 1 && Money >= 21.86)
            {
                invertory.Add(new Thing(Objects.Майка.ToString(), 21.86f));
                Money -= 21.86f;
                Console.WriteLine($"Майка успешно куплена! На счету осталось: ${Money.ToString("#.##")}");
            }
            else if (num_of_thing == 2 && Money >= 24.31)
            {
                invertory.Add(new Thing(Objects.Шорты.ToString(), 24.31f));
                Money -= 24.31f;
                Console.WriteLine($"Шорты успешно куплены! На счету осталось: ${Money.ToString("#.##")}");
            }
            else if (num_of_thing == 3 && Money >= 101.12)
            {
                invertory.Add(new Thing(Objects.Броня.ToString(), 101.12f));
                Money -= 101.12f;
                Console.WriteLine($"Броня успешно куплена! На счету осталось: ${Money.ToString("#.##")}");
            }
            else Console.WriteLine("Вам не хватит денег.");
            Mood = Moods.Нормальное;
        }
        public void BuyFood()
        {
            Console.WriteLine("\nУ нас доступны из еды: \n" +
                        $"1.{Objects.Яблоко.ToString()} - (+20 здоровье) - $2.66\n" +
                        $"2.{Objects.Исцелитель.ToString()} - (+100 здоровье) - $69.34\n" +
                        $"3.{Objects.Торт.ToString()} - (Отличное настроение) - 457.52\n" +
                        $"4.{Objects.Яд.ToString()} - (Смерть) - 2.18р");
            Console.Write("Что желаете купить? (Введите номер) ");
            int num_of_thing = Convert.ToInt32(Console.ReadLine());
            if (num_of_thing == 1 && Money >= 2.66)
            {
                InvertoryObjects apple = new Food(Objects.Яблоко.ToString(), 2.66f);
                invertory.Add(apple);
                Money -= 2.66f;
                Console.WriteLine($"Яблоко успешно куплено! На счету осталось: ${Money.ToString("#.##")}");
            }
            else if (num_of_thing == 2 && Money >= 69.34)
            {
                invertory.Add(new Food(Objects.Исцелитель.ToString(), 69.34f));
                Money -= 69.34f;
                Console.WriteLine($"Исцелитель успешно куплен! На счету осталось: ${Money.ToString("#.##")}");
            }
            else if (num_of_thing == 3 && Money >= 57.52)
            {
                invertory.Add(new Food(Objects.Торт.ToString(), 57.52f));
                Money -= 57.52f;
                Console.WriteLine($"Торт успешно куплен! На счету осталось: ${Money.ToString("#.##")}");
            }
            else if (num_of_thing == 4 && Money >= 2.18)
            {
                invertory.Add(new Food(Objects.Яд.ToString(), 2.18f));
                Money -= 2.18f;
                Console.WriteLine($"Яд успешно куплен! На счету осталось: ${Money.ToString("#.##")}");
            }
            else Console.WriteLine("Вам не хватит денег.");
            Mood = Moods.Нормальное;
        }
        public void Eat()
        {
            Console.WriteLine("\nЕда из инвертаря: ");
            try
            {
                var trying = invertory[0];
                foreach (Food el in invertory)
                {
                    string name_of_food = el.Name;
                    Console.WriteLine(name_of_food);
                }
                Food b = null;
                while (b == null)
                {
                    Console.Write("Что выбрать? (Введите полное имя): ");
                    string a = Console.ReadLine();
                    try
                    {
                        foreach (Food el in invertory) if (el.Name == a) b = el;
                    }
                    catch (InvalidCastException)
                    {
                        //Ничего не делать
                    }
                    if (b != null)
                    {
                        b.Eat(ref Health, ref Mood);
                        invertory.Remove(b);
                    }
                    else
                    {
                        Console.WriteLine("Такой еды нет в инвентаре!");
                        break;
                    }
                }
            }
            catch (InvalidCastException)
            {
                //Ничего не делать
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Пусто!");
            }
        }
        public void GetThing()
        {
            Console.WriteLine("\nОдежда из инвертаря: ");
            try
            {
                var trying = invertory[0];
                foreach (Thing el in invertory)
                {
                    string name_of_thing = el.Name;
                    Console.WriteLine(name_of_thing);
                }
                Thing b = null;
                while (b == null)
                {
                    Console.Write("Что выбрать? (Введите полное имя): ");
                    string a = Console.ReadLine();
                    try
                    {
                        foreach (Thing el in invertory) if (el.Name == a) b = el;
                    }
                    catch (InvalidCastException)
                    {
                        //Ничего не делать
                    }
                    if (b != null)
                    {
                        b.GetThing(ref Secure);
                        invertory.Remove(b);
                    }
                    else
                    {
                        Console.WriteLine("Такой еды нет в инвентаре!");
                        break;
                    }
                }
            }
            catch (InvalidCastException)
            {
                //Ничего не делать
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Пусто!");
            }
        }
        public void Battle()
        {
            Random rand = new Random();
            int minusorplus = rand.Next(-1, 1);
            if (minusorplus == 0 || Mood == Moods.Отличное)
            {
                Console.WriteLine("\nВы победили в сражении! У вас отличное настроение!");
                Mood = Moods.Отличное;
            }
            else if (minusorplus == 1 || Mood == Moods.Ужасное)
            {
                int minushealth = rand.Next(150);
                if (minushealth > Secure)
                {
                    Health -= minushealth - Secure;
                    Secure = 0;
                }
                else Secure -= minushealth;
                Console.WriteLine($"\nВы проиграли! Ваше здоровье: {Health}, Броня: {Secure}");
            }

            if (Secure <= 0 && Health <= 0)
            {
                Console.WriteLine("Вы мертвы!");
                Environment.Exit(0);
            }
            else if (Secure <= 0 && Health !<= 0)
            {
                Console.WriteLine("Защита израсходована.");
            }
        }
    }
}
