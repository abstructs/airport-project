using System;
namespace W17As2_Wilson
{
	public class Andrew_User
	{

		Andrew_Airport[] airports = new Andrew_Airport[100];
		int airports_length = 0; // keep track of items in airport array

		public Andrew_User()
		{
		}

		public void user_menu()
		{
			string[] decisions = {
					"Welcome to Airportz! What would you like to do?",
					"1: Add Airport Data",
					"2: View Statistical Report",
					"\n0: Exit"
				};

			while(true)
			{
				Console.Clear();


				int number = Andrew_Helpers.get_int(decisions, 0, 2);

				switch (number)
				{
					case (0):
						Console.Clear();
						int confirm = Andrew_Helpers.get_int("Would you like to exit the program?\n1: Yes\n2: No", 1, 2);
						if (confirm == 1)
						{
							return;
						}

						break;
					case (1):
						set_airport();
						break;
					case (2):
						show_airport_menu();
						break;
					default:
						Andrew_Helpers.input_error();
						break;
				}
			}
		}

		private void set_airport()
		{
			string[] decisions = { 
				"You are in the airport data menu! Options: ",
				"1: Create new airport entry",
				"2: Edit an existing airport entry",
				"3: Create report for an existing airport",
				"\n0: Back" 
			};

			while(true)
			{
				Console.Clear();
				int decision = Andrew_Helpers.get_int(decisions, 0, 3);
				switch (decision)
				{
					case(0):
						return;
					case(1):
						create_new_airport();
						break;
					case(2):
						edit_airport();
						break;
					case(3):
						create_report();
						break;
					default:
						return;
				}
			}
		}

		private void show_airport_menu()
		{
			Console.Clear();

			if (airports_length == 0)
			{
				Andrew_Helpers.input_error("No airport data entered yet.");
				return;
			}

			string[] decisions = { 
				"View statistical report for which airport?",
				get_airports_string(), // returns string of all airports
				"-1: View All Airports And Reports",
				"0: Back" 
			};

			while (true)
			{
				int decision = Andrew_Helpers.get_int(decisions, -1, airports_length);

				if (decision == 0)
				{
					return;
				}
				else if (decision == -1)
				{
					show_all_airports_and_data();
					Console.Clear();
					continue;
				}

				Console.Clear();
				airports[decision - 1].show_all_data();
				Console.WriteLine("\nPress any key to continue...");
				Console.ReadKey();
				Console.Clear();
			}
		}

		private void create_report()
		{
			Console.Clear();

			if (airports_length == 0)
			{
				Andrew_Helpers.input_error("No airport data entered yet.");
				return;
			}

			string[] decisions = {
				"Create report for which airport?",
				get_airports_string(),
				"0: Back"
			};

			int decision = Andrew_Helpers.get_int(decisions, 0, airports_length);

			if (decision == 0)
			{
				return;
			}

			airports[decision - 1].create_report();
		}

		private void edit_airport()
		{
			Console.Clear();

			if (airports_length == 0)
			{
				Andrew_Helpers.input_error("No airport data entered yet.");
				return;
			}

			string[] decisions = { 
				"Add report to which airport?",
				get_airports_string(), 
				"\n0: Back" 
			};

			int decision = Andrew_Helpers.get_int(decisions, 0, airports_length);

			if (decision == 0)
			{
				return;
			}

			airports[decision - 1].edit_data_menu();
		}

		private void create_new_airport()
		{
			Andrew_Airport new_airport = new Andrew_Airport();
			airports[airports_length++] = new_airport;
		}

		private void create_airport()
		{
			Andrew_Airport airport = new Andrew_Airport();
			airport.edit_data_menu();

			airports[airports_length++] = airport;
		}

		private string get_airports_string()
		{
			string airports_string = "";
			int count = 1;
			foreach (Andrew_Airport airport in airports)
			{
				if (airport != null)
				{
					airports_string += count++.ToString() + ". " + airport + "\n";
				}
			}

			return airports_string;
		}

		private void show_all_airports_and_data()
		{
			foreach (Andrew_Airport airport in airports)
			{
				if (airport != null)
				{
					airport.show_all_data();
					Console.WriteLine("");
				}
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}

		private void show_airports() // print out all the airports
		{
			int airport_count = 0;

			foreach (Andrew_Airport airport in airports)
			{
				if (airport != null)
				{
					Console.WriteLine("{0}: {1}", ++airport_count, airport);
				}
			}
		}
	}
}
