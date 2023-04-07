//WriteLine($"{NameHero} у тебя стихия Огня\nИ вот столько хп {Fire.HP}");

//         class Fire {
//             public static int HP { get; set;}
//         }

//     }
// }



using System;

namespace Game {
    class Program {
        static void Main(string[] args) {
            //Sound();

            Game myGame = new Game();
            
            myGame.Start();

            
        }
    }
}

