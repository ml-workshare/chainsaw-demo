using System;
using System.Collections.Generic;
using System.Linq;

namespace lib
{

	public class SantaService
	{ 
		public void AllocateGifts(Person parent, IEnumerable<Gift> gifts)
		{
			var allPeople = Flatten(parent).ToList();

			foreach(var person in allPeople)
			{
				var suitableGifts = gifts.Where(g => g.Gender == person.Gender && person.Age >= g.MinAge && person.Age <= g.MaxAge && g.Recipient == null);
				if(!suitableGifts.Any())
				{ 
					throw new InvalidOperationException("Santa forgot about someone! Was someone bad?");
				}

				var gift = suitableGifts.First();
				gift.Recipient = person;
			}
		}

		private static IEnumerable<Person> Flatten(Person root)
		{
			var stack = new Stack<Person>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				var current = stack.Pop();
				yield return current;
				foreach (var child in current.Children)
					stack.Push(child);
			}
		}
	}
}
