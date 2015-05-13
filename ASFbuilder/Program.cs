using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.Menus;

namespace ASFbuilder
{
    class Program
    {
        static void Main()
        {
            MainMenu builder = new MainMenu();
            builder.StartBuilder();
        }
    }
}
