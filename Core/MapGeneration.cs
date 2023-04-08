using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Zodiac.Core
{
    public class MapGeneration //генерация 2D карты
    {
        public static char[,] MapArray = new char[20, 20];

        public static char[,] Filing()
        {
            for (int i = 0; i < 20; i++) //заполнение решетками
            {
                for (int j = 0; j < 20; j++)
                {
                    MapArray[i, j] = '#';
                }
            }
            return MapArray;
        }
        public static char[,] Floor(Monster monster1, Monster monster2, Monster monster3)
        {
            Random ran = new Random();
            int k;
            int n = 0;
            while (n != 10)
            {
                for (int i = 1; i < 19; i++) //прокладывание пути
                {
                    for (int j = 1; j < 19; j++)
                    {
                        if (i == 0 || j == 0 || i == 19 || j == 19)
                        {
                            MapArray[i, j] = '#';
                        }
                        else
                        {
                            k = ran.Next(1, 5);
                            Console.WriteLine(k);
                            if (i != 0 || j != 0 || i != 19 || j != 19)
                            {
                                switch (k)
                                {
                                    case 1:
                                        MapArray[i, j] = '.';
                                        if (i + 1 != 19)
                                        {
                                            MapArray[i + 1, j] = '.';
                                            i++;
                                        }

                                        break;
                                    case 2:
                                        MapArray[i, j] = '.';
                                        if (j + 1 != 19)
                                        {
                                            MapArray[i, j + 1] = '.';
                                            j++;
                                        }

                                        break;
                                    case 3:
                                        MapArray[i, j] = '.';
                                        if (i - 1 != 0)
                                        {
                                            MapArray[i - 1, j] = '.';
                                            i++;
                                        }

                                        break;
                                    case 4:
                                        MapArray[i, j] = '.';
                                        if (j - 1 != 0)
                                        {
                                            MapArray[i, j - 1] = '.';
                                            j++;
                                        }

                                        break;
                                }
                            }


                        }
                    }
                }
                n++;
            }
            MethodsForMonsters.AddMonster_rand(monster1, monster2, monster3, MethodsForMonsters.MonsterArray(monster1, monster2, monster3));
            return MapArray;
        }
    }

}
