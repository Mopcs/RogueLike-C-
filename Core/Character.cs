using ConsoleApp8.Interfaces;
using RLNET;
using RogueSharp;
using System;

namespace ConsoleApp8.Core
{
    internal class Character
    {
        public string Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

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

        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /*public void DrawPerson(Character person)
        {
            Screen[(int)(Y + 1) * GameWidth + (int)(X)] = Symbol;
            Console.SetCursorPosition(0, 0);
            Console.Write(Screen);
        }*/

        

    }
}
