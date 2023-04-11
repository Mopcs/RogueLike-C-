using Game_Zodiac._Battle;
using Game_Zodiac._Vector2;
using System;
using System.IO;

namespace Game_Zodiac.Core
{
    public class Zodiak
    {
        //public int CoorPlayer { get; set; }
        //игра
        public static void Game(Character player, Monster monster1, Monster monster2, Monster monster3)
        {
            Console.SetWindowSize(Maze.GameWidth, Maze.GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(Maze.GameWidth, Maze.GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            Maze.Init(monster1, monster2, monster3); //иницилизация карты

            while (true)
            {
          
                Player.Steps(player); //шаги игрока
                Monster.MonsterMovement(MethodsForMonsters.MonsterArray(monster1, monster2, monster3),player);
                Render3D.Draw(player, monster1, monster2, monster3, player); //отрисовка лабиринта и его составляющих
                
                if ((Math.Abs(player.X - monster1.X) <= 5) & (Math.Abs(player.Y - monster1.Y) <= 5))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster1);
                    
                }
                if ((Math.Abs(player.X - monster2.X) <= 5) & (Math.Abs(player.Y - monster2.Y) <= 5))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster2);
                    
                }
                if ((Math.Abs(player.X - monster3.X) <= 5) & (Math.Abs(player.Y - monster3.Y) <= 5))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster3);
                    
                }
                Maze.Draw2D(player); //отрисовка карты
                Maze.Stats(player); //состояние
                
               

                Console.SetCursorPosition(0, 0);
                Console.Write(Maze.Screen);

            }
        }
    }
}
