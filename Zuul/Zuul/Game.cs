using System;
using Zuul;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player;

		public Game ()
		{
            player = new Player();
            parser = new Parser();
            createRooms();
		}

		private void createRooms()
		{
			Room beach, mainRoad, spermket, sewerBranch, gasStation, launchsite;

			// create the rooms
			beach = new Room("at the beach the spawn place for all nakeds");
			mainRoad = new Room("on the mainRoad looking for glory");
			spermket = new Room("in the local spermket");
			sewerBranch = new Room("in the sewerBranch.");
			gasStation = new Room("in the ruined gasStation");
            launchsite = new Room("in the high tier player area.");

            // initialise room exits and give items to rooms
            beach.setExit("east", mainRoad);
			beach.setExit("south", sewerBranch);
			beach.setExit("west", spermket);

            mainRoad.setExit("west", beach);
            mainRoad.setExit("north", launchsite);

            launchsite.setExit("south", mainRoad);
            launchsite.isLocked();

            spermket.setExit("east", beach);
            Key key = new Key("Keycard", "A Green Keycard", 5, 5.0f);
            spermket.GetInventory().AddItem(key);

            gasStation.setExit("north", beach);
            gasStation.setExit("east", sewerBranch);

            sewerBranch.setExit("west", gasStation);
            sewerBranch.LockRoom();
            player.SetCurrentRoom(beach);  // start game at beach
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
			Console.WriteLine("Welcome to Rusty Text!");
			Console.WriteLine("Rusty Text is a new, text version of Rust.");
			Console.WriteLine("Type 'help' if you need help.");
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
                    Console.WriteLine("player added: " + toTake.GetLongDescription());
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
                    player.GetInventory().UseKey(player, toUse, toOpen);
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
    }
}
