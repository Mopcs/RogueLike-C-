using ConsoleApp8.Core;
using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Interfaces
{
    internal interface IInterfaceDrawer
    {
        int X { get; set; }
        int Y { get; set; }
        string Symbol { get; set; }

        RLColor color { get; set; }

        void Draw(Character person);


    }
}
