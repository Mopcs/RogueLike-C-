using Game_Zodiac._Battle;
using Game_Zodiac._Pattern;
using Game_Zodiac._Vector2;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Game_Zodiac._Renderer2D
{
    internal class Renderer2D
    {
        public const int MAX_WINDOW_WIDTH = 213;
        public const int MAX_WINDOW_HEIGHT = 50;
   

        private int _windowWidth;
        public int WindowWidth
        {
            private set
            {
                _windowWidth = Math.Min(value, MAX_WINDOW_WIDTH);
            }
            get
            {
                return _windowWidth;
            }
        }

        private int _windowHeight;
        public int WindowHeight
        {
            private set
            {
                _windowHeight = Math.Min(value, MAX_WINDOW_HEIGHT);
            }
            get
            {
                return _windowHeight;
            }
        }

        private char[][] _screen;
        private ConsoleColor[][] _screenColors;

        public Renderer2D(int windowWidth, int windowHeight)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

            Initialize();
        }

        public Renderer2D()
        {
            WindowWidth = 256;
            WindowHeight = 256;

            Initialize();
        }

        public void SetActive()
        {
            // Создание буфера консоли и установка его размеров
            Stream consoleStream = Console.OpenStandardOutput();
            StreamWriter streamWriter = new StreamWriter(consoleStream);
            streamWriter.AutoFlush = true;

            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(WindowWidth, WindowHeight);
            Console.SetOut(streamWriter);
        }

        public void SetConsoleTitle(string title)
        {
            Console.Title = title;
        }

        public void UpdateBuffer()
        {
            Console.Clear();

            for (var h = 0; h < WindowHeight - 1; h++)
            {
                for (var w = 0; w < WindowWidth; w++)
                {
                    Console.ForegroundColor = _screenColors[h][w];
                    Console.Write(_screen[h][w]);
                }
            }


            ClearScreen();
        }

        public void DrawText(Text textBar)
        {
            for (var i = textBar.position.x; i < WindowWidth && i - textBar.position.x < textBar.text.Length; i++)
            {
                _screen[textBar.position.y][i] = textBar.text[i - textBar.position.x];
                _screenColors[textBar.position.y][i] = textBar.color;
            }
        }

        public void DrawMultiLineText(Text textBar)
        {
            for (var i = textBar.position.x; i < WindowWidth && i - textBar.position.x < textBar.text.Length; i++)
            {
                _screen[textBar.position.y + 1][i] = textBar.text[i - textBar.position.x];
                _screenColors[textBar.position.y][i] = textBar.color;
            }
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            rectangle.position = new Vector2(CustomMath.Clamp(rectangle.position.x, 0, WindowWidth), CustomMath.Clamp(rectangle.position.y, 0, WindowHeight));

            for (var h = rectangle.position.y; h < WindowHeight && h < rectangle.size.y + rectangle.position.y; h++)
            {
                for (var w = rectangle.position.x; w < WindowWidth && w < rectangle.size.x + rectangle.position.x; w++)
                {
                    _screen[h][w] = rectangle.drawingSymbol;
                    _screenColors[h][w] = rectangle.color;
                }
            }
        }

        public void DrawHealthBar(HealthBar healthbar)
        {
            Vector2 size = healthbar.size;
            Vector2 pos = healthbar.position;
            int remainingHealthBarWidth = (int)Math.Round(size.x * ((float)healthbar.currentHealth / (float)healthbar.maxHealth));
            int missingHealthBarWidth = size.x - remainingHealthBarWidth;


            size.x = remainingHealthBarWidth;
            DrawRectangle(new Rectangle(pos, size, '█', ConsoleColor.Green));
            size.x = missingHealthBarWidth;
            pos.x += remainingHealthBarWidth;
            DrawRectangle(new Rectangle(pos, size, ' ')); 
        }

        public void DrawFromJson(Vector2 position, string jsonPath, string propertyName)
        {
            var obj = JsonConvert.DeserializeObject<Pattern>(File.ReadAllText(jsonPath));

            var property = typeof(Pattern).GetProperty(propertyName);
 
            var values = (string[])property.GetValue(obj, null);

            for (var i = 0; i < values.Length; i++)
            {
                DrawText(new Text(values[i], new Vector2(position.x, position.y + i)));
            }
        }

        public void ClearScreen()
        {
            for (var i = 0; i < WindowHeight - 1; i++)
            {
                for (var j = 0; j < WindowWidth; j++)
                {
                    _screen[i][j] = ' ';
                }
            }
        }

        private string GetScreenAsString()
        {
            string result = "";

            foreach (var row in _screen)
            {
                foreach (var symbol in row)
                {
                    result += symbol;
                }
            }

            return result;
        }

        private void Initialize()
        {
            _screen = new char[WindowHeight][];

            for (var i = 0; i < WindowHeight; i++)
            {
                _screen[i] = new char[WindowWidth];
            }

            _screenColors = new ConsoleColor[WindowHeight][];

            for (var i = 0; i < WindowHeight; i++)
            {
                _screenColors[i] = new ConsoleColor[WindowWidth];
                for (int j = 0; j < WindowWidth; j++)
                {
                    _screenColors[i][j] = ConsoleColor.White;
                }
            }
        }
    }
}
