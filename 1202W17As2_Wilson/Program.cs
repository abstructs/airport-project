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

			airport1.airport_menu();
		}
	}
}
