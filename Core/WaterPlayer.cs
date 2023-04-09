using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Game_Zodiac.Core
{
    internal class WaterPlayer : Character
    {
        public WaterPlayer(string nameHero) 
        {
            Name = nameHero;
            Symbol = '≈';
            Health = 150;
            MaxHealth = 150;
            Armor = 0;
            Key = 0;
            Gold = 0;
            X = 1;
            Y = 1;
            C = 7;
        }
    }
}
