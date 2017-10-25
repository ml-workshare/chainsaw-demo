using santa_lib.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib
{
    public class Demo
    {
		private static readonly ILog Logger = LogProvider.For<Demo>();

		public IEnumerable<Gift> Run()
		{
			var steve = new Person("Steve" + Environment.NewLine + "Jobs", Gender.Male, 100);
			var alan = steve.AddChild("Alan", Gender.Male, 75);
			var lisa = alan.AddChild("Lisa", Gender.Female, 50);
			var flo = lisa.AddChild("Flo", Gender.Female, 25);
			var anna = flo.AddChild("Anna", Gender.Female, 12);
			var jane = flo.AddChild("Jane", Gender.Female, 3);
			var jack = flo.AddChild("Jack", Gender.Male, 6);

			var gifts = new List<Gift>
			{
				new Gift{ Gender = Gender.Male, MaxAge = 100, MinAge=100, Name="Whiskey"},
				new Gift{ Gender = Gender.Male, MaxAge = 75, MinAge=75, Name="Red Wine"},
				new Gift{ Gender = Gender.Female, MaxAge = 50, MinAge=50, Name="White Wine"},
				new Gift{ Gender = Gender.Female, MaxAge = 25, MinAge=25, Name="White Lightning"},
				new Gift{ Gender = Gender.Female, MaxAge = 12, MinAge=12, Name="Cola"},
				new Gift{ Gender = Gender.Female, MaxAge = 3, MinAge=3, Name="Milk"},
				//new Gift{ Gender = Gender.Male, MaxAge = 6, MinAge=6, Name="Juice"},
			};

			try
			{
				var santaService = new SantaService();
				santaService.AllocateGifts(steve, gifts);
			}
			catch (Exception ex)
			{
				Logger.ErrorException("Caught unhandled exceptoin", ex);
			}
			return gifts;
		}
	}
}
