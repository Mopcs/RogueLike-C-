using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace zodiak_labirint
{
    public class Maze
    {
        public const int GameWidth = 200; //ширина
        public const int GameHeight = 80; //высота

        public const int LabWidth = 20; //ширина карты лабиринта
        public const int LabHeight = 20; //высота карты лабиринта

        public const double Fov = Math.PI / 3; //угол
        public const double Depth = 16; //глубина, до которой может дойти игрок
        public const double ElapsedTime = 0.06; //каждый раз подсчет времени операции

        public static double _PlayerX = 1; //координаты игрока по x
        public static double _PlayerY = 1; //координаты игрока по y
        public static double _PlayerC = 7; //угол обзора игрока

        public static readonly StringBuilder Map = new StringBuilder(); //карта
        public static readonly char[] Screen = new char[GameHeight * GameWidth]; //содание игровой консоли, экран

        //иницилизация карты
        public static void Init()
        {
            Map.Clear();
            Map.Append("####################");
            Map.Append("#..................#");
            Map.Append("#....#.............#");
            Map.Append("#.........O........#");
            Map.Append("#..................#");
            Map.Append("#.........###......#");
            Map.Append("#.........###......#");
            Map.Append("#..................#");
            Map.Append("#..................#");
            Map.Append("#..........#.......#");
            Map.Append("#..........#.......#");
            Map.Append("#..........#.......#");
            Map.Append("#..........#########");
            Map.Append("#..................#");
            Map.Append("#....##............#");
            Map.Append("#....###...........#");
            Map.Append("#..................#");
            Map.Append("#............#.....#");
            Map.Append("#..................#");
            Map.Append("####################");
        }

        //состояние
        public static void Stats()
        {
            char[] stats = $"X: {Maze._PlayerX}, Y: {Maze._PlayerY}, FPS: {(int)(1 / Maze.ElapsedTime)}".ToCharArray();
            stats.CopyTo(Maze.Screen, 0);
        }

        public static void Draw2D()
        {
            //вывод 2D карты
            for (int x = 0; x < Maze.LabWidth; x++)
            {
                for (int y = 0; y < Maze.LabHeight; y++)
                {
                    Maze.Screen[(y + 1) * Maze.GameWidth + x] = Maze.Map[y * Maze.LabWidth + x];
                }
            }

            //игрок на 2D карте
            Maze.Screen[(int)(Maze._PlayerY + 1) * Maze.GameWidth + (int)(Maze._PlayerX)] = '@';
        }

    }

    public class Player
    {
        public static void Steps()
        {
            if (Console.KeyAvailable)
            {
                var ConsoleKey = Console.ReadKey(true).Key; //считываем с консоли нажатие на кнопку

                switch (ConsoleKey)
                {
                    case ConsoleKey.A:
                        Maze._PlayerC += 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота вправо
                        break;

                    case ConsoleKey.D:
                        Maze._PlayerC -= 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота влево
                        break;

                    case ConsoleKey.W:
                        Maze._PlayerX += 12 * Math.Sin(Maze._PlayerC) * Maze.ElapsedTime; //идем вперед
                        Maze._PlayerY += 12 * Math.Cos(Maze._PlayerC) * Maze.ElapsedTime;

                        if (Maze.Map[(int)Maze._PlayerY * Maze.LabWidth + (int)Maze._PlayerX] == '#') //проверка на стену, нельзя пройти
                        {
                            Maze._PlayerX -= 12 * Math.Sin(Maze._PlayerC) * Maze.ElapsedTime;
                            Maze._PlayerY -= 12 * Math.Cos(Maze._PlayerC) * Maze.ElapsedTime;
                        }
                        break;

                    case ConsoleKey.S:
                        Maze._PlayerX -= 12 * Math.Sin(Maze._PlayerC) * Maze.ElapsedTime; //идем назад
                        Maze._PlayerY -= 12 * Math.Cos(Maze._PlayerC) * Maze.ElapsedTime;

                        if (Maze.Map[(int)Maze._PlayerY * Maze.LabWidth + (int)Maze._PlayerX] == '#') //проверка на стену, нельзя пройти
                        {
                            Maze._PlayerX += 12 * Math.Sin(Maze._PlayerC) * Maze.ElapsedTime;
                            Maze._PlayerY += 12 * Math.Cos(Maze._PlayerC) * Maze.ElapsedTime;
                        }
                        break;
                }
            }
        }
    }

    public class Render3D
    {
        public static void Draw()
        {
            for (int x = 0; x < Maze.GameWidth; x++)
            {
                double RayCorner = Maze._PlayerC + Maze.Fov / 2 - x * Maze.Fov / Maze.GameWidth; //луч род углом наклона

                double RayX = Math.Sin(RayCorner); //с помощью угла узнаем координаты по x
                double RayY = Math.Cos(RayCorner); //с помощью угла узнаем координаты по y

                double DistanceWall = 0; //расстояние до стены
                bool HitWall = false; //попали в стену или нет
                bool IsBound = false; //грань блока или нет
                bool IsMob = false;

                while (!HitWall && DistanceWall < Maze.Depth)
                {
                    DistanceWall += 0.1;

                    int TestX = (int)(Maze._PlayerX + RayX * DistanceWall); //узнаем координаты по x
                    int TestY = (int)(Maze._PlayerY + RayY * DistanceWall); //узнаем координаты по y

                    if (TestX < 0 || TestX >= Maze.Depth + Maze._PlayerX || TestY < 0 || TestY >= Maze.Depth + Maze._PlayerY) //проверка на стену
                    {
                        HitWall = true;
                        DistanceWall = Maze.Depth;
                    }
                    else
                    {
                        char TestCell = Maze.Map[TestY * Maze.LabWidth + TestX];

                        if (TestCell == '#')
                        {
                            HitWall = true;

                            var BoundsVectorList = new List<(double module, double cos)>();

                            for (int tx = 0; tx < 2; tx++)
                            {
                                for (int ty = 0; ty < 2; ty++)
                                {
                                    double vx = TestX + tx - Maze._PlayerX;
                                    double vy = TestY + ty - Maze._PlayerY;

                                    double VectorModule = Math.Sqrt(vx * vx + vy * vy); //находим модуль вектора для грани
                                    double CosCorner = (RayX * vx + RayY * vy) / VectorModule;

                                    BoundsVectorList.Add((VectorModule, CosCorner));
                                }
                            }

                            BoundsVectorList = BoundsVectorList.OrderBy(v => v.module).ToList();

                            double BoundCorner = 0.03 / DistanceWall;

                            if (Math.Acos(BoundsVectorList[0].cos) < BoundCorner || Math.Acos(BoundsVectorList[1].cos) < BoundCorner)
                            {
                                IsBound = true;
                            }
                        }
                        else if (TestCell == 'O')
                        {
                            IsMob = true;
                            HitWall = true;
                        }
                    }
                }

                // рисовка лабиринта(обзора)
                int GameCeiling = (int)(Maze.GameHeight / 2d - Maze.GameHeight * Maze.Fov / DistanceWall); //потолок
                int GameFloor = Maze.GameHeight - GameCeiling; //пол

                //покраска стен в зависимости от близости к игроку
                char WallShade;
                if (IsBound)
                {
                    WallShade = '|';
                }
                else if (DistanceWall < Maze.Depth / 4d)
                {
                    WallShade = '\u2593';
                }
                else if (DistanceWall < Maze.Depth / 3d)
                {
                    WallShade = '\u2593';
                }
                else if (DistanceWall < Maze.Depth / 2d)
                {
                    WallShade = '\u2592';
                }
                else if (DistanceWall < Maze.Depth)
                {
                    WallShade = '\u2591';
                }
                else
                {
                    WallShade = ' ';
                }

                for (int y = 0; y < Maze.GameHeight; y++)
                {
                    if (y <= GameCeiling)
                    {
                        Maze.Screen[y * Maze.GameWidth + x] = ' '; //рисуем потолок
                    }
                    else if (y > GameCeiling && y <= GameFloor)
                    {
                        if (IsMob == true)
                        {
                            char MobShade = '\u2580';
                            Maze.Screen[y * Maze.GameWidth + x] = MobShade; //рисуем моба
                        }
                        else
                        {
                            Maze.Screen[y * Maze.GameWidth + x] = WallShade; //рисуем стены
                        }
                    }
                    else
                    {
                        char FloorShade;
                        double b = 1 - (y - Maze.GameHeight / 2d) / (Maze.GameHeight / 2d);

                        if (b < 0.25)
                        {
                            FloorShade = '#';
                        }
                        else if (b < 0.5)
                        {
                            FloorShade = 'x';
                        }
                        else if (b < 0.75)
                        {
                            FloorShade = '-';
                        }
                        else if (b < 0.9)
                        {
                            FloorShade = '.';
                        }
                        else
                        {
                            FloorShade = ' ';
                        }
                        Maze.Screen[y * Maze.GameWidth + x] = FloorShade; //рисуем пол
                    }
                }
            }
        }
    }

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
    class Program
    {
        static void Main(string[] args)
        {
            Zodiak.Game();
        }
    }
}
