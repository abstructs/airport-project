using System;
namespace W17As2_Wilson
{
	public class Andrew_Airport
	{
		private string name;
		private string location;
		private decimal runway_charge;

		private Andrew_Report[] reports = new Andrew_Report[12];

		public Andrew_Airport(string name, string location, decimal runway_charge)
		{
			this.name = name;
			this.runway_charge = runway_charge;
			this.location = location;
		}

		// TODO: create report, allow multiple reports per airport, create report for multiple months
		// TODO: Create menu for creating a report and accessing a report

		private Andrew_Report create_report(int flight_count, int passenger_count, int month)
		{
			return new Andrew_Report(flight_count, passenger_count, runway_charge, month);
		}

		private void show_airport()
		{
			Console.Clear();
			Console.WriteLine("Name: {0} Location: {1} Runway Charge: {2}", name, location, runway_charge);
			show_reports();
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public void airport_menu()
		{
			do
			{
				Console.Clear();
				string[] decisions = { "1: Add Airport Data",
									   "2: View Statistical Report",
									   "3: Exit" };

				int number = get_int(decisions);

				switch (number)
				{
					case(1):
						// Enter airport data
						airport_data_menu();
						break;
					case(2):
						// View airport data in a report
						show_airport();
						break;
					case(3):
						return;
					default:
						input_error();
					break;
				}

			} while (true);
		}

		private int get_int(string[] decisions)
		{			
			while (true)
			{
				print_decisions(decisions);

				int number;
				bool result = int.TryParse(Console.ReadLine(), out number);

				if (!result)
				{
					input_error();
					continue;
				}

				return number;
			}
		}

		private int get_int(string[] decisions, int min, int max)
		{
			while (true)
			{
				print_decisions(decisions);

				int number;
				bool result = int.TryParse(Console.ReadLine(), out number);

				if (!result)
				{
					input_error();
					continue;
				}
				else
				{
					if (number < min || number > max)
					{
						input_error();
						continue;
					}
				}

				return number;
			}
		}

		private decimal get_decimal(string message)
		{
			while (true)
			{
				Console.Write(message);

				decimal number;
				bool result = decimal.TryParse(Console.ReadLine(), out number);

				if (!result)
				{
					input_error();
					continue;
				}

				return number;
			}
		}

		private decimal get_decimal(string message, decimal min, decimal max)
		{
			while (true)
			{
				Console.Write(message);

				decimal number;
				bool result = decimal.TryParse(Console.ReadLine(), out number);

				if (!result)
				{
					input_error();
					continue;
				}
				else
				{
					if (number < min || number > max)
					{
						input_error(string.Format("Please enter a number between {0} and {1}.", min, max));
						continue;
					}
				}

				return number;
			}
		}

		private static void print_decisions(string[] decisions)
		{
			foreach (string decision in decisions)
			{
				Console.WriteLine(decision);
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

			int i = 0;

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
								input_error("Please enter a number between 1 and 12");
							}
							else
							{
								i++;
								if (reports[month - 1] != null)
								{
									string[] choices = { "There is already a report for that month, overwrite?",
														  "1: Yes", "2: No" };
									int decision = get_int(choices, 1, 2);
									if (decision == 2)
									{
										return;
									}
								}
							}
						}
						else
						{
							input_error("Please enter a number");
						}
						Console.Clear();
						break;
					case (1):
						Console.WriteLine("Enter Flights: ");
						if (int.TryParse(Console.ReadLine(), out flights))
						{
							if (flights < 0)
							{
								input_error("Please enter a positive number.");
							}
							else
							{
								i++;
							}

						}
						else
						{
							input_error("Please enter a number");
						}
						Console.Clear();
						break;
					case (2):
						Console.WriteLine("Enter Passengers: ");
						if (int.TryParse(Console.ReadLine(), out passengers))
						{

							if (passengers < 0)
							{
								input_error("Please enter a positive number.");
							}
							else
							{
								i++;
							}
						}
						else
						{
							input_error("Please enter a number");
						}
						Console.Clear();
						break;
					default:
						i++;
						break;
				}
			} while (i <= 2);

			this.reports[month - 1] = create_report(flights, passengers, month);
			Console.Clear();
		}

		private static string get_string(string message, string error_message)
		{
			while (true)
			{

				Console.Write(message + " ");
				
				string result = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(result))
				{
					return result;
				}

				input_error(error_message);
			}
		}

		private static string get_string(string message)
		{
			while (true)
			{

				Console.Write(message);

				string result = Console.ReadLine();
				if (result != "")
				{
					return result;
				}

				input_error();
			}
		}

		private void airport_data_menu()
		{
			do
			{
				Console.Clear();
				string[] decisions = {	"1: Enter airport name",
									  	"2: Enter airport Location",
									  	"3: Enter airport runway charge",
										"4: Create airport report",
										"0: Back" };

				int number = get_int(decisions);

				// TODO: Validate inputs
				switch (number)
				{
					case (0):
						Console.Clear();
						return;
					case (1):
						Console.Clear();
						this.name = get_string("Enter the name of this airport: ", "Name cannot be blank");
						break;
					case (2):
						Console.Clear();
						this.location = get_string("Enter the location of this airport: ", "Location cannot be blank");
						break;
					case (3):
						Console.Clear();
						runway_charge = get_decimal("Enter the runway charge for this airport: ", 1499.99M, 3500.00M);
						break;
					case (4):
						create_report();
						break;
					default:
						input_error();
						break;
				}
			} while (true);
		}

		private static void input_error()
		{
			Console.Clear();
			Console.WriteLine("Not a valid input.");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		private static void input_error(string error)
		{
			Console.Clear();
			Console.WriteLine(error + "\n");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		private static void input_error(int input_int)
		{
			Console.Clear();
			Console.WriteLine("\"{0}\" is not a valid input!", input_int);
			Console.ReadKey();
			Console.Clear();
		}

		private static void input_error(decimal input_decimal)
		{
			Console.Clear();
			Console.WriteLine("\"{0}\" is not a valid input!", input_decimal);
			Console.ReadKey();
			Console.Clear();
		}
	}
}
