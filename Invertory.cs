using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public abstract class InvertoryObjects
    {
        public string Name;
        public Destinations Destination;
        public float Price;
    }

    public class Food : InvertoryObjects 
    { 
        public Food(string Name, float Price)
        {
            this.Name = Name;
            Destination = Destinations.Еда;
            this.Price = Price;
        }
        public void Eat(ref int Health, ref Moods Mood)
        {
            if (Name == Objects.Яблоко.ToString())
            {
                Console.WriteLine("Вы сьели яблоко и получили +10 здоровья!");
                Health += 10;
            }
            else if (Name == Objects.Исцелитель.ToString())
            {
                Console.WriteLine("Вы выпили исцелитель и полностью восстановили здоровье!");
                Health = 100;
            }
            else if (Name == Objects.Торт.ToString())
            {
                Console.WriteLine("Вы сьели и теперь у вас отличное настроение!");
                Mood = Moods.Отличное;
            }
            else if (Name == Objects.Яд.ToString())
            {
                Console.WriteLine("Вы выпили яд и умерли!");
                Environment.Exit(0);
            }
        }
    }

    public class Thing : InvertoryObjects
    {
        public Thing(string Name, float Price)
        {
            this.Name = Name;
            Destination = Destinations.Одежда;
            this.Price = Price;
        }
        public void GetThing(ref int Secure)
        {
            if (Name == Objects.Майка.ToString())
            {
                Console.WriteLine("Вы надели майку и получили +20 брони!");
                Secure += 20;
            }
            else if (Name == Objects.Шорты.ToString())
            {
                Console.WriteLine("Вы надели шорты и получили +25 брони!");
                Secure += 25;
            }
            else if (Name == Objects.Броня.ToString())
            {
                Console.WriteLine("Вы надели броню и получили +100 брони!");
                Secure +=100;
            }
        }
    }
}
