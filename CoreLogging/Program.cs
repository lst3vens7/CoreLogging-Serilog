using Serilog;
using Serilog.Core;
using System;

namespace CoreLogging
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");
			{
				Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(@"logfile.txt").CreateLogger();

				for (int x = 0; x < 2; x++)
				{
					Log.Information($"Hello, Serilog! {x}");
					Log.Warning($"Goodbye, Serilog. {x}");
					Log.Information($"Time to add two numbers: {DateTime.Now.ToUniversalTime()}    {x}");
					Log.Verbose($"Verbose log message: {x}");
				}
				Log.CloseAndFlush();
				Console.WriteLine("--------");
				ReadFromFile();
				Console.ReadLine();
			}
		}

		private static void ReadFromFile()
		{
			string[] lines = System.IO.File.ReadAllLines(@"logfile.txt");
			foreach (string line in lines)
			{
				Console.WriteLine("\t" + line);
			}
		}
	}
}