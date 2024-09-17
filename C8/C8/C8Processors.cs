using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8
{
	public class C8Processors
	{

		public static string ProcessQ1Line(string inStr, Func<long, long[][], string> Solve)
		{
			var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			var n = long.Parse(lines[0]);

			var points = lines
				.Skip(1)
				.Select(
					line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()
				)
				.ToArray();

			return Solve(n, points);
		}

		public static string ProcessQ2Palindrome(string inStr, Func<long, long, long, long> Solve)
		{
			var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


			var nums = lines[0]
				.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(d => long.Parse(d))
				.ToArray();

			long n = nums[0];
			long x = nums[1];
			long k = nums[2];
	
			return Solve(n, x, k).ToString();
		}
	}
}