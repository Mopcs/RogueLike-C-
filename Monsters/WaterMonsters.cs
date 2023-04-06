using System;
using System.Xml.Linq;
using Roguelikej.Core;

namespace Roguelikej.Monsters
{
	public class WaterMonsters : Monster
    {
        public WaterMonsters()
        {
            Random rnd = new Random();
            Name = "Water";
            Symbol = "😭";
            Attack = 20;
            Health = 200;
            MaxHealh = 200;
            Armor = 5;
            Key = 0;
            Gold = rnd.Next(30, 45);
            Awake = false;
        
        
        }
	}
}

