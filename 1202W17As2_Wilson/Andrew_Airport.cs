using System;
namespace W17As2_Wilson
{
	public class Andrew_Airport
	{
		public string name;
		public string location;
		public decimal runway_charge;

		public Andrew_Airport(string name, string location, decimal runway_charge)
		{
			this.name = name;
			this.runway_charge = runway_charge;
			this.location = location;
		}

		// TODO: create report, allow multiple reports per airport, create report for multiple months
		// TODO: Create menu for creating a report and accessing a report

		public Andrew_Report create_report(int flight_count, int passenger_count)
		{
			return new Andrew_Report(flight_count, passenger_count, runway_charge);
		}

		public void show_airport()
		{
			Console.WriteLine("Name: {0} Locaion: {1}", name, location);
		}
	}
}
