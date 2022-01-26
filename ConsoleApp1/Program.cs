using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
        // Характеристики
            int shield = 0;
            int damage = 0;
            int hero = 0;
            int monster = 10;
        // Инвентарь
            var invent = new List<string>();
            var cash = new List<int>();
        // Переименновать dice  
            Random dice = new Random();
            Random montreCoins = new Random();
        // Начало игры
            Console.WriteLine("Сыграем в игру?");
            string playing = Console.ReadLine();

            if (playing == "Да" || playing == "да")
            {
                Console.WriteLine(@"Выбери умение:

Силач - 8hp +1 к урону.
Крепыш - 8hp + щит способный отразить 1 урона.
");

                // Выбор умения
                string skill = Console.ReadLine();

                switch (skill)
                {
                    case "Силач":
                        hero = 85555;
                        damage = 1;
                        break;

                    case "Крепыш":
                        hero = 8;
                        shield = 1;
                        break;
                }
            }
            else if (playing == "Нет" || playing == "нет")
            {
                Console.WriteLine("Пошел нахуй");
                return;
            }
            // Игра продолжается до тех пор пока жив игрок, другого варианта не нашлось
            while (hero != 0)

            {   // Циклические похождения
                Console.WriteLine("По пути в подземелье на тебя напал монстр\n");

                do
                {
                // Характеристики атаки, дописать первую строку
                    int rollH = dice.Next(1, 5);
                    int attack = rollH + damage;
                    int rollM = dice.Next();

                    Console.WriteLine("1 - Атаковать\n");
                    Console.WriteLine("2 - Поставить щит\n");

                    string act = Console.ReadLine();

                // Атака героя
                    if (act == "1")
                    {
                        monster -= attack;
                        Console.WriteLine($@"Ты бьешь на {attack} урона всего у него {monster} hp");
                    }
                // Щит героя 
                    else if (act == "2")
                    {
                        rollM = dice.Next(1, 5);
                        hero -= rollM - shield;
                        Console.WriteLine($"Монстр бьет на {rollM - shield} урона всего у тебя {hero} hp\n");
                        continue;
                    }

                    else if (monster <= 0) continue;

                // Атака монстра в ответ
                    rollM = dice.Next(1, 4);
                    hero -= (rollM);
                    Console.WriteLine($"Монстр бьет на {rollM} урона всего у тебя {hero} hp\n");


                } while (monster >= 0 && hero >= 0);
            // Рандом монет
                int loot = montreCoins.Next();
                loot = montreCoins.Next(5, 11);

                invent.Add($"Монеты: {loot}");

                Console.WriteLine(monster > hero ? $"Ты проиграл" : "С монстра упало");
                Console.WriteLine($"{loot} монет идем дальше\n");

            // Магазин дедули допелить
                Console.WriteLine("По пути тебе попался дедуля с магазинчиком его товар:\n" +
        "Зелье + 10 к здоровью " +
        "Стоимость: 10 монет\n" +
        "Что купим?" +
        "Enter - пропустить");



                string magazin = Console.ReadLine();                                       
                
                switch (magazin)
                {
                    case "Зелье":
                        invent.Add("Зелье + 10 к здоровью - Выпить");
                        cash.Remove(10);
                        break;                   

                    default:
                        break;
                }

               /* if (cash[0] > 10)
                {
                    Console.WriteLine("Не хватает монет");
                } */

                // Добавить с элемент гемплея боя

                Console.WriteLine("Можем посмотреь инвентарь - 1");
                string check = Console.ReadLine();

                if (check == "1")
                {
                    foreach (var item in invent)
                    {
                        Console.WriteLine(item);
                        string act = Console.ReadLine();
                        if (act == "Выпить")
                            hero += 10;
                        else
                            continue;
                    }                   

                }

                Console.WriteLine($"Мое здоровье {hero}");




            }
        }
    }
}
        