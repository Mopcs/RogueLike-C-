using Game_Zodiac.Monsters;
using System;
using static System.Console;

namespace Game_Zodiac.Core
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
            Console.SetCursorPosition(30, 20);
            WriteLine("\nНажмите любую клавишу для выхода");
            ReadKey(true); //нажатие любой клавиши
            RunMenu();


        }

        public static void DisplayAboutInfo()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 15);
            WriteLine("Здесь следует прописать информацию о создателях игры и т.п...\n");

            Console.SetCursorPosition(20, 18);
            WriteLine("Нажмите любую клавишу чтобы вернуться в меню");
            ReadKey(true);
            RunMenu();
        }

        public static void RunFirstChoice()
        {
            Console.Clear();
            SetCursorPosition(20, 15);
            WriteLine("Введи своё имя");
            SetCursorPosition(20, 15);
            string nameHero = Console.ReadLine();
            Console.Clear();

            string tip = "    Выбери свой знак зодиака\n";
            string[] options = { 
                "                                                         Овен", 
                "                                                         Телец", 
                "                                                         Близнецы", 
                "                                                         Рак", 
                "                                                         Лев", 
                "                                                         Дева", 
                "                                                         Весы", 
                "                                                         Скорпион", 
                "                                                         Стрелец", 
                "                                                         Козерог", 
                "                                                         Водолей", 
                "                                                         Рыбы" };

            Menu ZodiacMenu = new Menu(tip, options);
            int selectedIndex = ZodiacMenu.Run();

            Console.Clear();
            
           
            Console.SetCursorPosition(20, 15);

            string player_class = "";
            switch (selectedIndex)
            {
                case 0:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    player_class = "fire";
                    break;
                case 1:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    player_class = "earth";
                    break;
                case 2:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    player_class = "air";
                    break;
                case 3:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    player_class = "water";
                    break;
                case 4:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    player_class = "fire";
                    break;
                case 5:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    player_class = "earth";
                    break;
                case 6:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    player_class = "air";
                    break;
                case 7:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    player_class = "water";
                    break;
                case 8:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ОГОНЬ!");
                    player_class = "fire";
                    break;
                case 9:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ЗЕМЛЯ!");
                    player_class = "earth";
                    break;
                case 10:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОЗДУХ!");
                    player_class = "air";
                    break;
                case 11:
                    WriteLine($"Поздравляю {nameHero} ты в клане стихии ВОДА!");
                    player_class = "water";
                    break;
            }

            System.Threading.Thread.Sleep(600);
            Console.Clear();
            Console.SetCursorPosition(20, 15);
            WriteLine("Сейчас начнется игра, удачи тебе!");
            //Give the Console a chance to Render
            System.Threading.Thread.Sleep(1000);

            switch (player_class)
            {
                case "water":
                    WaterPlayer Wplayer = new WaterPlayer(nameHero);
                    AirMonsters AWmonster = new AirMonsters();
                    EarthMonsters EWmonster = new EarthMonsters();
                    FireMonsters FWmonster = new FireMonsters();

                    MethodsForMonsters.AddMonster_rand(AWmonster, EWmonster, FWmonster, MethodsForMonsters.MonsterArray(AWmonster, EWmonster, FWmonster));
                    Zodiak.Game(Wplayer, AWmonster, EWmonster, FWmonster);
                    //Monster.MonsterMovement(MethodsForMonsters.MonsterArray(AWmonster, EWmonster, FWmonster), Wplayer);

                    break;
                case "air":
                    AirPlayers Aplayer = new AirPlayers(nameHero);
                    WaterMonsters WAmonster = new WaterMonsters();
                    EarthMonsters EAmonster = new EarthMonsters();
                    FireMonsters FAmonster = new FireMonsters();

                    MethodsForMonsters.AddMonster_rand(WAmonster, EAmonster, FAmonster, MethodsForMonsters.MonsterArray(WAmonster, EAmonster, FAmonster));
                    //Monster.MonsterMovement(MethodsForMonsters.MonsterArray(WAmonster, EAmonster, FAmonster), Aplayer);
                    Zodiak.Game(Aplayer, EAmonster, FAmonster, WAmonster);

                    break;
                case "earth":
                    EarthPlayer Eplayer = new EarthPlayer(nameHero);
                    AirMonsters AEmonster = new AirMonsters();
                    WaterMonsters WEmonster = new WaterMonsters();
                    FireMonsters FEmonster = new FireMonsters();

                    MethodsForMonsters.AddMonster_rand(AEmonster, WEmonster, FEmonster, MethodsForMonsters.MonsterArray(AEmonster, WEmonster, FEmonster));
                    //Monster.MonsterMovement(MethodsForMonsters.MonsterArray(AEmonster, WEmonster, FEmonster), Eplayer);
                    Zodiak.Game(Eplayer, WEmonster, FEmonster, AEmonster);

                    break;
                case "fire":
                    FirePlayer Fplayer = new FirePlayer(nameHero);
                    AirMonsters AFmonster = new AirMonsters();
                    EarthMonsters EFmonster = new EarthMonsters();
                    WaterMonsters WFmonster = new WaterMonsters();

                    MethodsForMonsters.AddMonster_rand(AFmonster, EFmonster, WFmonster, MethodsForMonsters.MonsterArray(AFmonster, EFmonster, WFmonster));
                    //Monster.MonsterMovement(MethodsForMonsters.MonsterArray(AFmonster, EFmonster, WFmonster), Fplayer);
                    Zodiak.Game(Fplayer, EFmonster, WFmonster, AFmonster);

                    break;
            }


        }
    }
}
