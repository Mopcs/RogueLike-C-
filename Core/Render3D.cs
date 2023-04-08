using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Game_Zodiac.Core
{
    public class Render3D
    {
        public static void Draw(Character player, Monster monster1, Monster monster2, Monster monster3)
        {
            for (int x = 0; x < Maze.GameWidth; x++)
            {
                double RayCorner = Maze.character1.C + Maze.Fov / 2 - x * Maze.Fov / Maze.GameWidth; //луч род углом наклона

                double RayX = Math.Sin(RayCorner); //с помощью угла узнаем координаты по x
                double RayY = Math.Cos(RayCorner); //с помощью угла узнаем координаты по y

                double DistanceWall = 0; //расстояние до стены
                bool HitWall = false; //попали в стену или нет
                bool IsBound = false; //грань блока или нет
                bool IsMob = false;

                while (!HitWall && DistanceWall < Maze.Depth)
                {
                    DistanceWall += 0.1;

                    int TestX = (int)(Maze.character1.X + RayX * DistanceWall); //узнаем координаты по x
                    int TestY = (int)(Maze.character1.Y + RayY * DistanceWall); //узнаем координаты по y

                    if (TestX < 0 || TestX >= Maze.Depth + Maze.character1.X || TestY < 0 || TestY >= Maze.Depth + Maze.character1.Y) //проверка на стену
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
                                    double vx = TestX + tx - Maze.character1.X;
                                    double vy = TestY + ty - Maze.character1.Y;

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

                        else if (TestCell == monster1.Symbol || TestCell == monster2.Symbol || TestCell == monster3.Symbol)
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
                            if (Maze.Screen[y * Maze.GameWidth + x] == monster1.Symbol)
                            {
                                char MobShade1 = monster1.Symbol;
                                string Mob1 = MobShade1.ToString();
                                Maze.Screen[y * Maze.GameWidth + x] = MobShade1; //рисуем моба
                            }
                            else if (Maze.Screen[y * Maze.GameWidth + x] == monster2.Symbol)
                            {
                                char MobShade2 = monster2.Symbol;
                                string Mob1 = MobShade2.ToString();
                                Maze.Screen[y * Maze.GameWidth + x] = MobShade2; //рисуем моба
          
                            }
                            else if (Maze.Screen[y * Maze.GameWidth + x] == monster3.Symbol)
                            {
                                char MobShade3 = monster3.Symbol;
                                string Mob1 = MobShade3.ToString();
                                Maze.Screen[y * Maze.GameWidth + x] = MobShade3; //рисуем моба
                            }
                            else
                            {
                                Maze.Screen[y * Maze.GameWidth + x] = ' ';
                            }
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

}
