using Game_Zodiac._Item;
using Game_Zodiac._Vector2;
using System;

namespace Game_Zodiac.Core
{
    public class Trader : TraderInventory
    {
        public Vector2 traderCoords;


        public int costOfItem;

        public TraderInventory traderInventory = new TraderInventory();

        public void SellItem(Item item, Character player)
        {
            if (traderInventory.items.Contains(item) && player.Gold >= costOfItem)
            {
                player.Gold -= costOfItem;
                traderInventory.items.Remove(item);
                player.inventory.AddItem(item);
                Console.WriteLine(player.Name + " bought " + item.name + " from Trader for " + costOfItem + " gold.");
            }

            else
            {
                Console.WriteLine("Not enough gold or item is not in stock!");
            }
        }
    }
}
