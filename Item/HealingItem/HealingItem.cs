using System;
using Game_Zodiac._Item;

namespace Game_Zodiac._HealingItem
{
    public class HealingItem : Item, IUsable
    {
        public int healingAmount;

        public int quantity;

        public HealingItem(string name, int count, string description, string icon, int healingAmount)
        {
            this.name = name;
            quantity = count;
            this.description = description;
            this.icon = icon;
            this.healingAmount = healingAmount;
        }

        public void Consume()
        {
            Console.WriteLine("Using " + name + " to heal for " + healingAmount + " points.");
        }
    }
}