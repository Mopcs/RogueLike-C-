
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Zodiac.Core
{
    internal class EarthPlayer : Character
    {
        public EarthPlayer(string nameHero)
        {
            Name = nameHero;
            Symbol = '●';
            Health = 70;
            MaxHealth = 70;
            Armor = 15;
            Key = 0;
            Gold = 0;
            X = 1;
            Y = 1;
            C = (int)Math.PI / 4;
        }
    }
}
