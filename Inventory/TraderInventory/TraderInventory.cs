using System;
using System.Collections.Generic;
using Game_Zodiac._Item;

namespace Game_Zodiac
{
    public class TraderInventory : Inventory
    {
        private int countOfTraderSlots = 8;
        public List<Item> traderItems = new List<Item>();
        public void AddItemToTrader(Item item)
        {
            if (traderItems.Count < countOfTraderSlots)
            {
                traderItems.Add(item);
                Console.WriteLine("Added " + item.name + " to trader inventory.");
            }

            else
            {
                Console.WriteLine("Inventory is full!");
            }
        }

        public void RemoveItemFromTrader(Item item)
        {
            traderItems.Remove(item);
            Console.WriteLine("Removed " + item.name + " from trader inventory.");
        }



        public void ShowTraderInventory()
        {
            Console.WriteLine(traderItems.Count);
            foreach (var tools in traderItems)
            {
                Console.WriteLine(tools.name);
            }
        }
    }
}

