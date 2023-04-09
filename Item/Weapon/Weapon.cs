using Game_Zodiac._Item;

namespace Game_Zodiac._Weapon
{
    public class Weapon : Item
    {
        private int damage;

        public int Damage => damage;

        public Weapon(string name, int count, string description, string icon, int damage)
        {
            this.name = name;
            this.count = count;
            this.description = description;
            this.icon = icon;
            this.damage = damage;
        }
    }
}
