using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Roguelikej.Core
{
    internal class WaterPlayer : Character
    {
        public WaterPlayer() 
        {
            Name = "nameHero";
            Symbol = "💧";
            Attack = 0;
            Health = 150;
            MaxHealh = 150;
            Armor = 0;
            Key = 0;
            Gold = 0;
        }

        public void DrawStats()
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Name { Name}");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine($"Health {Health}");
            Console.SetCursorPosition(1, 5);
            Console.WriteLine($"Attack {Attack}");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine($"Armor {Armor}");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine($"Gold {Gold}");
        }
    }
}
