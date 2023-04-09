using System;
using Game_Zodiac.Core;

namespace Game_Zodiac.Monsters
{
	public class AirMonsters : Monster
    {
		public AirMonsters()
		{
            Random rnd = new Random();

            Name = "Air";
            Symbol = 'a';
            Attack = 30;
            Health = 90;
            MaxHealth = 90;
            Armor = rnd.Next(4, 10);
            Key = 0;
            Gold = rnd.Next(1, 10);
            Awake = false;
            X = 2;
            Y = 3;
        }
	}
}

