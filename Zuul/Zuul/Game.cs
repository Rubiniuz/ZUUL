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
			Room outside, theatre, pub, lab, office, movieRoom;

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing admin office");
            movieRoom = new Room("in the movie player room");

            // initialise room exits
            outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);
            outside.AddItem(new Item("Axe", "A fireman's axe with a dull blade", 10.0f));
            Item lighter = new Item("Lighter", "A worn out lighter", 2.0f);
            lighter.SetEffect("damage");
            outside.AddItem(lighter);

            theatre.setExit("west", outside);
            theatre.setExit("up", movieRoom);

            movieRoom.setExit("down", theatre);

            pub.setExit("east", outside);

			lab.setExit("north", outside);
			lab.setExit("east", office);

			office.setExit("west", lab);

            player.SetCurrentRoom(outside);  // start game outside
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
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
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
                    Console.WriteLine(player.GetCurrentRoom().GetInventory());
                    break;
                case "status":
                    Console.WriteLine(player.Status());
                    Console.WriteLine(player.GetInventory());
                    break;
                case "take":
                    if (player.GetWeight() <= player.GetCarryLimit())
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
			Console.WriteLine("You wander around at the university.");
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
                    player.SetCurrentRoom(nextRoom);
                    player.Damage(15);
                    Console.WriteLine(player.GetCurrentRoom().getLongDescription());
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
            Item toTake = player.GetCurrentRoom().RemoveItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.AddItem(toTake);
                    player.AddWeight(toTake.GetWeight());
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
            Item toDrop = player.RemoveItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.GetCurrentRoom().AddItem(toDrop);
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
            Item toUse = player.GetItem(item);

            if (item == null)
            {
                Console.WriteLine("There is no item with this name: " + item + "!");
            }
            else
            {
                if (player.IsAlive())
                {
                    player.UseItem(toUse);
                    player.AddWeight(-toUse.GetWeight());
                    player.RemoveItem(item);
                    Console.WriteLine("player used: " + toUse.GetLongDescription());
                }
                else
                {
                    Console.WriteLine("you died " + player.GetCurrentRoom().getLongDescription());
                }
            }
        }
    }
}
