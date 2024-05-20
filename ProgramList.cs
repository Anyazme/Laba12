using Bib10;
namespace Laba12_1
{
	public class Program
	{
		static void Main(string[] args)
		{
			MyList<Aircraft> list = new MyList<Aircraft>();	
			bool ok = false;
			while (!ok)
			{
				try
				{
					Console.WriteLine("Меню:");
					Console.WriteLine("1. Создать новый список заданного размера");
					Console.WriteLine("2. Вывести список");
					Console.WriteLine("3. Добавить воздушное судно в начало списка");
					Console.WriteLine("4. Добавить воздушное судно в конец списка");
					Console.WriteLine("5. Удалить воздушное судно из списка");
					Console.WriteLine("6. Добавить в список элемент с заданным номером");
					Console.WriteLine("7. Удалить все элементы с нечетными номерами");
					Console.WriteLine("8. Выход");
					Console.WriteLine("Введите ваш выбор:");

					int answer = int.Parse(Console.ReadLine());

					switch (answer)
					{
						case 1:
							{
								Console.WriteLine("Размер списка?");
								int size = int.Parse(Console.ReadLine());
								list = new MyList<Aircraft>(size);
								Console.WriteLine("Список создан");
								break;
							}

						case 2:
							{
								list.PrintList();
								break;
							}

						case 3:
							{
								Aircraft aircraft2 = new Aircraft();
								aircraft2.RandomInit();
								list.AddToBegin(aircraft2);
								Console.WriteLine("Элемент добавлен в начало");
								break;
							}

						case 4:
							{
								Aircraft aircraft3 = new Aircraft();
								aircraft3.RandomInit();
								list.AddToEnd(aircraft3);
								Console.WriteLine("Элемент добавлен в конец");
								break;
							}

						case 5:
							{
								Aircraft aircraft4 = new Aircraft();
								aircraft4.Init();
								if (!list.RemoveItem(aircraft4))
								{
									Console.WriteLine("Элемент не найден");
								}
								else
								{
									Console.WriteLine("Элемент удален");
								}
								break;
							}

						case 6:
							{
								Console.WriteLine("Введите индекс, куда добавить элемент:");
								int index = int.Parse(Console.ReadLine());

								Aircraft aircraft4 = new Aircraft();
								aircraft4.RandomInit();

								list.AddAtIndex(aircraft4, index);
								Console.WriteLine("Элемент добавлен по индексу " + index);
								break;
							}

						case 7:
							{
								list.RemoveAllIndexedElements();
								Console.WriteLine("Удалены все элементы с нечетными индексами");
								break;
							}

						case 8:
							{
								ok = true;
								break;

							}
					}
				}

				catch (Exception ex)
				{
					Console.WriteLine($"Ошибка: {ex}");
				}
			}
		}
	}
} 
		
