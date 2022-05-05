using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
// Version 1.0 
// Created by: Brennan Sprague, 3/29/2021
// Updated: 7/21/2021
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameLoop gL = new GameLoop();

            // Set board, ships, and draw them to the screen
            gL.SetUp();     

        Console.Read();
        }
    }
}
