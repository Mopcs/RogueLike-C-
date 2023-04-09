using System;
using Game_Zodiac._Vector2;

namespace Game_Zodiac._Renderer2D
{
    public class Text
    {
        public string text;
        public Vector2 position;
        public ConsoleColor color;

        public Text(string text, Vector2 position, ConsoleColor color = ConsoleColor.White)
        {
            this.text = text;
            this.position = position;
            this.color = color;
        }
    }
}
