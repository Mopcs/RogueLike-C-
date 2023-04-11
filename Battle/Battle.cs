using System;
using Game_Zodiac.Core;

namespace Game_Zodiac._Battle
{
    public class Battle
    {
        public void BattleAction(Character player, Monster enemy)
        {
            char action = Console.ReadKey(true).KeyChar;
            switch (action)
            {
                case '1':
                    //Console.WriteLine("Player attacked enemy");
                    player.HitWithWeapon(enemy);
                    player.ApplyDamage(enemy.Attack);
                    break;
                case '2':
                    //Console.WriteLine("Player used a potion");
                    player.inventory.UseItem(player.CurrentPotion, player);
                    break;
                case '3':
                    //Console.WriteLine("Player used defence");
                    player.ApplyDamage(enemy.Attack, true);
                    break;
                default:
                    //Console.WriteLine("Invalid action, please choose again");
                    break;
            }
        }
    }
}
