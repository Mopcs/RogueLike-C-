using System;
namespace Game_Zodiac.Core
{
	public class Monster : Character
    {
        private int _attack;

        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }

        public void Hit(Character target)
        {
            //Console.WriteLine(name + " hits " + target.name + " for " + attackDamage + " damage!");
            target.ApplyDamage(Attack);
        }
    }
}

