using System;
using Roguelikej.Core;

namespace Roguelikej.Monsters
{
	public class FireMonsters : Monster
    {
		public FireMonsters()
		{
            Name = "Fire";
            Symbol = "😡";
            Attack = 45;
            Health = 90;
            MaxHealh = 90;
            Armor = 10;
            Key = 0;
            Random rnd = new Random();
            Gold = rnd.Next(1, 10);
            Awake = false;
        }
	}
}

