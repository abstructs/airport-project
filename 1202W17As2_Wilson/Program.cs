using System;

namespace W17As2_Wilson
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string name = "Pearsons";
			string location = "Toronto";
			decimal charge = 1500.99M;
			Andrew_Airport airport1 = new Andrew_Airport(name, location, charge);
			Andrew_Report report1 = airport1.create_report(4, 30);

			airport1.show_airport();
			report1.show_report();
		}
	}
}
