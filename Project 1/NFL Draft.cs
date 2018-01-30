﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] players = { { "Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield" },
                                  {"Saquon Barkley","Derrius Guice", "Bryce Love", "Ronald Jones II", "Damien Harris"},
                                  {"Courtland Sutton","James Washington","Marcell Ateman","Anthony Miller","Calvin Ridley" },
                                  {"Maurice Hurst","Vita Vea","Taven Bryan","Da'Ron Payne","Harrison Phillips"},
                                  {"Joshua Jackson","Derwin James","Denzel Ward","Minkah Fitzpatrick","Isaish Oliver" },
                                  {"Mark Andrews","Dallas Goedert","Jaylen Samuels","Mike Gesicki","Troy Fumagalli" },
                                  {"Roquan Smith","Termaine Edmunds","Kendall Joseph","Dorian O'Daniel","Malik Jefferson" },
                                  {"Orlando Brown","Kolton Miller","Chukwuma Okorafor","Connor Williams","Mike McGlinchey" } };

            string[,] college = { { "(Oklahoma State)", "(Louisville)", "(UCLA)", "(Southern California)", "(Oklahoma)" },
                                  {"(Penn State)","(LSU)","(Stanford)","(Southern California)","(Alabama)" },
                                  {"(Southern Methodist)","(Oklahoma State)","(Oklahoma State)","(Memphis)","(Alabama)" },
                                  {"(Michigan)","(Washington)","(Florida)","(Alabama)","(Stanford)" },
                                  {"(Iowa)","(Florida State)","(Ohio State)","(Alabama)","(Colorado)" },
                                  {"(Oklahoma)","(So. Dakota State)","(NC State)","(Penn State)","(Wisconsin)" },
                                  {"(Georgia)","(Virgina Tech)","(Clemson)","(Clemson)","(Texas)" },
                                  {"(Oklahoma)","(UCLA)","(Western Michigan)","(Texas)","(Notre Dame)" } };

            int[,] salary = { {26400100, 20300100, 17420300,13100145,10300000 },
                              {24500100,19890200,18700800,15000000,11600400 },
                              {23400000,21900300,19300230,13400230,10000000 },
                              {26200300,22000000,16000000,18000000,13000000 },
                              {24000000,22500249,20000100,16000200,11899999 },
                              {27800900,21000800,17499233,27900200,14900333 },
                              {22900300,19000590,18000222,12999999,10000100 },
                              {23000000,20000000,19400000,16200700,15900000 } };

            int money = 95000000;

            draftPlayer(players, salary, money);



        }

        public static void draftPlayer(string[,] players, int[,] salary, int money)
        {
            for (var y = 0; y < 5; ++y)
            {
                int position = selectPosition();
                int choiceColumn = selectName(players, salary, position);
                money = money - salary[position, choiceColumn - 1];
                Console.WriteLine("\nYou have ${0} left to spend.", money);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();

            }
        }

        public static int selectPosition()
        {
            Console.WriteLine("Enter the number for the position you would like to choose.\n");
            Console.WriteLine("1 for Quarterback.");
            Console.WriteLine("2 for Running Back");
            Console.WriteLine("3 for Wide-Receiver");
            Console.WriteLine("4 for Defensive Lineman");
            Console.WriteLine("5 for Defensive-Back");
            Console.WriteLine("6 for Tight End");
            Console.WriteLine("7 for Line-Backer");
            Console.WriteLine("8 for Offensive Tackle");
            string position = Console.ReadLine();
            int row = Int32.Parse(position);
            row = row - 1;
            Console.WriteLine("\nEnter the number for the player you would like to draft.\n");

            return row;
        }

        public static int selectName(string[,] players, int[,] salary, int row)
        {
            for (int x = 0; x < 5; x++)
            {
                
                int column = x;
                string name = players[row, column];
                Console.WriteLine("{0}. {1}",x+1,name);
            }
            string choice = Console.ReadLine();
            int choiceColumn = Int32.Parse(choice);
            Console.WriteLine("\nYou drafted {0}.", players[row, choiceColumn - 1]);
            Console.WriteLine("Their salary initial is ${0}.", salary[row, choiceColumn - 1]);



            return choiceColumn;
        }
    }
}