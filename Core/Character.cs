using System;
using Game_Zodiac._HealingItem;
using Game_Zodiac._Weapon;
using Game_Zodiac._Item;

namespace Game_Zodiac.Core
{
    public class Character : IInterfaceDrawer, IInterfaces, IDamageable, IHealingeable
    {
        public char Symbol { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double C { get; set; }
        public bool Awake { get; set; }

        public string JsonPath { get; set; }
        public int GoldLevel { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public HealingItem CurrentPotion { get; set; }

        public Inventory inventory = new Inventory();

        public Character(double _X, double _Y, double _C)
        {
            X = _X;
            Y = _Y;
            C = _C;
        }
        public Character()
        {

        }

        
        private string _name;
        private int _lineOfSight;
        private int _health;
        private int _maxHealth;
        private int _key;
        private int _armor;
        private int _additionArmor = 5;
        private int _gold;

        public int AdditionalArmor => _additionArmor;

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

        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
            set
            {
                _maxHealth = value;
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


        public void HitWithWeapon(Monster target)
        {
            //Console.WriteLine(name + " hits " + target.name + " for " + CurrentWeapon.Damage + " damage!");
            target.ApplyDamage(CurrentWeapon.Damage);
        }

        public void ApplyDamage(int damage, bool isDefence = false)
        {
            int resultArmor = isDefence ? Armor + AdditionalArmor : Armor;
            int actualDamage = Math.Max(damage - resultArmor, 0);
            Health -= actualDamage;
            if (Health < 0)
            {
                Health = 0;
            }
            //Console.WriteLine(name + " takes " + actualDamage + " damage!");
        }

        public void TakeHealing(HealingItem item)
        {
            Health += item.healingAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            //Console.WriteLine(name + " heals for " + item.healingAmount + " points!");
        }

        public void TakeWeapon(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }

        public void TakePotion(HealingItem potion)
        {
            CurrentPotion = potion;
        }

        public void BuyItem(Item item, Trader trader)
        {
            if (trader.traderInventory.items.Contains(item))
            {
                if (Gold >= trader.costOfItem)
                {
                    inventory.AddItem(item);
                    trader.traderInventory.RemoveItem(item);
                    Gold -= trader.costOfItem;
                    Console.WriteLine(Name + " bought " + item.name + " from Trader for " + trader.costOfItem + " gold.");
                }

                else
                {
                    Console.WriteLine("You don't have enough gold to buy " + item.name + ".");
                }
            }
            else
            {
                Console.WriteLine("Trader doesn't have " + item.name + " for sale.");
            }
        }
    }
}
