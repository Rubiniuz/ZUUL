using System;
using System.Collections.Generic;
using Zuul;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player;

        public Game ()
		{
            player = new Player();
            Weapon rock = new Weapon("rock", "A blunt rock with sharp edges used to smash heads and gather resources", 25, 15.0f, 10);
            Item torch = new Item("torch", "A torch that can be lit", 10, 7.5f);
            player.GetInventory().AddItem(rock);
            player.GetInventory().AddItem(torch);
            parser = new Parser();
            createRooms();
		}

		private void createRooms()
		{
            // create the rooms
            Room b3 = new Room("B3. at a local junkyard.", 0);
            Key b3key = new Key("greenkey","A greenkeycard to open low tier doors",2,5.0f,1);
            b3.GetInventory().AddItem(b3key);
            Room c2 = new Room("C2. at Sewer branch.", 1);
            Key c2key = new Key("bluekey", "A blue keycard to open mid tier doors", 2, 5.0f,2);
            c2.GetInventory().AddItem(c2key);
            c2.LockRoom();
            Room underc2 = new Room("C2 Basement. under Sewer branch.", 2);
            underc2.LockRoom();
            Room c3 = new Room("C3. at Launchsite.",3);
            c3.LockRoom();
            Room c4 = new Room("C4. at the trainyard.", 2);
            Key c4key = new Key("redkey", "A red keycard to open high tier doors", 2, 5.0f, 3);
            c4.GetInventory().AddItem(c4key);
            c4.LockRoom();
            Room d3 = new Room("D3. at the military tunnels.", 3);
            Key d3key = new Key("masterkey", "A master keycard to open all doors", 999, 15.0f, 5);
            d3.GetInventory().AddItem(d3key);
            d3.LockRoom();
            Room b2 = new Room("B2. at a local spermket.", 0);
            Key b2key = new Key("greenkey", "A greenkeycard to open low tier doors", 2, 5.0f, 1);
            b2.GetInventory().AddItem(b2key);
            Room b4 = new Room("B4. at a local gas station.", 0);
            Key b4key = new Key("greenkey", "A greenkeycard to open low tier doors", 2, 5.0f, 1);
            b4.GetInventory().AddItem(b4key);
            Room d4 = new Room("D4. at a local spermket.", 0);
            Key d4key = new Key("greenkey", "A greenkeycard to open low tier doors", 2, 5.0f, 1);
            d4.GetInventory().AddItem(d4key);
            Room d2 = new Room("D2. at a local gas station.", 0);
            Key d2key = new Key("greenkey", "A greenkeycard to open low tier doors", 2, 5.0f, 1);
            d2.GetInventory().AddItem(d2key);
            

           Room a1 = new Room("A1. the beach. the spawn place for all nakeds.", 0);
            Room a2 = new Room("A2. the beach. the spawn place for all nakeds.", 0);
            Room a3 = new Room("A3. the beach. the spawn place for all nakeds.", 0);
            Room a4 = new Room("A4. the beach. the spawn place for all nakeds.", 0);
            Room a5 = new Room("A5. the beach. the spawn place for all nakeds.", 0);
            Room b1 = new Room("B1. the beach. the spawn place for all nakeds.", 0);
            Room b5 = new Room("B5. the beach. the spawn place for all nakeds.", 0);
            Room c1 = new Room("C1. the beach. the spawn place for all nakeds.", 0);
            Room c5 = new Room("C5. the beach. the spawn place for all nakeds.", 0);
            Room d1 = new Room("D1. the beach. the spawn place for all nakeds.", 0);
            Room d5 = new Room("D5. the beach. the spawn place for all nakeds.", 0);
            Room e1 = new Room("E1. the beach. the spawn place for all nakeds.", 0);
            Room e2 = new Room("E2. the beach. the spawn place for all nakeds.", 0);
            Room e3 = new Room("E3. the beach. the spawn place for all nakeds.", 0);
            Room e4 = new Room("E4. the beach. the spawn place for all nakeds.", 0);
            Room e5 = new Room("E5. the beach. the spawn place for all nakeds.", 0);

            //layer 1
            a1.setExit("east", b1);
            a1.setExit("south", a2);

            b1.setExit("south", b2);
            b1.setExit("east", c1);
            b1.setExit("west", a1);

            c1.setExit("south", c2);
            c1.setExit("east", d1);
            c1.setExit("west", e1);

            d1.setExit("south", d2);
            d1.setExit("east", e1);
            d1.setExit("west", c1);

            e1.setExit("west", b1);
            e1.setExit("south", e2);

            //layer 2
            a2.setExit("east", b2);
            a2.setExit("south", a3);
            a2.setExit("north", a1);

            b2.setExit("south", b3);
            b2.setExit("north", b1);
            b2.setExit("east", c2);
            b2.setExit("west", a2);

            c2.setExit("south", c3);
            c2.setExit("north", c1);
            c2.setExit("east", d2);
            c2.setExit("west", b2);
            c2.setExit("down", underc2);

            underc2.setExit("up", c2);

            d2.setExit("north", d1);
            d2.setExit("south", d3);
            d2.setExit("east", e2);
            d2.setExit("west", c2);

            e2.setExit("west", d2);
            e2.setExit("south", e3);
            e2.setExit("north", e1);

            //layer 3
            a3.setExit("east", b3);
            a3.setExit("south", a4);
            a3.setExit("north", a2);

            b3.setExit("south", b4);
            b3.setExit("north", b2);
            b3.setExit("east", c3);
            b3.setExit("west", a3);

            c3.setExit("south", c4);
            c3.setExit("north", c2);
            c3.setExit("east", d3);
            c3.setExit("west", b3);

            d3.setExit("north", d2);
            d3.setExit("south", d4);
            d3.setExit("east", e3);
            d3.setExit("west", c3);

            e3.setExit("west", d3);
            e3.setExit("south", e4);
            e3.setExit("north", e2);

            //layer 4
            a4.setExit("east", b4);
            a4.setExit("south", a5);
            a4.setExit("north", a4);

            b4.setExit("south", b5);
            b4.setExit("north", b5);
            b4.setExit("east", c4);
            b4.setExit("west", a4);

            c4.setExit("south", c5);
            c4.setExit("north", c3);
            c4.setExit("east", d4);
            c4.setExit("west", b4);

            d4.setExit("north", d3);
            d4.setExit("south", d5);
            d4.setExit("east", e4);
            d4.setExit("west", c4);

            e4.setExit("west", d4);
            e4.setExit("south", e5);
            e4.setExit("north", e3);

            //layer 5
            a5.setExit("east", b5);
            a5.setExit("north", a4);

            b5.setExit("north", b4);
            b5.setExit("east", c5);
            b5.setExit("west", a5);

            c5.setExit("north", c4);
            c5.setExit("east", d5);
            c5.setExit("west", e5);

            d5.setExit("north", d4);
            d5.setExit("east", e5);
            d5.setExit("west", c5);

            e5.setExit("west", b5);
            e5.setExit("north", e4);
            
            player.SetCurrentRoom(a1);  // start game at beach
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
                Command command = parser.getCommand();
                finished = processCommand(command);
            }
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
            
            Console.WriteLine();
            // ascii text
            int rC = 183;
            int gC = 65;
            int bC = 14;
            
            Console.WriteAscii("Rusty Text!", Color.FromArgb(rC, gC, bC));
            // normal text
            Console.WriteLine();
            string start = "Welcome to: {0} This is a text version of {1}.";
            string info = "Type {2} if you need help.";
            Formatter[] welcome = new Formatter[]
            {
                new Formatter("Rusty Text!", Color.Red),
                new Formatter("Rust", Color.Red),
                new Formatter("help", Color.ForestGreen),
            };
            Console.WriteLineFormatted(start, Color.White, welcome);
            Console.WriteLineFormatted(info, Color.White, welcome);
            Console.WriteLine();
			Console.WriteLine(player.GetCurrentRoom().getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
                    player.IsAlive();
                    goRoom(command);
                    break;
                case "look":
                    Console.WriteLine(player.GetCurrentRoom().getLongDescription());
                    //Console.WriteLine(player.GetCurrentRoom().GetResourceNode()); not correctly implemented yet               W.I.P
                    Console.WriteLine(player.GetCurrentRoom().GetInventory().GetItems());
                    break;
                case "status":
                    Console.WriteLine(player.Status());
                    Console.WriteLine(player.GetInventory().GetItems());
                    break;
                case "take":
                    if (player.GetInventory().GetWeight() <= player.GetInventory().GetCarryLimit())
                    {
                        Take(command);
                    }
                    break;
                case "drop":
                    Drop(command);
                    break;
                case "use":
                    Use(command);
                    break;
                case "mine":
                    Console.WriteLine("W.I.P");
                    break;
                case "map":
                    ShowMap();
                    break;
                case "unlock":
                    Unlock(command);
                    break;
                case "quit":
					wantToQuit = true;
					break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around on the Island.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.GetCurrentRoom().getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to "+direction+"!");
			} else {
                if (player.IsAlive())
                {
                    if (!nextRoom.isLocked())
                    {
                        player.SetCurrentRoom(nextRoom);
                        player.Damage(5);
                        Console.WriteLine(player.GetCurrentRoom().getLongDescription());
                    }
                    else
                    {
                        Console.WriteLine("the door " + direction + " is locked");
                    }
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
			}
		}

        private void Take(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Take what?");
                return;
            }

            string item = command.getSecondWord();

            // Try to leave current room.
            Item toTake = player.GetCurrentRoom().GetInventory().RemoveItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.GetInventory().AddItem(toTake);
                    if (toTake != null)
                    {
                        Console.WriteLine("player added: " + toTake.GetLongDescription());
                    }
                    else
                    {
                        Console.WriteLine("There is no item with this name!");
                    }
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
        }

        private void Drop(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Drop what?");
                return;
            }

            string item = command.getSecondWord();

            // Try to leave current room.
            Item toDrop = player.GetInventory().RemoveItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.GetCurrentRoom().GetInventory().AddItem(toDrop);
                    Console.WriteLine("player dropped: " + toDrop.GetLongDescription());
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
        }
        private void Use(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Use what?");
                return;
            }

            string item = command.getSecondWord();

            // Try to leave current room.
            Item toUse = player.GetInventory().GetItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.GetInventory().UseItem(toUse , player);
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
        }

        private void Unlock(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Which room do you want to unlock?");
                Console.WriteLine("Use the command like this 'Unlock' 'exit' 'the item that is a key'.");
                return;
            }
            if (!command.hasThirdWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Which key do you want to use?");
                return;
            }

            string door = command.getSecondWord();
            string key = command.getThirdWord();
            Room toOpen;
            Key toUse;
            // Try to leave current room.
            if (door == null)
            {
                Console.WriteLine("There is no door with this name: " + door + "!");
            }
            toOpen = player.GetCurrentRoom().getExit(door);
            if (player.GetInventory().GetItem(key) is Key)
            {
                toUse = (Key)player.GetInventory().GetItem(key);
                if (player.IsAlive())
                {
                    if (player.GetCurrentRoom().GetTier() <= toUse.GetTier())
                    {
                        player.GetInventory().UseKey(player, toUse, toOpen);
                    }
                    else
                    {
                        Console.WriteLine("That Key is not strong enough for this door");
                    }
                    
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
            else
            {
                if (player.IsAlive())
                {
                    Console.WriteLine("That's not a key");
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
        }
        public string ShowMap2()
        {
            string mapString = "";
            mapString += "O============================================O";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "| | A1 | = | B1 | = | C1 | = | D1 | = | E1 | |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "|   ||       ||       ||       ||       ||   |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "| | A2 | = | B2 | = | C2 | = | D2 | = | E2 | |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "|   ||       ||       ||       ||       ||   |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "| | A3 | = | B3 | = | C3 | = | D3 | = | E3 | |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "|   ||       ||       ||       ||       ||   |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "| | A4 | = | B4 | = | C4 | = | D4 | = | E4 | |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "|   ||       ||       ||       ||       ||   |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "| | A5 | = | B5 | = | C5 | = | D5 | = | E5 | |";
            mapString += "\n";
            mapString += "| X====X   X====X   X====X   X====X   X====X |";
            mapString += "\n";
            mapString += "O============================================O";
            mapString += "\n";
            mapString += "Your current location is: " + player.GetCurrentRoom().getShortDescription();
            return mapString;
        }

        public void ShowMap()
        {
            Console.ForegroundColor = Color.White;
            string topbottom = "O==================================O";
            string breakLine = "|                                  |";
            string line = "| |{0}| = |{1}| = |{2}| = |{3}| = |{4}| |";
            string between = "|  ||     ||     ||     ||     ||  |";
            Formatter[] line1 = new Formatter[]
            {
                new Formatter("A1", Color.Black),
                new Formatter("B1", Color.Black),
                new Formatter("C1", Color.Black),
                new Formatter("D1", Color.Black),
                new Formatter("E1", Color.Black)
            };
            Formatter[] line2 = new Formatter[]
            {
                new Formatter("A2", Color.Black),
                new Formatter("B2", Color.ForestGreen),
                new Formatter("C2", Color.ForestGreen),
                new Formatter("D2", Color.ForestGreen),
                new Formatter("E2", Color.Black)
            };
            Formatter[] line3 = new Formatter[]
            {
                new Formatter("A3", Color.Black),
                new Formatter("B3", Color.Red),
                new Formatter("C3", Color.Red),
                new Formatter("D3", Color.Red),
                new Formatter("E3", Color.Black)
            };
            Formatter[] line4 = new Formatter[]
            {
                new Formatter("A4", Color.Black),
                new Formatter("B4", Color.ForestGreen),
                new Formatter("C4", Color.Red),
                new Formatter("D4", Color.ForestGreen),
                new Formatter("E4", Color.Black)
            };
            Formatter[] line5 = new Formatter[]
            {
                new Formatter("A5", Color.Black),
                new Formatter("B5", Color.Black),
                new Formatter("C5", Color.Black),
                new Formatter("D5", Color.Black),
                new Formatter("E5", Color.Black)
            };
            Console.BackgroundColor = Color.LightBlue;
            Console.WriteLine(topbottom, Color.Black);
            Console.WriteLine(breakLine, Color.Black);
            Console.WriteLineFormatted(line, Color.Black, line1);
            Console.WriteLine(between, Color.Black);
            Console.WriteLineFormatted(line, Color.Black, line2);
            Console.WriteLine(between, Color.Black);
            Console.WriteLineFormatted(line, Color.Black, line3);
            Console.WriteLine(between, Color.Black);
            Console.WriteLineFormatted(line, Color.Black, line4);
            Console.WriteLine(between, Color.Black);
            Console.WriteLineFormatted(line, Color.Black, line5);
            Console.WriteLine(breakLine, Color.Black);
            Console.WriteLine(topbottom, Color.Black);
            Console.ResetColor();
        }

    }
}
