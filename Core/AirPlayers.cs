using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Zodiac.Core
{
    internal class AirPlayers: Character
    {
        public AirPlayers(string nameHero)
        {
            Name = nameHero;
            Symbol = '☁';
            Health = 85;
            MaxHealth = 85;
            Armor = 4;
            Key = 0;
            Gold = 0;
            X = 1;
            Y = 1;
            C = 7;
        }
    }
}
