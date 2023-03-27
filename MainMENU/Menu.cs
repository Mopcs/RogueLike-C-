using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game {
    class Menu {
        private int SelectIndex; //выбранный индекс
        private string[] Options;//опции
        private string Tip; //подсказка

        public Menu(string tip, string[] options) {
            Tip = tip;
            Options = options;
            SelectIndex = 0; //перемещение по меню
        }
        private void DisplayOptions() {
            WriteLine(Tip);
            for (int i = 0; i < Options.Length; i++) {
                string currentOption = Options[i]; //выбранная опция
                string prefix;

                if (i == SelectIndex) {
                    prefix = ">";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                } else {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} | {currentOption}");
            }
            ResetColor(); //сброс цвета
        }
        public int Run() {
            ConsoleKey keyPressed;
            do {
                Clear(); //очистка
                DisplayOptions();//отображение параметров
                //перерисовывает меню каждый раз


                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow) {
                    SelectIndex--;
                    if (SelectIndex == -1) {

                        SelectIndex = Options.Length - 1; //при пролистывании первого эл вверх проимходит закольцовывание на нижнюю опцию

                    }

                }
                else if (keyPressed == ConsoleKey.DownArrow) {
                    SelectIndex++;
                    if (SelectIndex == Options.Length) {
                        SelectIndex = 0;
                    }
                }
                //обновим выбранный индекс(SelectIndex) с помощью стрелок
            } while (keyPressed != ConsoleKey.Enter); // при нажатии на ентер происходит выбор и возвращается значение для селектиндекс

            return SelectIndex; //возвращаю значение для навигации меню
        }
    }
}
