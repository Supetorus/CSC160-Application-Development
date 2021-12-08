using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Foundation
{
	class LINQ
	{
		public static void DoIt()
		{
			string[] aryNames = { "Chandler", "Chandlina", "Chandler Jr." };

			var results = from name in aryNames
						  where name.Contains("Jr")
						  select name;

			aryNames[0] = "Channy Boi";
			/*
						foreach (var name in results)
						{
							Console.Write(name + "|");
						}
						Console.WriteLine();*/

			var methodResult = aryNames.Where(name => name.Contains("lina")).Select(n => n.Length);

			/*			foreach (var name in methodResult)
						{
							Console.Write(name + " | ");
						}
						Console.WriteLine();*/

			int[] numbers = { 10, 8, 24, 2434, 3442, 34324234 };
			var orderResult = from n in numbers
							  where n > 10
							  orderby n descending
							  select n;

			/*			foreach (var number in orderResult)
						{
							Console.Write(number + " ");
						}
						Console.WriteLine();*/

			var firstTenOrGreater = numbers.First(num => num > 10);

			Console.WriteLine(firstTenOrGreater);
		}
	}
}
