using Game_Zodiac._Battle;
using Game_Zodiac._Renderer2D;
using Game_Zodiac._Vector2;
using System;

namespace Game_Zodiac.Core
{
    public class Zodiak
    {
        
        public static void Game(Character player, Monster monster1, Monster monster2, Monster monster3)
        {
            Renderer2D _renderer = new Renderer2D(120, 35);
            Console.SetWindowSize(Maze.GameWidth, Maze.GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(Maze.GameWidth, Maze.GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            Maze.Init(monster1, monster2, monster3); //иницилизация карты
            BattleLoop battleLoop = new BattleLoop();
            while (true)
            {

                Player.Steps(player); //шаги игрока
                Monster.MonsterMovement(MethodsForMonsters.MonsterArray(monster1, monster2, monster3),player);
                Render3D.Draw(player, monster1, monster2, monster3, player); //отрисовка лабиринта и его составляющих


                Maze.Draw2D(player); //отрисовка карты
                
                Maze.Stats(player); //состояние

                
                if ((Math.Abs(player.X - monster1.X) <= 1) & (Math.Abs(player.Y - monster1.Y) <= 1))
                {
                    battleLoop.StartBattleLoop(player, monster1);
                    //monster1.Awake = false;

                }
                if ((Math.Abs(player.X - monster2.X) <= 1) & (Math.Abs(player.Y - monster2.Y) <= 1))
                {
                    battleLoop.StartBattleLoop(player, monster2);
                    //monster2.Awake = false;
                }
                if ((Math.Abs(player.X - monster3.X) <= 1) & (Math.Abs(player.Y - monster3.Y) <= 1))
                {
                    battleLoop.StartBattleLoop(player, monster3);
                    
                }

                

                if (player.GoldLevel > 1000)
                {
                    player.Gold += player.GoldLevel;
                    player.GoldLevel = 0;
                    if (player.Gold >= 5000)
                    {
                        _renderer.DrawText(new Text($"YOU WON!!!", new Vector2(50, 5), ConsoleColor.Green));
                        Environment.Exit(0);
                    }
                    else
                    {
                        Maze.Init(monster1, monster2, monster3);
                        Game(player, monster1, monster2, monster3);
                    }
                    

                }
                Console.SetCursorPosition(0, 0);
                Console.Write(Maze.Screen);

            }
        }
    }
}
