using System;
using Roguelikej.Monsters;

namespace Roguelikej.Core
{
    
    public class MethodsForMonsters
    {
        private readonly List<Monster> _monsters;
        public MethodsForMonsters()
        {
            // инициализируем все списки используем list вместо массива у нас 10 монстров 
            _monsters = new List<Monster>(10);
            
        }
        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
           
        }
        public void AddMonster_rand( )//Maze.Map туда кинуть 
        {
            int MosterPlace=0;
            if (MosterPlace != 0) {
                int MX;
                int MY;

                Random rnd = new Random();
                var numberOfMonsters = rnd.Next(1,10);
                for (int i = 0; i < numberOfMonsters; i++)
                {
                    do
                    {
                        Random rnd1 = new Random();
                        MX = rnd1.Next(20, 190);
                        MY = rnd1.Next(20, 70);
                    }
                    while (Maze.Map[MX][MY] != ' ');

                    var monster = WaterMonsters.Create(1);
                    monster.X = MX;
                    monster.Y = MY;
                    _map.AddMonster(monster);

                    _monsters[i].X = MX;
                    _monsters[i].Y = MY;
                   
                    Maze.Map[_monsters[i].X][_monsters[i].Y] = _monsters.Symbol;// gjxtve yt dblbn

                }
                MosterPlace = 1; 
            }

        }


    }
}

