using System;
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

            string[] positions = {"Quaterback","Running Back","Wide-Receiver","Defensive Lineman",
                                    "Defensive-Back","Tight End","Line-Backer","Offensive Tackle"};

            int money = 95000000;
            string[] chosenPlayers = { };

            draftPlayer(players, college, salary, positions, money);



        }

        public static void draftPlayer(string[,] players, string[,] college, int[,] salary, string[] positions, int money)
        {
            string[] chosenPlayers = { };
            string[] playerPos = { };
            int[] playerSalary = { };
            string[] playerCollege = { };
            int columnTop = 0;

            bool sentinel = true;
            while (sentinel == true) //sentinel value
            {
                int row = choosePosition(); //Select the player position
                int choiceColumn = selectName(players, college, salary, positions, row, money); // Select the player
                columnTop = StoreChoiceColumn(choiceColumn, columnTop); //Stores and returns corresponding column from players array


                if (money < salary[row, choiceColumn])
                { }
                else //if enough salary is left, add player name to list
                {
                    chosenPlayers = manageSelection(chosenPlayers, players, row, choiceColumn);
                    playerPos = managePosition(row, positions, playerPos);
                    playerCollege = ManageCollege(row, choiceColumn, college, playerCollege);
                    playerSalary = manageSalary(row, choiceColumn, salary, playerSalary);
                    money = money - salary[row, choiceColumn];
                }
             

                Console.WriteLine("Number of players drafted:{0}\n", chosenPlayers.Length);
                for (int x = 0; x < chosenPlayers.Length; x++)
                {
                    Console.WriteLine("{0}. {1}, ({2}), {3}, ${4}", x + 1, chosenPlayers[x], playerPos[x], playerCollege[x], playerSalary[x]);
                }

                Console.WriteLine("\nYou have ${0} remaining.", money);
                if (chosenPlayers.Length == 5) //ends loop if user has selected 5 players
                {
                    sentinel = false;
                    Console.WriteLine("You have drafted five players.");
                    Console.Clear();
                    ClosingMessage(chosenPlayers, playerPos, playerSalary, playerCollege, money);
                }
                else
                {
                    Console.WriteLine("Press enter to draft another player or enter any other key to quit.");
                    string cont = Console.ReadLine();
                    if (cont != "")
                    {
                        sentinel = false;
                        Console.Clear();
                        CostEffectiveMessage(chosenPlayers, money, columnTop);
                        ClosingMessage(chosenPlayers, playerPos, playerSalary, playerCollege, money);
                    }
                }

                Console.Clear();
                
            }
        }

        public static int choosePosition()
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
            string a;
            a = Console.ReadLine();
            while (a != "1" && a != "2" && a != "3" && a != "4" && a != "5" && a != "6" && a != "7" && a != "8")
            {
                Console.WriteLine("Invalid option. Please enter a number 1-8");
                a = Console.ReadLine();
            }
            int row = Int32.Parse(a);
            row = row - 1;
            Console.WriteLine("\nEnter the number for the player you would like to draft.\n");

            return row;
        }

        public static int selectName(string[,] players, string[,] college, int[,] salary, string[] positions, int row, int money)
        {
            for (int x = 0; x < 5; x++)
            {

                int column = x;
                string name = players[row, column];
                Console.WriteLine("{0}. {1}, {2}", x + 1, name, college[row, column]);
            }
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Invalid option. Please enter a number 1-5.");
                choice = Console.ReadLine();
            }
            int choiceColumn = Int32.Parse(choice);
            choiceColumn = choiceColumn - 1;
            if (money < salary[row, choiceColumn])
            {
                Console.WriteLine("You don't have enough balance to draft this player.\n");
            }
            else
            {
                Console.WriteLine("\nYou drafted {2}, {0} {1}.", players[row, choiceColumn], college[row, choiceColumn], positions[row]);
                Console.WriteLine("Their initial salary is ${0}.\n", salary[row, choiceColumn]);
            }

            return choiceColumn;
        }

        public static string[] manageSelection(string[] chosenPlayers, string[,] players, int row, int choiceColumn)
        {

            string[] z = { players[row, choiceColumn] };
            chosenPlayers = chosenPlayers.Concat(z).ToArray();
            return chosenPlayers;
        }

        public static string[] managePosition(int row, string[] positions, string[] playerPos)
        {
            string[] b = { positions[row] };
            playerPos = playerPos.Concat(b).ToArray();
            return playerPos;
        }

        public static int[] manageSalary(int row, int choiceColumn, int[,] salary, int[] playerSalary)
        {
            int[] c = { salary[row, choiceColumn] };
            playerSalary = playerSalary.Concat(c).ToArray();
            return playerSalary;
        }

        public static string[] ManageCollege(int row, int choiceColumn, string[,] college, string[] playerCollege)
        {
            string[] d = { college[row, choiceColumn] };
            playerCollege = playerCollege.Concat(d).ToArray();
            return playerCollege;
        }

        static void ClosingMessage(string[] chosenPlayers, string[] playerPos, int[] playerSalary, string[] playerCollege, int money)
        {
            Console.WriteLine("Thank you for using this program.\n Listed below are your final draft picks.\n");
            for(int x = 0; x < chosenPlayers.Length; x++)
            {
                Console.WriteLine("{0}. {1}, ({2}), {3}, ${4}", x + 1, chosenPlayers[x], playerPos[x], playerCollege[x], playerSalary[x]);
            }
            int totalSalaries = 95000000 - money;
            Console.WriteLine("\nYou have spent a total of ${0} on player salaries.\n${1} remains for signing bonuses.\n",totalSalaries, money);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        static void CostEffectiveMessage(string[] chosenPlayers, int money, int columnTop)
        {
            if (columnTop >= 3)
            {
                if (money >= 30000000)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cost effective pick!\nYou picked up to " +
                        "three top 3 players for under $65000000!\n");
                    Console.ResetColor();
                }
            }
        }

        static int StoreChoiceColumn(int choiceColumn, int columnTop)
        {
            if (choiceColumn <= 2)
            {
                columnTop = columnTop + 1;
            }
            return columnTop;
        }


    }
}