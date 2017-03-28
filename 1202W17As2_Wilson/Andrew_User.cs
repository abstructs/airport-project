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
			do
			{
				Console.Clear();
				string[] decisions = { "1: Add Airport Data",
									   "2: View Statistical Report",
									   "3: Exit" };

				int number = Andrew_Helpers.get_int(decisions);

				switch (number)
				{
					case (1):
						set_airport();
						break;
					case (2):
						get_airport();
						break;
					case (3):
						return;
					default:
						Andrew_Helpers.input_error();
						break;
				}

			} while (true);
		}

		private void set_airport()
		{
			string[] decisions = { "1: Create new data entry",
								   "2: Edit existing data entry/Add report to airport.",
								   "0: Back" };

			do
			{
				Console.Clear();
				int decision = Andrew_Helpers.get_int(decisions);
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
					default:
						return;
				}
			} while (true);

		}

		private void create_new_airport()
		{
			Andrew_Airport new_airport = new Andrew_Airport();
			airports[airports_length++] = new_airport;
		}

		private void create_airport()
		{
			Andrew_Airport airport = new Andrew_Airport();
			airport.set_data_menu();

			airports[airports_length++] = airport;
		}

		private void edit_airport()
		{
			Console.Clear();

			if (airports_length == 0)
			{
				Andrew_Helpers.input_error("No airport data entered yet.");
				return;
			}

			string[] decisions = { "Edit/Add report to which airport?",
									get_aiports(), "0: Back" };

			int decision = Andrew_Helpers.get_int(decisions, 0, airports_length);

			if (decision == 0)
			{
				return;
			}

			airports[decision - 1].set_data_menu();
		}

		private string get_aiports()
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

		private void get_airport()
		{
			if (airports_length == 0)
			{
				Andrew_Helpers.input_error("No airport data entered yet.");
				return;
			}

			string[] decisions = { "View report for which airport to which airport?",
									get_aiports(), "0: Back" };

			int decision = Andrew_Helpers.get_int(decisions, 0, airports_length);

			if (decision == 0)
			{
				return;
			}

			airports[decision - 1].show_airport();
		}

		private void show_airports() // print out all the airports
		{
			int airport_count = 0;

			foreach (Andrew_Airport airport in airports)
			{
				if (airport != null)
				{
					Console.WriteLine("{0}. {1}", ++airport_count, airport);
				}
			}
		}
	}
}
