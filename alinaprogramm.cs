using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zodiak_labirint
{
    class Program
    {
        private const int GameWidth = 200; //ширина
        private const int GameHeight = 80; //высота

        private const int LabWidth = 20; //ширина карты лабиринта
        private const int LabHeight = 20; //высота карты лабиринта

        private const double Fov = Math.PI / 3; //угол
        private const double Depth = 16; //глубина, до которой может дойти игрок

        private static double _PlayerX = 1; //координаты игрока по x
        private static double _PlayerY = 1; //координаты игрока по y
        private static double _PlayerC = 7; //угол обзора игрока


        private static readonly char[] Screen = new char[GameHeight * GameWidth]; //содание игровой консоли, экран

        private static readonly StringBuilder Map = new StringBuilder(); //карта

        static void Main(string[] args)
        {
            Console.SetWindowSize(GameWidth, GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(GameWidth, GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            InitMap(); //иницилизация карты

            DateTime DateTimeFrom = DateTime.Now; //считаем время каждой операции

            while (true)
            {
                DateTime DateTimeTo = DateTime.Now; //фиксация времени старта
                double ElapsedTime = (DateTimeTo - DateTimeFrom).TotalSeconds; //каждый раз подсчет времени операции
                DateTimeFrom = DateTime.Now;

                if (Console.KeyAvailable)
                {
                    var ConsoleKey = Console.ReadKey(true).Key; //считываем с консоли нажатие на кнопку

                    switch (ConsoleKey)
                    {
                        case ConsoleKey.A:
                            _PlayerC += 8 * ElapsedTime; //изменяем обзор с помощью поворота вправо
                            break;

                        case ConsoleKey.D:
                            _PlayerC -= 8 * ElapsedTime; //изменяем обзор с помощью поворота влево
                            break;

                        case ConsoleKey.W:
                            _PlayerX += 12 * Math.Sin(_PlayerC) * ElapsedTime; //идем вперед
                            _PlayerY += 12 * Math.Cos(_PlayerC) * ElapsedTime;

                            if (Map[(int)_PlayerY * LabWidth + (int)_PlayerX] == '#') //проверка на стену, нельзя пройти
                            {
                                _PlayerX -= 12 * Math.Sin(_PlayerC) * ElapsedTime;
                                _PlayerY -= 12 * Math.Cos(_PlayerC) * ElapsedTime;
                            }
                            break;

                        case ConsoleKey.S:
                            _PlayerX -= 12 * Math.Sin(_PlayerC) * ElapsedTime; //идем назад
                            _PlayerY -= 12 * Math.Cos(_PlayerC) * ElapsedTime;

                            if (Map[(int)_PlayerY * LabWidth + (int)_PlayerX] == '#') //проверка на стену, нельзя пройти
                            {
                                _PlayerX += 12 * Math.Sin(_PlayerC) * ElapsedTime;
                                _PlayerY += 12 * Math.Cos(_PlayerC) * ElapsedTime;
                            }
                            break;
                    }
                }

                for (int x = 0; x < GameWidth; x++)
                {
                    double RayCorner = _PlayerC + Fov / 2 - x * Fov / GameWidth; //луч род углом наклона

                    double RayX = Math.Sin(RayCorner); //с помощью угла узнаем координаты по x
                    double RayY = Math.Cos(RayCorner); //с помощью угла узнаем координаты по y

                    double DistanceWall = 0; //расстояние до стены
                    bool HitWall = false; //попали в стену или нет
                    bool IsBound = false; //грань блока или нет

                    while (!HitWall && DistanceWall < Depth)
                    {
                        DistanceWall += 0.1;

                        int TestX = (int)(_PlayerX + RayX * DistanceWall); //узнаем координаты по x
                        int TestY = (int)(_PlayerY + RayY * DistanceWall); //узнаем координаты по y

                        if (TestX < 0 || TestX >= Depth + _PlayerX || TestY < 0 || TestY >= Depth + _PlayerY) //проверка на стену
                        {
                            HitWall = true;
                            DistanceWall = Depth;
                        }
                        else
                        {
                            char TestCell = Map[TestY * LabWidth + TestX];

                            if (TestCell == '#')
                            {
                                HitWall = true;

                                var BoundsVectorList = new List<(double module, double cos)>();

                                for (int tx = 0; tx < 2; tx++)
                                {
                                    for (int ty = 0; ty < 2; ty++)
                                    {
                                        double vx = TestX + tx - _PlayerX;
                                        double vy = TestY + ty - _PlayerY;

                                        double VectorModule = Math.Sqrt(vx * vx + vy * vy);
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
                        }
                    }

                    // рисовка лабиринта(обзора)
                    int GameCeiling = (int)(GameHeight / 2d - GameHeight * Fov / DistanceWall); //потолок
                    int GameFloor = GameHeight - GameCeiling; //пол

                    //покраска стен в зависимости от близости к игроку
                    char WallShade;
                    if (IsBound)
                    {
                        WallShade = '|';
                    }
                    else if (DistanceWall < Depth / 4d)
                    {
                        WallShade = '\u2588';
                    }
                    else if (DistanceWall < Depth / 3d)
                    {
                        WallShade = '\u2593';
                    }
                    else if (DistanceWall < Depth / 2d)
                    {
                        WallShade = '\u2592';
                    }
                    else if (DistanceWall < Depth)
                    {
                        WallShade = '\u2591';
                    }
                    else
                    {
                        WallShade = ' ';
                    }

                    for (int y = 0; y < GameHeight; y++)
                    {
                        if (y <= GameCeiling)
                        {
                            Screen[y * GameWidth + x] = ' '; //рисуем потолок
                        }
                        else if (y > GameCeiling && y <= GameFloor)
                        {
                            Screen[y * GameWidth + x] = WallShade; //рисуем стены
                        }
                        else
                        {
                            char FloorShade;
                            double b = 1 - (y - GameHeight / 2d) / (GameHeight / 2d);

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
                            Screen[y * GameWidth + x] = FloorShade; //рисуем пол
                        }
                    }
                }
                char[] stats = $"X: {_PlayerX}, Y: {_PlayerY}, FPS: {(int) (1 / ElapsedTime)}".ToCharArray();
                stats.CopyTo( Screen, 0 );

                for (int x = 0; x < LabWidth; x++)
                {
                    for (int y = 0; y < LabHeight; y++)
                    {
                        Screen[(y + 1) * GameWidth + x] = Map[y * LabWidth + x];
                    }
                }

                Screen[(int)(_PlayerY + 1) * GameWidth + (int)(_PlayerX)] = '@';
                Console.SetCursorPosition(0, 0);
                Console.Write(Screen);
            }
        }

        private static void InitMap()
        {
            Map.Clear();
            Map.Append("####################");
            Map.Append("#..................#");
            Map.Append("#....#.............#");
            Map.Append("#..................#");
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
    }
}