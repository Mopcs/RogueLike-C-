using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class Program
    {
        private const int GameWidth = 100; //ширина
        private const int GameHeight = 60; //высота

        private const int LabWidth = 32; //ширина карты лабиринта
        private const int LabHeight = 32; //высота карты лабиринта

        private const double Fov = Math.PI / 3; //угол
        private const double Depth = 16; //глубина, до которой может дойти игрок

        private static string _lab = ""; //сам лабиринт

        private static double _PlayerX = 0; //координаты игрока по x
        private static double _PlayerY = 0; //координаты игрока по y
        private static double _PlayerC = 0; //угол обзора игрока


        private static readonly char[] Screen = new char[GameHeight * GameWidth]; //содание игровой консоли, экран


        static void Main(string[] args)
        {
            Console.SetWindowSize(GameWidth, GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(GameWidth, GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            _lab += "#####################";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#...................#";
            _lab += "#####################";

            while (true)
            {
                for(int x = 0; x < GameWidth; x++)
                {
                    double RayCorner = _PlayerC + Fov / 2 - x * Fov / GameWidth; //луч род углом наклона

                    double RayX = Math.Sin(RayCorner); //с помощью угла узнаем координаты по x
                    double RayY = Math.Cos(RayCorner); //с помощью угла узнаем координаты по y

                    double DistanceWall = 0; //расстояние до стены
                    bool HitWall = false; //попали в стену или нет

                    while (!HitWall && DistanceWall < Depth)
                    {
                        DistanceWall += 0.1;

                        int TestX = (int) (_PlayerX + RayX * DistanceWall); //узнаем координаты по x
                        int TestY = (int) (_PlayerY + RayY * DistanceWall); //узнаем координаты по y

                        if (TestX < 0 || TestX >= Depth + _PlayerX || TestY < 0 || TestY >= Depth + _PlayerY) //проверка на стену
                        {
                            HitWall = true;
                            DistanceWall = Depth;
                        }
                        else
                        {
                            char TestCell = _lab[TestY * GameWidth + TestX];

                            if (TestCell == '#')
                            {
                                HitWall = true;
                            }
                        }
                    }

                } 
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(Screen);
        }
    }
}
