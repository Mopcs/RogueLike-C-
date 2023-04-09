using System;


namespace Game_Zodiac
{
	public interface IInterfaces
	{
        string Name { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set;}
        int Armor { get; set; }
        int Key { get; set; }
        int Gold { get; set; }
        bool Awake { get; set; }
    }
}

