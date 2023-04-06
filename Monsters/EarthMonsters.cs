using System;
using Roguelikej.Core;

namespace Roguelikej.Monsters
{
	public class EarthMonsters : Monster
    {
		public EarthMonsters()
		{
            Random rnd = new Random();

            Name = "Earth";
            Symbol = "🧨";
            Attack = 25;
            Health = 80;
            MaxHealh = 80;
            Armor = rnd.Next(10, 14); 
            Key = 0;
            Gold = rnd.Next(1, 10);
            Awake = false;
        }
	}
}

