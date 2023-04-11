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

        public static void Steps(Character player)
        {
            if (Console.KeyAvailable)
            {
                var ConsoleKey = Console.ReadKey(true).Key; //считываем с консоли нажатие на кнопку

                switch (ConsoleKey)
                {
                    case ConsoleKey.A:
                        player.C += 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота вправо
                        break;
                        
                    case ConsoleKey.D:
                        player.C -= 8 * Maze.ElapsedTime; //изменяем обзор с помощью поворота влево
                        break;

                    case ConsoleKey.W:
                        player.X += 12 * Math.Sin(player.C) * Maze.ElapsedTime; //идем вперед
                        player.Y += 12 * Math.Cos(player.C) * Maze.ElapsedTime;

                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            player.X -= 12 * Math.Sin(player.C) * Maze.ElapsedTime;
                            player.Y -= 12 * Math.Cos(player.C) * Maze.ElapsedTime;
                        }
                        break;

                    case ConsoleKey.S:
                        player.X -= 12 * Math.Sin(player.C) * Maze.ElapsedTime; //идем назад
                        player.Y -= 12 * Math.Cos(player.C) * Maze.ElapsedTime;


                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            player.X += 12 * Math.Sin(player.C) * Maze.ElapsedTime;
                            player.Y += 12 * Math.Cos(player.C) * Maze.ElapsedTime;
                        }
                        break;


                }
            }
        }
    }
}
