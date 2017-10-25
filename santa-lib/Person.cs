using santa_lib.Logging;
using System;
using System.Collections.Generic;

namespace lib
{

	public class Person
	{
		private static readonly ILog Logger = LogProvider.For<Person>();


		public Person(string name, Gender gender, int age)
		{
			Id = Guid.NewGuid();
			Name = name;
			Gender = gender;
			Age = age;
		}

		public Guid Id { get; }
		public string Name { get; }
		public Gender Gender { get; }
		public int Age { get; }

		private List<Person> _children = new List<Person>();
		public IEnumerable<Person> Children
		{
			 get { return _children; }
		}

		public Person AddChild(string name, Gender gender, int age)
		{
			Logger.Debug(() => $"About to give person {Name} a child with name {name}, gender {gender}, age {age}");


			var child = new Person(name, gender, age);
			_children.Add(child);

			Logger.InfoFormat("Using Format: Gave person {@Name} a child: {@child}. State is now {@state}", Name, child, this);
			return child;
		}
	}
}
