using System;
using Game_Zodiac.Interfaces;


namespace Game_Zodiac.Core
{
    public class Character : IInterfaceDrawer, IInterfaces
    { 
        public char Symbol { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double C { get; set; }
        public bool Awake { get; set; }
        public Character(double _X, double _Y, double _C)
        {
            X = _X;
            Y = _Y;
            C = _C;
        }
        public Character()
        {

        }



        private int _attack;
        private string _name;
        private int _lineOfSight;
        private int _health;
        private int _maxHealh;
        private int _key;
        private int _armor;
        private int _gold;
        

        public int Gold
        {
            get
            {
                return _gold;
            }
            set 
            {
                _gold = value;
            }
        }

        public int Armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
            }
        }

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

        public int Health
        {
            get
            {
                return _health;

            }
            set
            {
                _health = value;
            }
        }

        public int MaxHealh
        {
            get
            {
                return _maxHealh;
            }
            set
            {
                _maxHealh = value;
            }
        }

        public int Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public int LineOfSight
        {
            get
            {
                return _lineOfSight;
            }
            set
            {
                _lineOfSight = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public void Draw()
        {
        }

        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /*public void DrawPerson(Character person)
        {
            Screen[(int)(Y + 1) * GameWidth + (int)(X)] = Symbol;
            Console.SetCursorPosition(0, 0);
            Console.Write(Screen);
        }*/

        

    }
}
