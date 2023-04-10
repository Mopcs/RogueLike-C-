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

            if (!MosterPlace)
            { // если монстров нет

                int MX;
                int MY;

                Random rnd1 = new Random();

                for (int i = 0; i < monster.Length; i++)
                {

                    MX = rnd1.Next(5, 19);
                    MY = rnd1.Next(5, 19);
                    //Console.WriteLine(MX + "   " + MY);

                    if (MapGeneration.MapArray[MX, MY] != '#')
                    {
                        /*monster[0].X = 2;
                        monster[0].Y = 1;*/

                        monster[i].X = MX;
                        monster[i].Y = MY;
                        //Console.WriteLine(monster[i].X + "        " + monster[i].Y);
                        MapGeneration.MapArray[(int)monster[i].X, (int)monster[i].Y] = monster[i].Symbol;
                        //Console.WriteLine(monster[i].Symbol);
                        //MapGeneration.MapArray[(int)monster[0].X, (int)monster[0].Y] = monster[0].Symbol;
                    }
                    //Console.WriteLine("Monster " + i + " new coordinates: " + monster[i].X + ", " + monster[i].Y);


                }

                MosterPlace = true;

            }

            return MapGeneration.MapArray;
        }
    }
}
    
