using System;

namespace Game_Zodiac.Core
{
    public static class MethodsForMonsters
    {
        public static Monster[] MonsterArray(Monster Monster1, Monster Monster2, Monster Monster3)
        {
            Monster[] monster = new Monster[10]; // осздаем массив для монстров

            for (int i = 0; i < 3; i++)
            {
                monster[i] = Monster1;
            }
            for (int i = 3; i < 6; i++)
            {
                monster[i] = Monster2;
            }
            for (int i = 6; i < 10; i++)
            {
                monster[i] = Monster3;
            }

            return monster;
        }
        public static char[,] AddMonster_rand(Monster Monster1, Monster Monster2, Monster Monster3, Monster[] monster)//Maze.Map туда кинуть
        {
            
            bool MosterPlace = false; // проверяем если монстры

            if (!MosterPlace) { // если монстров нет

                int MX;
                int MY;

                Random rnd1 = new Random();

                for (int i = 0; i < monster.Length; i++)
                {
                    
                    MX = rnd1.Next(5, 19);
                    MY = rnd1.Next(5, 19);
                    Console.WriteLine(MX + "   " + MY);

                    if (MapGeneration.MapArray[MX, MY] != '#')
                    {

                        monster[i].X = MX;
                        monster[i].Y = MY;
                        Console.WriteLine(monster[i].X + "        " + monster[i].Y);
                        MapGeneration.MapArray[(int) monster[i].X, (int) monster[i].Y] = monster[i].Symbol;
                        Console.WriteLine(monster[i].Symbol);
                    }
                    //Console.WriteLine("Monster " + i + " new coordinates: " + monster[i].X + ", " + monster[i].Y);


                }

                MosterPlace = true;
                
            }

            return MapGeneration.MapArray;
        }

        public static void MonsterMovement(Monster[] monster, Character player) // движение монстров 
        {
            int DisY, DisX;

            for (int i = 0; i < monster.Length; i++)
            {
                Console.WriteLine(monster[i].X);

                System.Threading.Thread.Sleep(1000);
                DisY = Math.Abs((int)monster[i].Y - (int)player.Y);
                DisX = Math.Abs((int)(int)monster[i].X - (int)player.X);

                if (DisY < 5 && DisX < 5)
                {
                    monster[i].Awake = true;

                }

                else
                {
                    monster[i].Symbol = '!';
                    monster[i].Awake = false;
                    continue;
                }

                int DirY = (int) monster[i].Y;
                int DirX = (int) monster[i].X;

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
                        monster[i].X -= 1;

                    else
                        DirX += 1;
                }

                // дживжение по диагонали
                if (MapGeneration.MapArray[DirX, DirY] == '#')
                {
                    DirY = (int)monster[i].Y;
                    DirX = (int)monster[i].X;

                    if (DirY > player.Y)
                        DirY -= 1;
                    else
                        DirY = +1;

                    if (DirX > player.X)
                        DirX -= 1;
                    else
                        DirX += 1;
                }

                // если все еще не удается к догонке игрока (инвертивное движение)
                if (MapGeneration.MapArray[DirX, DirY] == '#')
                {
                    DirY = (int)monster[i].Y;
                    DirX = (int)monster[i].X;

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

                if (MapGeneration.MapArray[DirX, DirY] != '#')
                {
                    MapGeneration.MapArray[(int)monster[i].X, (int)monster[i].Y] = '.';
                    monster[i].X = DirX;
                    monster[i].Y = DirY;


                    MapGeneration.MapArray[(int)monster[i].X, (int)monster[i].Y] = monster[i].Symbol;

                }
            }
        }

    }
}
    
