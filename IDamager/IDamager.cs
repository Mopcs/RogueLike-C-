using Game_Zodiac.Core;


namespace Game_Zodiac
{
    public interface IDamager
    {
        void Hit(Character target);
        void HitWithWeapon(Monster target);
    }
}

