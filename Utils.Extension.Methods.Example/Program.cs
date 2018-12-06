using System;
using System.Collections.Generic;

namespace Utils.Extension.Methods.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("------------List-------------:");
			List<string> list = null;
			Console.WriteLine($"List is empty? {list.IsEmpty()}");
			Console.WriteLine($"List is not empty? {list.NotEmpty()}");


			Console.WriteLine("------------Byte,String,Stream-------------:");
			string str = "This is test string";
			Console.WriteLine($"This string is null? {str.IsNullOrWhiteSpace()}");
			Console.WriteLine($"This string is not null? {str.NotNullOrWhiteSpace()}");

			var bytes = str.AsBytes();
			Console.WriteLine($"Bytes length is {bytes.Length}");
			Console.WriteLine($"Stream length is {bytes.AsStream().Length}");

			Console.WriteLine("------------Json-------------:");
			var obj = new { id = 1, name = "jack" };
			var json = obj.ToJson();
			Console.WriteLine($"Convert an object to josn string:{json}");
			Console.WriteLine($"Convert a json string to object:{json.JsonToObject<dynamic>()}");




			Console.ReadKey();
		}
	}
}
