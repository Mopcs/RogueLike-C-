using System;
using Roguelikej.Monsters;

namespace Roguelikej.Core
{

    public class MethodsForMonsters
    {
        private readonly List<EarthMonsters> _monsters;
        public MethodsForMonsters()
        {
            // инициализируем все списки используем list вместо массива у нас 10 монстров 
            _monsters = new List<EarthMonsters>(10);

        }
        public void AddMonster(EarthMonsters monster)
        {
            _monsters.Add(monster);

        }
        public char[,] AddMonster_rand()//Maze.Map туда кинуть 
        {
            Monster[] monster = new Monster[10]; // осздаем массив для монстров

            bool MosterPlace = false; // проверяем если монстры

            if (!MosterPlace) { // если монстров нет

                int MX;
                int MY;

                for (int i = 0; i < monster.Length; i++)
                {
                    do
                    {
                        Random rnd1 = new Random();
                        MX = rnd1.Next(1, 19);
                        MY = rnd1.Next(1, 19);
                    }
                    while (Maze.Map[MX][MY] != ' ');

                    monster[i].X = MX;
                    monster[i].Y = MY;

                    Maze.Map[monster[i].X][monster[i].Y] = monster.Symbol;// gjxtve yt dblbn

                }
                
                MosterPlace = true;

            }
            MonsterMovement(monster );

            return Maze.Map;
        }
        public static void MonsterMovement(Monster[] monster, FirePlayer player) // движение монстров 
        {
            int DisY, DisX;

            for (int i = 0; i < monster.Length; i++)
            {
                DisY = Math.Abs(monster[i].Y - player.Y);
                DisX = Math.Abs(monster[i].X - player.X);

                if (DisY < 5 && DisX < 5)
                    monster[i].Awake = true;

                if (monster[i].Awake == false)
                    continue;

                int DirY = monster[i].Y;
                int DirX = monster[i].X;

                // движение в право и влево
                if (DisY > DisX)
                {
                    if (DirY > player.Y)
                        DirY -= 1;
                    else
                        DirY += 1;

                }
                else
                {
                    if (DirX > player.X)
                        DirX -= 1;

                    else
                        DirX += 1;
                }
                // дживжение по диагонали
                if (Maze.Map[DirX][DirY] == '#')
                {
                    DirY = monster[i].Y;
                    DirX = monster[i].X;

                    if (DirY > player.Y)
                        DirY -= 1;
                    else
                        DirY =+1;

                    if (DirX > player.X)
                        DirX -=1;
                    else
                        DirX +=1;
                }

                // если все еще не удается к догонке игрока (инвертивное движение)
                if (Maze.Map[DirX][DirY] == '#')
                {
                    DirY = monster[i].Y;
                    DirX = monster[i].X;

                    if (DisY > DisX)
                    {
                        if (DirX > player.X)
                            DirX -= 1;
                        else
                            DirX += 1;
                    }
                    else
                    {
                        if (DirY > player.Y)
                            DirY -= 1;
                        else
                            DirY = +1;
                    }
                  
                }

                if (Maze.Map[DirX][DirY] == ' ')
                {
                    Maze.Map[monster[i].X][monster[i].Y] = ' ';

                    monster[i].Y = DirY;
                    monster[i].X = DirX;

                    Maze.Map[monster[i].X][monster[i].Y] = monster.Symbol;
                }




            }
        }

    }
}

