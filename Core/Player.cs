using System;

namespace Game_Zodiac.Core
{
    public class Player
    {
        public string player_class;

        public Player(string _player_class)
        {
            player_class = _player_class;
        }

        public static void Steps()
        {
            if (Console.KeyAvailable)
            {
                var ConsoleKey = Console.ReadKey(true).Key; //считываем с консоли нажатие на кнопку

                switch (ConsoleKey)
                {
                    case ConsoleKey.D:
                        Maze.character1.C += (int) Math.PI / 9; //изменяем обзор с помощью поворота вправо
                        //Maze.character1.X -= (int)(12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                        Maze.character1.X -= 1;
                        //Maze.character1.Y += 1;
                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //Maze.character1.X += (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                            //Maze.character1.Y -= (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime);
                            Maze.character1.X += 1;
                            //Maze.character1.Y -= 1;
                        }
                        break;

                    case ConsoleKey.A:
                        Maze.character1.C -= (int) Math.PI / 9; //изменяем обзор с помощью поворота влево
                        //Maze.character1.X += (int)(12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                        Maze.character1.X += 1;
                        //Maze.character1.Y += 1;
                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //Maze.character1.X -= (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                            //Maze.character1.Y -= (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime);
                            Maze.character1.X -= 1;
                            //Maze.character1.Y -= 1;
                        }
                        break;

                    case ConsoleKey.W:
                        //Maze.character1.X += (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime); //идем вперед
                        //Maze.character1.Y += (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime);
                        //Maze.character1.X += 1;
                        Maze.character1.Y += 1;
                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //Maze.character1.X -= (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                            //Maze.character1.Y -= (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime);
                            //Maze.character1.X -= 1;
                            Maze.character1.Y -= 1;
                        }
                        break;

                    case ConsoleKey.S:
                        //Maze.character1.X -= (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime); //идем назад
                        //Maze.character1.Y -= (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime);
                        //Maze.character1.X -= 1;
                        Maze.character1.Y -= 1;
                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //Maze.character1.X += (int) (12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime);
                            //Maze.character1.Y += (int) (12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime) ;
                            //Maze.character1.X += 1;
                            Maze.character1.Y += 1;
                        }
                        break;


                }
            }
        }
    }
}
