using System;
using System.Xml.Linq;
using Game_Zodiac.Core;

namespace Game_Zodiac.Monsters
{
	public class WaterMonsters : Monster
    {
        public WaterMonsters()
        {
            Random rnd = new Random();
            Name = "Water";
            Symbol = 'w';
            Attack = 20;
            Health = 200;
            MaxHealth = 200;
            Armor = 5;
            Key = 0;
            Gold = rnd.Next(30, 45);
            Awake = false;
            X = 2;
            Y = 3;
        }
	}
}

