using System;

namespace Game_Zodiac.Core
{
    public class FirePlayer : Character
    {
        public FirePlayer(string nameHero)
        {
            Name = nameHero;
            Symbol = '*';
            Health = 100;
            MaxHealth = 100;
            Armor = 2;
            Key = 0;
            Gold = 0;
            X = 1;
            Y = 1;
            C = (int) Math.PI / 4;
        }
    }
}
