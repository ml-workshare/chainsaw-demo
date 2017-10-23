namespace lib
{
	public class Gift
	{
		public string Name { get; set; }

		public int MinAge { get; set; }

		public int MaxAge { get; set; }

		public Gender Gender { get; set; }

		public Person Recipient { get; set; }
	}
}
