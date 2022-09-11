using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
namespace GameRockScissorsPaper
{
    class Game
    {
        static Dictionary<string, string> choices = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            choices.Add("p", "paper");
            choices.Add("r", "rock");
            choices.Add("s", "scissor");

            PrintGameIntro();
            RunGame();
        }
        static void PrintGameIntro()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("~~~~Rock|Scissors|Paper Game~~~");
            Console.WriteLine("Hi, Welcome to the Rock, Scissors, Paper Game");
            Console.WriteLine("Chices is: ");
            foreach(KeyValuePair<string, string> choice in choices)
            {
                Console.WriteLine($"\t {choice.Key} => {choice.Value}");
            }
            Console.WriteLine("Please Start Gaming.");
            Console.WriteLine(new string('-', 50));
        }
        static void RunGame()
        {
            bool again = true;
            do
            {
                var userInput = UserInput();
                Console.WriteLine("Player: " + userInput);

                var systemInput = SystemInput();
                Console.WriteLine($"Computer: {systemInput}");

                ResultGame(userInput, systemInput);

                Console.WriteLine("Would you like play again (Y/N): ");
                var againgame = Console.ReadLine();
                Console.Clear();
                again = againgame.ToUpper() == "Y";
                
            }while(again);    
            Console.WriteLine("Thanks for palying ^_^ !");
        }
        static string UserInput()
        {
            Console.Write("Enter your select with paper, rock & scissor (p, r, s): ");
            var userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            return userInput;
        }
        static string SystemInput()
        {
            Random random = new Random();
            int systemInput = random.Next(choices.Count);
            string keySystem = choices.Keys.ElementAt(systemInput);
            return keySystem;
        }
        static void ResultGame(string userInput, string systemInput)
        {
            if(choices.ContainsKey(userInput))
            {
                Console.WriteLine($"User choice is {choices[userInput]} and System choice is {choices[systemInput]}");
                if(userInput == systemInput)
                {
                    Console.WriteLine("it's a draw");
                }
                else
                {
                    if(userInput == "s" && systemInput == "p")
                    {
                        Console.WriteLine("You win"); 
                    }
                    else if(userInput == "r" && systemInput == "s")
                    {
                        Console.WriteLine("You win");  
                    }
                    else if(userInput == "p" && systemInput == "r")
                    {   
                        Console.WriteLine("You win"); 
                    }
                    else
                    {
                        Console.WriteLine("You lose!");
                    }
                }
            }    
            else
            {
                Console.WriteLine("Invalid input, You should select between s, r or p");     
            }  
        }
    }    
}