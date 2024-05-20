using Bib10;
namespace Laba12_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyCollection<Aircraft> c1 = new MyCollection<Aircraft>(10);
			foreach (Aircraft a in c1)
			{
				Console.WriteLine(a);
			}
			Console.WriteLine();
		}
	}
}