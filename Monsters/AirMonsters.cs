using System;
using Roguelikej.Core;

namespace Roguelikej.Monsters
{
	public class AirMonsters : Monster
    {
		public AirMonsters()
		{
            Random rnd = new Random();

            Name = "Air";
            Symbol = "💣";
            Attack = 30;
            Health = 90;
            MaxHealh = 90;
            Armor = rnd.Next(4, 10); ;
            Key = 0;
            Gold = rnd.Next(1, 10);
            Awake = false;
        }
	}
}

