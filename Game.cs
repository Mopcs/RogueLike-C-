using Game_Zodiac;
using System;
using static System.Console;

namespace Game_Zodiak
{
    class Game
    {
          

        public static void Start()
        {
            Console.SetWindowSize(Maze.GameWidth, Maze.GameHeight); //размер окна по заданным параматрам
            Console.SetBufferSize(Maze.GameWidth, Maze.GameHeight); //размер буфера по заданным параметрам

            Console.CursorVisible = false; //выключение курсора

            Title = "Zodiac";
            RunMenu();

            // WriteLine("нажмите любую клавишу для выхода");
            // ReadKey(true);
        }
        public static void RunMenu()
        { //метод запуска главного меню
          //ANCI Shadow
            string tip = @" ███████╗ ██████╗ ██████╗ ██╗ █████╗  ██████╗
                                                     ╚══███╔╝██╔═══██╗██╔══██╗██║██╔══██╗██╔════╝
                                                       ███╔╝ ██║   ██║██║  ██║██║███████║██║     
                                                      ███╔╝  ██║   ██║██║  ██║██║██╔══██║██║     
                                                     ███████╗╚██████╔╝██████╔╝██║██║  ██║╚██████╗
                                                     ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝ ╚═════╝ 
                                                                
                                                                            
                                              Добро пожаловать в игру ZODIAC, чем бы ты хотел заняться?

                                   (Используйте игровые клавишы для перемещения по опциям меню и ентер для выбора)"; //подсказка для действия
            string[] options = { "                                                                    PLAY",
                                 "                                                                    ABOUT",
                                 "                                                                    EXIT" }; // массив множеств опций
            Menu mainMenu = new Menu(tip, options);
            int selectedIndex = mainMenu.Run(); //обработка всех движений со стрелками до тех пор пока не нажата ентер

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        public static void ExitGame()
        {
            Console.Clear();
            Console.SetCursorPosition(60, 30);
            WriteLine("\nНажмите любую клавишу для выхода");
            ReadKey(true); //нажатие любой клавиши
            Environment.Exit(0);
        }

        public static void DisplayAboutInfo()
        {
            Console.Clear();
            Console.SetCursorPosition(47, 25);
            WriteLine("Здесь следует прописать информацию о создателях игры и т.п.\n");

            Console.SetCursorPosition(47, 28);
            WriteLine("Нажмите любую клавишу чтобы вернуться в меню");
            ReadKey(true);
            RunMenu();
        }

        public static void RunFirstChoice()
        {
            Console.Clear();
            SetCursorPosition(68, 20);
            WriteLine("Введи своё имя");
            SetCursorPosition(70, 23);
            string nameHero = Console.ReadLine();
            Console.Clear();

            string tip = "           Выбери свой знак зодиака\n";
            string[] options = { 
                "                                                                     Овен", 
                "                                                                     Телец", 
                "                                                                     Близнецы", 
                "                                                                     Рак", 
                "                                                                     Лев", 
                "                                                                     Дева", 
                "                                                                     Весы", 
                "                                                                     Скорпион", 
                "                                                                     Стрелец", 
                "                                                                     Козерог", 
                "                                                                     Водолей", 
                "                                                                     Рыбы" };

            Menu ZodiacMenu = new Menu(tip, options);
            int selectedIndex = ZodiacMenu.Run();

            Console.Clear();
            Console.SetCursorPosition(55, 30);

            switch (selectedIndex)
            {
                case 0:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    break;
                case 1:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    break;
                case 2:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    break;
                case 3:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    break;
                case 4:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    break;
                case 5:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    break;
                case 6:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    break;
                case 7:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    break;
                case 8:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    break;
                case 9:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    break;
                case 10:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    break;
                case 11:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    break;
            }

            System.Threading.Thread.Sleep(600);
            Console.Clear();
            Console.SetCursorPosition(55, 30);
            WriteLine("Сейчас начнется игра, удачи тебе!");
            //Give the Console a chance to Render
            System.Threading.Thread.Sleep(1000);
            Zodiak.Game();
        }
    }
}
