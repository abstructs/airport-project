using System;
namespace W17As2_Wilson
{
	public class Andrew_Helpers
	{
		public static int get_int(string decision, int min, int max)
		{
			while (true)
			{
				Console.WriteLine(decision);

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

		public static void input_error()
		{
			Console.Clear();
			Console.WriteLine("Not a valid input.");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public static void print_decisions(string[] decisions)
		{
			foreach (string decision in decisions)
			{
				Console.WriteLine(decision);
			}
		}

		public static int get_int(string[] decisions, int min, int max)
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

		public static int get_int(string[] decisions)
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

		public static int get_int(string decision)
		{
			while (true)
			{
				Console.WriteLine(decision);

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


		public decimal get_decimal(string message)
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

		public static decimal get_decimal(string message, decimal min, decimal max)
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

		public static string get_string(string message)
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

		public static string get_string(string message, string error_message)
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

		public static void input_error(string error)
		{
			Console.Clear();
			Console.WriteLine(error + "\n");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public static void input_error(int input_int)
		{
			Console.Clear();
			Console.WriteLine("\"{0}\" is not a valid input!", input_int);
			Console.ReadKey();
			Console.Clear();
		}

		public static void input_error(decimal input_decimal)
		{
			Console.Clear();
			Console.WriteLine("\"{0}\" is not a valid input!", input_decimal);
			Console.ReadKey();
			Console.Clear();
		}

	}
}
