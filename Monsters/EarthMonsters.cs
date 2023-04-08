using System;
using Game_Zodiac.Core;

namespace Game_Zodiac.Monsters
{
	public class EarthMonsters : Monster
    {
		public EarthMonsters()
		{
            Random rnd = new Random();

            Name = "Earth";
            Symbol = 'e';//'●';
            Attack = 25;
            Health = 80;
            MaxHealh = 80;
            Armor = rnd.Next(10, 14); 
            Key = 0;
            Gold = rnd.Next(1, 10);
            Awake = false;
            X = 2;
            Y = 3;
        }
	}
}

