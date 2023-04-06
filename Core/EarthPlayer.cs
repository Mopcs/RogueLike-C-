
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelikej.Core
{
    internal class EarthPlayer : Character
    {
        public EarthPlayer()
        {
            Name = "nameHero";
            Symbol = "🌍";
            Attack = 0;
            Health = 70;
            MaxHealh = 70;
            Armor = 15;
            Key = 0;
            Gold = 0;

        }
        public void DrawStats()
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Name {Name}");
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
