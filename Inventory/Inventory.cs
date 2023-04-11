using System;
using System.Collections.Generic;
using Game_Zodiac._Item;
using Game_Zodiac._HealingItem;
using Game_Zodiac.Core;

namespace Game_Zodiac
{
    public class Inventory : Item
    {
        private int countOfSlots = 6;
        public List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            if (items.Count < countOfSlots)
            {
                items.Add(item);
                Console.WriteLine("Added " + item.name + " to inventory.");
            }

            /*else
            {
                Console.WriteLine("Inventory is full!");
            }*/
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            Console.WriteLine("Removed " + item.name + " from inventory.");
        }

        public void UseItem(HealingItem item, Character player)
        {
            if (player.Health <= 0)
            {
                return;
            }
            else if (item.quantity > 0)
            {
                player.TakeHealing(item);
                item.Consume();
                item.quantity--;

                if (player.Health > player.MaxHealth)
                {
                    player.Health = player.MaxHealth;
                }
            }
            else
            {
                Console.WriteLine("You don't have any potions left.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine(items.Count);
            foreach (var tools in items)
            {
                Console.WriteLine(tools.name);
            }
        }
    }
}