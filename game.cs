using System;
using System.Collections.Generic;

class AdventureGame
{
    static void Main(string[] args)
    {
        // Game Introduction
        Console.WriteLine("Welcome to the Enchanted Adventure!");
        Console.WriteLine("What's your name, brave explorer?");
        string playerName = Console.ReadLine();
        Console.WriteLine($"Embark on your quest, {playerName}!");

        // Game World Setup
        var locations = new Dictionary<string, string>
        {
            {"Village", "You are in a peaceful village. Paths lead in all directions."},
            {"Forest", "You are in a mysterious forest. Paths lead north and east."},
            {"Lake", "A serene lake lies here, with a path leading west."},
            {"Mountains", "Majestic mountains surround you. Paths lead south and into a cave."},
            {"Cave", "Inside a dim cave. An old sage resides here."}
        };

        var playerLocation = "Village";
        var inventory = new List<string>();
        var hasSpokenToSage = false;

        // Main Game Loop
        bool playing = true;
        while (playing)
        {
            Console.WriteLine(locations[playerLocation]);

            // Player Input
            Console.Write("What will you do? ");
            string command = Console.ReadLine().ToLower();

            // Game Logic
            switch (command)
            {
                case "north":
                    if (playerLocation == "Village") playerLocation = "Forest";
                    else if (playerLocation == "Forest") playerLocation = "Mountains";
                    else Console.WriteLine("You can't go that way.");
                    break;
                case "south":
                    if (playerLocation == "Mountains") playerLocation = "Forest";
                    else if (playerLocation == "Forest") playerLocation = "Village";
                    else Console.WriteLine("You can't go that way.");
                    break;
                case "east":
                    if (playerLocation == "Forest") playerLocation = "Lake";
                    else Console.WriteLine("You can't go that way.");
                    break;
                case "west":
                    if (playerLocation == "Lake") playerLocation = "Forest";
                    else Console.WriteLine("You can't go that way.");
                    break;
                case "enter cave":
                    if (playerLocation == "Mountains") playerLocation = "Cave";
                    else Console.WriteLine("There is no cave here.");
                    break;
                case "talk":
                    if (playerLocation == "Cave")
                    {
                        if (!hasSpokenToSage)
                        {
                            Console.WriteLine("The sage tells you about a hidden treasure in the forest.");
                            hasSpokenToSage = true;
                        }
                        else Console.WriteLine("The sage has nothing more to say.");
                    }
                    else Console.WriteLine("There's no one to talk to.");
                    break;
                case "look":
                    if (playerLocation == "Forest" && hasSpokenToSage && !inventory.Contains("treasure"))
                    {
                        Console.WriteLine("You found a hidden treasure!");
                        inventory.Add("treasure");
                    }
                    else Console.WriteLine("There's nothing special here.");
                    break;
                case "inventory":
                    Console.WriteLine("You are carrying:");
                    foreach (var item in inventory) Console.WriteLine(item);
                    break;
                case "quit":
                    playing = false;
                    break;
                default:
                    Console.WriteLine("I don't understand that command.");
                    break;
            }
        }

        Console.WriteLine("Thank you for playing the Enchanted Adventure!");
    }
}
