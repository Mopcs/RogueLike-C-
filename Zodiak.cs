using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Render3D.Draw(player, monster1, monster2, monster3); //отрисовка лабиринта и его составляющих

                Maze.Draw2D(player); //отрисовка карты
                Maze.Stats(); //состояние

                Console.SetCursorPosition(0, 0);
                Console.Write(Maze.Screen);

            }
        }
    }
}
