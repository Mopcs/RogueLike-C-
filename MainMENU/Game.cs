using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Media;

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
            WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            ReadKey(true);
            RunMenu();
        }

        private void RunFirstChoice() {
            WriteLine("\nВведи своё имя");
            string? nameHero = ReadLine();
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
        private void PlayMenu() { //метод для паузы
            string tip = "Пауза\n";
            string[] options = {"Вернуться в главное меню", "Вернуться в Игру", "О нас", "Выход из Игры"};
            Menu PlayMenu = new Menu(tip, options);
            int selectedIndex = PlayMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMenu();
                    break;
                case 1:
                    return;
                case 2:
                    DisplayAboutInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }
        private void Dialogue() {
            string tip = "Давай поболтаем?";
            string[] options = {"Конечно", "Пшл куда подальше"};
            Menu Dialogue = new Menu(tip, options);
            int selectedIndex = Dialogue.Run();
            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
        private void ChoiceOfWeapons() {
            string tip = "Выбери оружие из списка";
            string[] options = {"hvnbvghgxfcnnxghfgfxcghgcvbvcghugfcxdzsaqwsedrftyujkbvcxzsawedrtyuioklnbvcxdsrftgh"};
            Menu ChoiceOfWeapons = new Menu(tip, options);
            int selectedIndex = ChoiceOfWeapons.Run();
            switch (selectedIndex)
            {
                case 0:
                    break;
            }
            // вставить методы оружий
        }
        private void Shop() {
            string tip = "МАГАЗИН, приветствуем вас";
            string[] options = {"Купить"};
            Menu Shop = new Menu(tip, options);
            int selectedIndex = Shop.Run();
            switch (selectedIndex)
            {
                case 0:
                    break;
            }
            //Реализовать магазин
        }

        // private void Sound() {

        //     if (OperatingSystem.IsWindows()) {
        //         SoundPlayer sPlayer = new SoundPlayer("Marilyn-Mae-Deang-Game-_Instrumental_.wav");
        //         sPlayer.Load();
        //         sPlayer.PlayLooping();            
        //     }
        //     else
        //     WriteLine("error");

        //     WriteLine("Нажмите на любую клавишу, чтобы выключить музыку");
        //     ReadKey(true);
        //     Environment.Exit(0);
        // }
    }
}
