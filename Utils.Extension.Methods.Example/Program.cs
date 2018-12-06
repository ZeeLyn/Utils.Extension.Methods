using System;
using System.Threading;

namespace Utils.Extension.Methods.Example
{
	class Program
	{
		static void Main(string[] args)
		{

			//while (true)
			//{
			//	var now = DateTime.Now;
			//	var utcnow = DateTime.UtcNow;
			//	Console.WriteLine("Local:" + now + ";UTC:" + utcnow);
			//	Console.WriteLine(now.ToTimeStamp().ToLocalDateTime() + ";" + utcnow.ToTimeStamp());

			//	Thread.Sleep(1000);
			//}

			var r = "{]".IsJson();

			Console.WriteLine(r.ToJson());
			Console.ReadKey();
		}
	}
}
