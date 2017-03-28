using System;
namespace W17As2_Wilson
{
	public class Andrew_Airport
	{
		private string name;
		private string location;
		private decimal runway_charge;

		private Andrew_Report[] reports = new Andrew_Report[12];
		//Andrew_Helpers helper = new Andrew_Helpers();

		public Andrew_Airport(string name, string location, decimal runway_charge)
		{
			this.name = name;
			this.runway_charge = runway_charge;
			this.location = location;
		}

		public Andrew_Airport()
		{

			int i = 0;

			do
			{
				Console.Clear();
				switch (i)
				{
					case (0):
						this.name = Andrew_Helpers.get_string("Enter the name of this airport: ", "Name cannot be blank");
						i++;
						break;
					case (1):
						this.location = Andrew_Helpers.get_string("Enter the location of this airport: ", "Location cannot be blank");
						i++; 
						break;
					case (2):
						runway_charge = Andrew_Helpers.get_decimal("Enter the runway charge for this airport: ", 1499.99M, 3500.00M);
						return;
					default:
						return;
				}
			} while (true);
		}
		// TODO: Create menu for creating a report and accessing a report

		private Andrew_Report create_report(int flight_count, int passenger_count, int month)
		{
			// just returns a new instance of a report
			return new Andrew_Report(flight_count, passenger_count, runway_charge, month);
		}

		public void show_airport()
		{
			// puts all airport information into a friendly menu
			Console.Clear();
			Console.WriteLine("Name: {0} Location: {1} Runway Charge: {2}", name, location, runway_charge);
			show_reports();
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public override string ToString()
		{
			return string.Format("Name: {0} Location: {1} Runway Charge: {2}", name, location, runway_charge);
		}

		public void airport_menu()
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
					case(1):
						// Enter airport data
						set_data_menu();
						break;
					case(2):
						// View airport data in a report
						show_airport();
						break;
					case(3):
						return;
					default:
						Andrew_Helpers.input_error();
					break;
				}

			} while (true);
		}

		public void set_airport_menu()
		{

			string[] decisions = {  "Please choose an option...",
									"1: Create a new data entry.",
									"2: Edit an existing data entry." };

			//Console.WriteLine("Do action for which airport?");
			//show_reports();

			int decision = Andrew_Helpers.get_int(decisions);

			if (decision == 2)
			{
				set_data_menu(); // update airport menu
			}
			else
			{
				// set new airport data
			}
		}

		private void show_reports()
		{
			int report_count = 0;
			foreach (Andrew_Report report in reports)
			{
				if (report != null)
				{
					report_count++;
					report.show_report();
				}
			}

			if (report_count == 0)
			{
				Console.WriteLine("No reports created yet");
			}
		}

		private void create_report()
		{
			// month

			int month = 0;
			int flights = 0;
			int passengers = 0;

			int i = 0; // user inputs values in order, we use i to iterate through forms

			do
			{
				Console.Clear();
				switch (i)
				{
					case (0):
						Console.WriteLine("Enter month of the report: ");
						if (int.TryParse(Console.ReadLine(), out month))
						{
							if (month < 1 || month > 12)
							{
								Andrew_Helpers.input_error("Please enter a number between 1 and 12");
							}
							else
							{
								i++;
								if (reports[month - 1] != null)
								{
									string[] choices = { "There is already a report for that month, overwrite?",
														  "1: Yes", "2: No" };
									int decision = Andrew_Helpers.get_int(choices, 1, 2);
									if (decision == 2)
									{
										return;
									}
								}
							}
						}
						else
						{
							Andrew_Helpers.input_error("Please enter a number");
						}
						Console.Clear();
						break;
					case (1):
						Console.WriteLine("Enter Flights: ");
						if (int.TryParse(Console.ReadLine(), out flights))
						{
							if (flights < 0)
							{
								Andrew_Helpers.input_error("Please enter a positive number.");
							}
							else
							{
								i++;
							}

						}
						else
						{
							Andrew_Helpers.input_error("Please enter a number");
						}
						Console.Clear();
						break;
					case (2):
						Console.WriteLine("Enter Passengers: ");
						if (int.TryParse(Console.ReadLine(), out passengers))
						{

							if (passengers < 0)
							{
								Andrew_Helpers.input_error("Please enter a positive number.");
							}
							else
							{
								i++;
							}
						}
						else
						{
							Andrew_Helpers.input_error("Please enter a number");
						}
						Console.Clear();
						break;
					default:
						i++;
						break;
				}
			} while (i <= 2); // breaks when questions have been asked
			// add report in appropriate place in report array
			this.reports[month - 1] = create_report(flights, passengers, month);
			Console.Clear();
		}


		public void set_data_menu()
		{
			do
			{
				Console.Clear();
				string[] decisions = {	"1: Edit airport name",
									  	"2: Edit airport Location",
									  	"3: Edit airport runway charge",
										"4: Create airport report",
										"0: Back" };

				int number = Andrew_Helpers.get_int(decisions);

				// TODO: Validate inputs
				switch (number)
				{
					case (0):
						Console.Clear();
						return;
					case (1):
						Console.Clear();
						this.name = Andrew_Helpers.get_string("Enter the name of this airport: ", "Name cannot be blank");
						break;
					case (2):
						Console.Clear();
						this.location = Andrew_Helpers.get_string("Enter the location of this airport: ", "Location cannot be blank");
						break;
					case (3):
						Console.Clear();
						runway_charge = Andrew_Helpers.get_decimal("Enter the runway charge for this airport: ", 1499.99M, 3500.00M);
						break;
					case (4):
						create_report();
						break;
					default:
						Andrew_Helpers.input_error();
						break;
				}
			} while (true);
		}
	}
}
