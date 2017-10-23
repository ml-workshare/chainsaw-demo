using System;
using System.Collections.Generic;

namespace lib
{
	public enum Gender
	{
		Male,
		Female,
	}

	public class Person
	{

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
			var child = new Person(name, gender, age);
			_children.Add(child);
			return child;
		}
	}
}
