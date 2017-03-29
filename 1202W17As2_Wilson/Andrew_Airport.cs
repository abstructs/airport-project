using System;

namespace W17As2_Wilson
{
	public class Andrew_Airport
	{
		private string name;
		private string location;
		private decimal runway_charge;
		private int report_count = 0;

		private Andrew_Report[] reports = new Andrew_Report[12]; // maximum of 12 reports

		public Andrew_Airport(string name, string location, decimal runway_charge)
		{
			this.name = name;
			this.runway_charge = runway_charge;
			this.location = location;
		}

		public Andrew_Airport()
		{
			Console.Clear();
			this.name = get_name();
			Console.Clear();
			this.location = get_location();
			Console.Clear();
			this.runway_charge = get_runway_charge();
		}

		private Andrew_Report create_report(int flight_count, int passenger_count, int month)
		{
			// just returns a new instance of a report
			return new Andrew_Report(flight_count, passenger_count, runway_charge, month);
		}

		public void show_all_data()
		{
			// puts all airport information into a friendly menu
			Console.WriteLine("AIRPORT:\nName: {0} | Location: {1} | Runway Charge: {2:C}", name, location, runway_charge);
			show_reports(); // shows all the reports
		}

		public override string ToString()
		{
			// override tostring class for easy string output 
			return string.Format("| Name: {0} | Location: {1} | Runway Charge: {2:C} | Reports: {3} |", name, location, 
			                     runway_charge, report_count);
		}

		public void airport_menu()
		{
			while(true)
			{
				Console.Clear();
				string[] decisions = {
					"Welcome to the airport menu! Options: ",
					"1: Add Airport Data",
					"2: View Statistical Report",
					"\n0: Exit" 
				};

				int number = Andrew_Helpers.get_int(decisions, 0, 2);

				switch (number)
				{
					case (0):
						return;
					case(1):
						// Enter airport data
						edit_data_menu();
						break;
					case(2):
						// View airport data in a report
						Console.Clear();
						show_all_data();
						// pause to allow user to view report
						Console.WriteLine("\nPress any key to continue...");
						Console.ReadKey();
						Console.Clear();
						break;
					default:
						Andrew_Helpers.input_error();
					break;
				}

			}
		}

		private void show_reports()
		{
			if (report_count == 0)
			{
				Console.WriteLine("No reports created yet");
				return;
			}

			Console.WriteLine("REPORTS: ");

			foreach (Andrew_Report report in reports)
			{
				
				if (report != null)
				{
					Console.WriteLine("{0}", report);
				}
			}


		}

		public void create_report()
		{
			int month = 0;
			int flights = 0;
			int passengers = 0;

			int i = 0; // user inputs values in order, we use i to iterate through forms
			// this code design is an "event handler"
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
								i++; // iterate to next switch statement as valid month was inputted
								if (reports[month - 1] != null) // check if there's already a reporting existing in that index
								{
									string[] choices = { 
										"There is already a report for that month, overwrite?",
										"1: Yes", "2: No"
									};

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
			} while (i <= 2); // breaks when all 3 questions have been asked

			// add report in appropriate place in report array
			this.reports[month - 1] = create_report(flights, passengers, month);

			// iterate report count 
			report_count++;

			Console.Clear();
		}

		public void edit_data_menu()
		{
			while(true)
			{
				Console.Clear();
				string[] decisions = {
					"1: Edit airport name. Currently: " + this.name,
					"2: Edit airport Location. Currently: " + this.location,
					"3: Edit airport runway charge. Currently: " + this.runway_charge.ToString("C"),
					"4: Create airport report. There is currently " + this.report_count.ToString() + " reports.",
					"\n0: Back" 
				};

				int number = Andrew_Helpers.get_int(decisions);

				switch (number)
				{
					case (0):
						Console.Clear();
						return;
					case (1):
						Console.Clear();
						this.name = get_name();
						break;
					case (2):
						Console.Clear();
						this.location = get_location();
						break;
					case (3):
						Console.Clear();
						runway_charge = get_runway_charge();
						break;
					case (4):
						create_report();
						break;
					default:
						Andrew_Helpers.input_error();
						break;
				}
			}
		}

		private static string get_name()
		{
			return Andrew_Helpers.get_string("Enter the name of this airport: ", "Name cannot be blank");
		}

		private static string get_location()
		{
			return Andrew_Helpers.get_string("Enter the location of this airport: ", "Location cannot be blank");
		}

		private static decimal get_runway_charge()
		{
			return Andrew_Helpers.get_decimal("Enter the runway charge for this airport: ", 1499.99M, 3500.00M);
		}
	}
}
