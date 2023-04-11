using System;
namespace Game_Zodiac.Core
{
    public class Monster : Character
    {
        private int _attack;

        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }

        public void Hit(Character target)
        {
            //Console.WriteLine(name + " hits " + target.name + " for " + attackDamage + " damage!");
            target.ApplyDamage(Attack);
        }

        public static void MonsterMovement(Monster[] monster, Character player) // движение монстров 
        {
            int DisY, DisX;

            for (int i = 0; i < monster.Length; i++)
            {
                //Console.WriteLine(monster[i].X);

                //System.Threading.Thread.Sleep(1000);
                DisY = Math.Abs((int)monster[i].Y - (int)player.Y);
                DisX = Math.Abs((int)monster[i].X - (int)player.X);

                if (DisY < 5 && DisX < 5)
                {
                    monster[i].Awake = true;
                    

                }

                else
                {
                    monster[i].Awake = false;
                }

                int DirY = (int)monster[i].Y;
                int DirX = (int)monster[i].X;

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

