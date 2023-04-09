using System;
using Game_Zodiac._Vector2;

namespace Game_Zodiac._Renderer2D
{
    internal class Rectangle
    {
        public Vector2 position;
        public Vector2 size;
        public char drawingSymbol;
        public ConsoleColor color;

        public Rectangle(Vector2 position, Vector2 size, char drawingSymbol = 'X', ConsoleColor color = ConsoleColor.White)
        {
            this.position = position;
            this.size = size;
            this.drawingSymbol = drawingSymbol;
            this.color = color;
        }
    }
}
