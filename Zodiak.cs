using Game_Zodiac._Battle;
using Game_Zodiac._Vector2;
using System;
using System.IO;

namespace Game_Zodiac.Core
{
    public class Zodiak
    {
        //игра
        public static void Game(Character player, Monster monster1, Monster monster2, Monster monster3)
        {
            Console.SetWindowSize(Maze.GameWidth, Maze.GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(Maze.GameWidth, Maze.GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора
            Maze.Init(monster1, monster2, monster3); //иницилизация карты

            while (true)
            {
                Player.Steps(); //шаги игрока
                Monster.MonsterMovement(MethodsForMonsters.MonsterArray(monster1, monster2, monster3),player);
                Render3D.Draw(player, monster1, monster2, monster3, Maze.character1); //отрисовка лабиринта и его составляющих
                if ((player.X == monster1.X) & (player.Y == monster1.Y))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster1);
                    
                }
                if ((player.X == monster2.X) & (player.Y == monster2.Y))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster2);
                    
                }
                if ((player.X == monster3.X) & (player.Y == monster3.Y))
                {
                    BattleLoop battleLoop = new BattleLoop();
                    battleLoop.StartBattleLoop(player, monster3);
                    
                }
                Maze.Draw2D(player); //отрисовка карты
                Maze.Stats(); //состояние
                
               

                Console.SetCursorPosition(0, 0);
                Console.Write(Maze.Screen);

            }
        }
    }
}
