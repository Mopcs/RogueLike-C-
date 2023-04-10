using Game_Zodiac._Battle;
using Game_Zodiac._HealingItem;
using Game_Zodiac._Weapon;
using Game_Zodiac.Monsters;
using System;


namespace Game_Zodiac.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string nameHero = Console.ReadLine();
            FirePlayer airPlayers = new FirePlayer(nameHero);
            WaterMonsters waterMonsters = new WaterMonsters();

            BattleLoop battleLoop = new BattleLoop();

            Weapon sword = new Weapon("Sword", 1, "A sharp sword.", "sword_icon.png", 20);

            HealingItem potion = new HealingItem("Potion", 7, "A healing potion.", "potion_icon.png", 30);

            airPlayers.inventory.AddItem(sword);
            airPlayers.inventory.AddItem(potion);

            airPlayers.TakeWeapon(sword);
            airPlayers.TakePotion(potion);


            battleLoop.StartBattleLoop(airPlayers, waterMonsters);
            Console.ReadKey();*/

            Game.Start();
        }
    }
}
