using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Helpers
{
	public class PasswordConvertor
	{
		static long ASCIIWordSum(String str, long[] sumArr)
		{
			int l = str.Length;
			int pos = 0;
			long sum = 0;
			long bigSum = 0;
			for (int i = 0; i < l; i++)
			{
				if (str[i] == ' ')
				{
					bigSum += sum;
					sumArr[pos++] = sum;
					sum = 0;
				}
				else
					sum += str[i];
			}

			sumArr[pos] = sum;
			bigSum += sum;
			return bigSum;
		}

		public static long Convert()
		{
			String str = "client10-spasem-mir";

			int ctr = 0;
			for (int i = 0; i < str.Length; i++)
				if (str[i] == ' ')
					ctr++;

			long[] sumArr = new long[ctr + 1];

			long sum = ASCIIWordSum(str, sumArr);
			
			return sum;
			
		}
	}
}
