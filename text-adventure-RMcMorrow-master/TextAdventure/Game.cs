using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
	class Game
	{
		Location currentLocation;

		public bool isRunning = true;

		private List<Item> inventory;

		public Game()
		{
			inventory = new List<Item>();

			Console.WriteLine("You wake up Slightly dazed and confused, a voice echo's around the room over and intercom.\n.");

			// build the "map"
			Location l1 = new Location("Grey Room", "The room is plain and empty, One door is on each ");
			Item rock = new Item("rock");// had to add rock here
			l1.addItem(rock);

			Location l2 = new Location("End of hall", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
			Item window = new Item("window");//had to add window here
			l2.addItem(window);

			Location l3 = new Location("Small study", "This is a small and cluttered study, containing a desk covered with\npapers. Though they no doubt are of some importance,\nyou cannot read their writing");

			l1.addExit(new Exit(Exit.Directions.North, l2));
			l1.addExit(new Exit(Exit.Directions.East, l3));

			l2.addExit(new Exit(Exit.Directions.South, l1));

			l3.addExit(new Exit(Exit.Directions.West, l1));

			currentLocation = l1;
			showLocation();
		}

		public void showLocation()
		{
			Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
			Console.WriteLine(currentLocation.getDescription());

			if (currentLocation.getInventory().Count > 0)
			{
				Console.WriteLine("\nThe room contains the following:\n");

				for ( int i = 0; i < currentLocation.getInventory().Count; i++ )
				{
					Console.WriteLine(currentLocation.getInventory()[i].ToString());
				}
			}
	
			Console.WriteLine("\nAvailable Exits: \n");

			foreach (Exit exit in currentLocation.getExits() )
			{
				Console.WriteLine(exit.getDirection());
			}

			Console.WriteLine();
		}

        // TODO: Implement the input handling algorithm.
		public void doAction(string command)
		{
			Console.WriteLine("\nInvalid command, are you confused?\n");
		}

		private void showInventory()
		{
			if ( inventory.Count > 0 )
			{
				Console.WriteLine("\nA quick look in your bag reveals the following:\n");

				foreach ( Item item in inventory )
				{
					Console.WriteLine(item.ToString());
				}
			}
			else
			{
				Console.WriteLine("Your bag is empty.");
			}

			Console.WriteLine("");// prints after saying your bag is empty and possibly after telling you what you have in your inventory.
		}

		public void Update()
		{
			string currentCommand = Console.ReadLine().ToLower();

			// instantly check for a quit
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }
            if (currentCommand == "inventory" || currentCommand == "inv" || currentCommand == "bag")
            {
                // shows what the player has in their inventory.
                showInventory();
                return;
            }
            if (currentCommand == "map" || currentCommand == "location")
            {
                // shows the player current locaton.
                showLocation();
                return;
            }

            // otherwise, process commands.
            doAction(currentCommand);
		}
	}
}
