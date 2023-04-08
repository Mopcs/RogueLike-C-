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
                    case ConsoleKey.A:
                        Maze.character1.C += 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота вправо
                        break;

                    case ConsoleKey.D:
                        Maze.character1.C -= 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота влево
                        break;

                    case ConsoleKey.W:
                        Maze.character1.X += 12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime; //идем вперед
                        Maze.character1.Y += 12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime;

                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            Maze.character1.X -= 12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime;
                            Maze.character1.Y -= 12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime;
                        }
                        break;

                    case ConsoleKey.S:
                        Maze.character1.X -= 12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime; //идем назад
                        Maze.character1.Y -= 12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime;

                        if (Maze.Map[(int)Maze.character1.Y * Maze.LabWidth + (int)Maze.character1.X] == '#') //проверка на стену, нельзя пройти
                        {
                            Maze.character1.X += 12 * Math.Sin(Maze.character1.C) * Maze.ElapsedTime;
                            Maze.character1.Y += 12 * Math.Cos(Maze.character1.C) * Maze.ElapsedTime;
                        }
                        break;


                }
            }
        }
    }
}
