using lib;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chainsaw_serilog
{
	class Program
	{
		static void Main(string[] args)
		{
			var file = "logs.txt";
			if (File.Exists(file))
			{
				File.Delete(file);

			}

			Log.Logger = new LoggerConfiguration()
			   .MinimumLevel.Debug()
			   .WriteTo.LiterateConsole()
			   .WriteTo.File(new JsonFormatter(), file)
			   .CreateLogger();

			var gifts = new Demo().Run();

			if (Debugger.IsAttached)
			{
				Console.ReadKey();
			}
		}
	}
}
