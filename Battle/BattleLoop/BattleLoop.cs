using Game_Zodiac._Renderer2D;
using Game_Zodiac.Core;
using Game_Zodiac._Vector2;
using System;
using System.Threading;
using Game_Zodiac._Weapon;
using Game_Zodiac._HealingItem;

namespace Game_Zodiac._Battle
{
    public class BattleLoop
    {
        Renderer2D renderer2D = new Renderer2D(120, 35);
        Battle battle = new Battle();

        public void StartBattleLoop(Character player, Monster enemy)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Rectangle outlineBorderRectangle = new Rectangle(Vector2.Zero, new Vector2(120, 26), color: ConsoleColor.Yellow);
            Rectangle inlineBorderRectangle = new Rectangle(new Vector2(1, 1), new Vector2(118, 24), ' ');
            HealthBar healthBarPlayer = new HealthBar(new Vector2(12, 5), new Vector2(21, 1), 150, 150);
            HealthBar healthBarEnemy = new HealthBar(new Vector2(80, 5), new Vector2(20, 1), 200, 200);
            Text playerName = new Text($"Player: {player.Name}", new Vector2(12, 4));
            Text enemyName = new Text($"Enemy: {enemy.Name}", new Vector2(80, 4));
            Weapon sword = new Weapon("Sword", 1, "A sharp sword.", "sword_icon.png", 30);
            HealingItem potion = new HealingItem("Potion", 7, "A healing potion.", "potion_icon.png", 40);

            player.inventory.AddItem(sword);
            player.inventory.AddItem(potion);

            player.TakeWeapon(sword);
            player.TakePotion(potion);


            while ((player.Health > 0 & enemy.Health != 0) | player.Health <= 0)
            {
                healthBarPlayer.currentHealth = player.Health;
                healthBarEnemy.currentHealth = enemy.Health;


                renderer2D.SetActive();
                renderer2D.DrawRectangle(outlineBorderRectangle);
                renderer2D.DrawRectangle(inlineBorderRectangle);
                renderer2D.DrawHealthBar(healthBarPlayer);
                renderer2D.DrawHealthBar(healthBarEnemy);
                renderer2D.DrawText(playerName);
                renderer2D.DrawText(new Text($"[{player.Health}/{player.MaxHealth}]", new Vector2(30, 4)));
                renderer2D.DrawFromJson(new Vector2(12, 7), "Arias.json", "Arias");
                renderer2D.DrawFromJson(new Vector2(80, 7), "Gemini.json", "Gemini");
                renderer2D.DrawText(enemyName);
                renderer2D.DrawText(new Text($"[{enemy.Health} / {enemy.MaxHealth}]", new Vector2(97, 4)));
                renderer2D.DrawText(new Text("Choose an action:", new Vector2(10, 26), ConsoleColor.DarkCyan));
                renderer2D.DrawText(new Text("1. Attack", new Vector2(10, 27), ConsoleColor.DarkCyan));
                renderer2D.DrawText(new Text("2. Potion", new Vector2(10, 28), ConsoleColor.DarkCyan));
                renderer2D.DrawText(new Text("3. Defence", new Vector2(10, 29), ConsoleColor.DarkCyan));
                renderer2D.UpdateBuffer();

                battle.BattleAction(player, enemy);

                if (player.Health <= 0)
                {
                    renderer2D.SetActive();
                    renderer2D.DrawText(new Text($"{enemy.Name} won the battle!", new Vector2(50, 5), ConsoleColor.Red));
                    renderer2D.DrawText(new Text("You lose!", new Vector2(55, 7), ConsoleColor.Red));
                    renderer2D.UpdateBuffer();
                    Thread.Sleep(1000);
                    Game.ExitGame();
                }

                if (enemy.Health <= 0)
                {
                    renderer2D.SetActive();
                    renderer2D.DrawText(new Text($"You won the battle!", new Vector2(50, 5), ConsoleColor.Green));
                    renderer2D.UpdateBuffer();
                    player.GoldLevel += 400;
                    Thread.Sleep(1000);
                    /*Maze.Draw2D(player); //отрисовка карты
                    Maze.Stats(player); //состояние



                    Console.SetCursorPosition(0, 0);
                    Console.Write(Maze.Screen);*/

                }
                /*else
                {
                    player.ApplyDamage(enemy.Attack);
                    renderer2D.DrawText(new Text("Enemy attacked player", new Vector2(80, 26)));
                }*/
            }
        }

    }
}
