using Laba12_2;
using Bib10;
using System;

public class Program
{
	static void Main(string[] args)
	{
		MyHashTable<Aircraft> myHash = new MyHashTable<Aircraft>();

		bool ok = false;

		while (!ok)
		{
			Console.WriteLine("Меню:");
			Console.WriteLine("1. Добавить воздушное судно");
			Console.WriteLine("2. Вывести хеш таблицу");
			Console.WriteLine("3. Проверить наличие воздушного судна");
			Console.WriteLine("4. Удалить воздушное судно");
			Console.WriteLine("5. Выход");

			Console.Write("Выберите действие: ");
			int choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					{
						Aircraft aircraft = new Aircraft();
						aircraft.RandomInit();
						myHash.AddItem(aircraft);
						Console.WriteLine("Воздушное судно добавлено в хеш таблицу.");
					}
					break;

				case 2:
					{
						Console.WriteLine("Хеш таблица:");
						myHash.Print();
					}
					break;

				case 3:
					{
						Console.Write("Введите данные о воздушном судне для проверки наличия: ");
						Aircraft aircraft1 = new Aircraft();
						aircraft1.Init();
						if (myHash.Contains(aircraft1))
						{
							Console.WriteLine("Воздушное судно присутствует в хеш таблице.");
						}
						else
						{
							Console.WriteLine("Воздушное судно отсутствует в хеш таблице.");
						}
					}
					break;

				case 4:
					{
						Console.Write("Введите данные о воздушном судне для удаления: ");
						Aircraft aircraft2 = new Aircraft();
						aircraft2.Init();
						if (myHash.RemoveData(aircraft2))
						{
							Console.WriteLine("Воздушное судно удалено из хеш таблицы.");
						}
						else
						{
							Console.WriteLine("Воздушное судно не найдено в хеш таблице.");
						}
					}
					break;

				case 5:
					{
						ok = true;
					}
					break;

				default:
					Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
					break;
			}
		}

		Console.WriteLine("Программа завершена");
	}
}


