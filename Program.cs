using Bib10;
using System;
namespace Laba12_3
{
	public class Program
	{
		static void Main(string[] args)
		{
			MyTree<Aircraft> tree = new MyTree<Aircraft>(10); // Создание дерева с 10 элементами

			while (true)
			{
				Console.WriteLine("1. Показать дерево");
				Console.WriteLine("2. Добавить элемент");
				Console.WriteLine("3. Найти минимальный элемент");
				Console.WriteLine("4. Удалить элемент");
				Console.WriteLine("5. Удалить дерево");
				Console.WriteLine("6. Выход");

				Console.Write("Выберите действие: ");
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.WriteLine("Дерево:");
						tree.ShowTree();
						break;
					case 2:
						Console.Write("Введите данные для добавления: ");
						Aircraft aircraft = new Aircraft();
						aircraft.RandomInit();
						Console.WriteLine("Элемент добавлен");
						break;
					case 3:
						Console.WriteLine("Минимальный элемент: " + tree.FindMin());
						break;
					case 4:
						Console.Write("Введите элемент для удаления: ");
						Aircraft aircraft1 = new Aircraft();
						aircraft1.Init();
						Console.WriteLine("Элемент удален");
						break;
					case 5:
						tree.DeleteTree();
						Console.WriteLine("Дерево удалено.");
						break;
					case 6:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Некорректный выбор. Попробуйте снова.");
						break;
				}
			}
		}
	}
}
