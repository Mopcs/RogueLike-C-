using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game {
    class Game {
        public void Start() {
            
            Title = "Zodiaci";
            RunMenu();
           
            // WriteLine("нажмите любую клавишу для выхода");
            // ReadKey(true);
        }
        private void RunMenu() { //метод запуска главного меню
//ANCI Shadow
             string tip = @"
███████╗ ██████╗ ██████╗ ██╗ █████╗  ██████╗
╚══███╔╝██╔═══██╗██╔══██╗██║██╔══██╗██╔════╝
  ███╔╝ ██║   ██║██║  ██║██║███████║██║     
 ███╔╝  ██║   ██║██║  ██║██║██╔══██║██║     
███████╗╚██████╔╝██████╔╝██║██║  ██║╚██████╗
╚══════╝ ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝ ╚═════╝                                                                  
                                                                            
Добро пожаловать в игру ZODIAC, чем бы ты хотел заняться?

(Используйте клавишы стрелки для перемещения по опциям меню и ентер для выбора)"; //подсказка для действия
            string[] options = {"Play", "About", "Exit"}; // массив множеств опций
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
        private void ExitGame() {
            WriteLine("\nНажмите любую клавишу для выхода");
            ReadKey(true); //нажатие любой клавиши
            Environment.Exit(0);
        }
        
        private void DisplayAboutInfo() {
            WriteLine("\nЗдесь следует прописать информацию о создателях игры и т.п.\n");
            WriteLine("Нажмите любую клавишу чтобы вернуться в меню");
            ReadKey(true);
            RunMenu();
        }

        private void RunFirstChoice() {
            WriteLine("\nВведи своё имя");
            string nameHero = Console.ReadLine();
            string tip = "Выбери свой знак зодиака\n";
            string[] options = {"Овен", "Телец", "Близнецы", "Рак" , "Лев", "Дева", "Весы", "Скорпион", "Стрелец", "Козерог", "Водолей", "Рыбы"};
            Menu ZodiacMenu = new Menu(tip, options);
            int selectedIndex = ZodiacMenu.Run();
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
            ExitGame();
        }
    }
}
