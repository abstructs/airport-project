﻿using System;
namespace W17As2_Wilson
{
	public class Andrew_Report
	{
		public int flight_count = 0;
		public int passenger_count = 0;
		decimal runway_charge = 0;
		public DateTime month = new DateTime(2016, 1, 1);
		public decimal revenue;

		public Andrew_Report(int flight_count, int passenger_count, decimal runway_charge, int month)
		{
			this.flight_count = flight_count;
			this.passenger_count = passenger_count;
			this.runway_charge = runway_charge;

			this.month = new DateTime(2016, month, 1); // specified only for 2016

			this.revenue = calculate_revenue(runway_charge, flight_count);
		}

		public static decimal calculate_revenue(decimal runway_charge, int flights)
		{
			return runway_charge * flights;
		}

		public override string ToString()
		{
			// override tostring class for easy string output 
			return string.Format("Report Month: {0} | Flights: {1} | Passengers: {3} | Revenue: {4:C}",
							  month.ToString("MMMM"), flight_count, passenger_count, runway_charge, revenue);
		}
	}
}
