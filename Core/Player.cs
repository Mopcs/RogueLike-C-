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
                    case ConsoleKey.D:
                        player.C += (int) Math.PI / 9; //изменяем обзор с помощью поворота вправо
                        //player.X -= (int)(12 * Math.Sin(player.C) * Maze.ElapsedTime);
                        player.X -= 1;
                        //player.Y += 1;
                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //player.X += (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime);
                            //player.Y -= (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime);
                            player.X += 1;
                            //player.Y -= 1;
                        }
                        break;

                    case ConsoleKey.A:
                        player.C -= (int) Math.PI / 9; //изменяем обзор с помощью поворота влево
                        //player.X += (int)(12 * Math.Sin(player.C) * Maze.ElapsedTime);
                        player.X += 1;
                        //player.Y += 1;
                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //player.X -= (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime);
                            //player.Y -= (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime);
                            player.X -= 1;
                            //player.Y -= 1;
                        }
                        break;

                    case ConsoleKey.W:
                        //player.X += (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime); //идем вперед
                        //player.Y += (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime);
                        //player.X += 1;
                        player.Y += 1;
                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //player.X -= (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime);
                            //player.Y -= (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime);
                            //player.X -= 1;
                            player.Y -= 1;
                        }
                        break;

                    case ConsoleKey.S:
                        //player.X -= (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime); //идем назад
                        //player.Y -= (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime);
                        //player.X -= 1;
                        player.Y -= 1;
                        if (Maze.Map[(int)player.Y * Maze.LabWidth + (int)player.X] == '#') //проверка на стену, нельзя пройти
                        {
                            //player.X += (int) (12 * Math.Sin(player.C) * Maze.ElapsedTime);
                            //player.Y += (int) (12 * Math.Cos(player.C) * Maze.ElapsedTime) ;
                            //player.X += 1;
                            player.Y += 1;
                        }
                        break;


                }
            }
        }
    }
}
