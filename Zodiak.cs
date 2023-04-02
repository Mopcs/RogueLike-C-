using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Zodiac
{
    public class Zodiak
    {
        //игра
        public static void Game()
        {
            Console.SetWindowSize(Maze.GameWidth, Maze.GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(Maze.GameWidth, Maze.GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            Maze.Init(); //иницилизация карты

            while (true)
            {
                Player.Steps(); //шаги игрока

                Render3D.Draw(); //отрисовка лабиринта и его составляющих

                Maze.Draw2D(); //отрисовка карты
                Maze.Stats(); //состояние

                Console.SetCursorPosition(0, 0);
                Console.Write(Maze.Screen);

            }
        }
    }
}
