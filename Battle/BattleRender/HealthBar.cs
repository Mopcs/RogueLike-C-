using Game_Zodiac._Vector2;

namespace Game_Zodiac._Battle
{
    public class HealthBar
    {
        public Vector2 position;
        public Vector2 size;
        public int currentHealth;
        public int maxHealth;

        public HealthBar(Vector2 position, Vector2 size, int currentHealth, int maxHealth)
        {
            this.position = position;
            this.size = size;
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }
    }
}
