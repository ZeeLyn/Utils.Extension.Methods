using System;
using System.Threading;

namespace Utils.Extension.Methods.Example
{
	class Program
	{
		static void Main(string[] args)
		{

			while (true)
			{
				Console.WriteLine(DateTime.Now.ToLocalTimeStamp());
				Thread.Sleep(1000);
			}

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}
