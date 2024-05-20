using Laba12_1;
using Laba12_2;
using Laba12_3;
using Laba12_4;
using Bib10;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using static System.Diagnostics.Activity;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;
namespace Laba12_1
{
	[TestClass]
	public class TestLaba12_1
	{
		[TestMethod]
		public void Test1()
		{
			// Arrange
			Point<Aircraft> point = new Point<Aircraft>(null);

			// Act
			var result = point.ToString();

			// Assert
			Assert.AreEqual("", result);
		}

		[TestMethod] public void Test30()
		{
			// Arrange
			Point<Aircraft> instance = new Point<Aircraft>();
			Aircraft aircraft = new Aircraft();
			aircraft.RandomInit();
			instance.Data = aircraft;

			// Act
			int hashCode = instance.GetHashCode();

			// Assert
			Assert.AreEqual(instance.Data.GetHashCode(), hashCode);
		}

		[TestMethod]
		public void Test2()
		{
			MyList<Aircraft> list = new MyList<Aircraft>();

			using (StringWriter sw = new StringWriter())
			{
				Console.SetOut(sw);
				list.PrintList();
				string expected = "The list is empty" + Environment.NewLine;
				Assert.AreEqual(expected, sw.ToString());
			}
		}

		[TestMethod]
		public void Test3()
		{
			Aircraft aircraft = new Aircraft();
			Aircraft aircraft1 = new Aircraft();
			Aircraft[] collection = new Aircraft[] { aircraft, aircraft1 };
			MyList<Aircraft> list = new MyList<Aircraft>(collection);
			Assert.AreEqual(collection.Length, list.Count);
		}

		[TestMethod]
		public void Test4()
		{
			Assert.ThrowsException<Exception>(() => new MyList<Aircraft>(new Aircraft[0]));
		}

		[TestMethod]
		public void Test5()
		{
			MyList<Aircraft> list = new MyList<Aircraft>(3);
			Assert.AreEqual(3, list.Count);
		}


		[TestMethod]
		public void Test6()
		{
			MyList<Aircraft> list = new MyList<Aircraft>();
			Aircraft aircraft = new Aircraft();
			aircraft.RandomInit();
			list.AddToBegin(aircraft);
			Assert.AreEqual(1, list.Count);
		}

		[TestMethod]
		public void Test7()
		{
			MyList<Aircraft> list = new MyList<Aircraft>();
			Aircraft aircraft = new Aircraft();
			aircraft.RandomInit();
			list.AddToEnd(aircraft);
			Assert.AreEqual(1, list.Count);
		}

		[TestMethod]
		public void Test8()
		{
			// Arrange
			Point<Aircraft> point = new Point<Aircraft>();
			point.Data = default(Aircraft);

			// Act
			int hashCode = point.GetHashCode();

			// Assert
			Assert.AreEqual(default(int).GetHashCode(), hashCode);
		}

		[TestMethod]
		public void Test9()
		{
			// Arrange
			Point<Aircraft> point = new Point<Aircraft>();

			// Act

			// Assert
			Assert.AreEqual(default(Aircraft), point.Data);
			Assert.IsNull(point.Pred);
			Assert.IsNull(point.Next);
		}

		[TestMethod]
		public void Test10()
		{
			MyList<Aircraft> list = new MyList<Aircraft>();
			Aircraft aircraft1 = new Aircraft();
			aircraft1.RandomInit();
			Aircraft aircraft2 = new Aircraft();
			aircraft2.RandomInit();

			list.AddToEnd(aircraft1);
			list.AddToEnd(aircraft2);

			list.RemoveAllIndexedElements();

			Assert.AreEqual(1, list.Count);
		}

		[TestMethod]
		public void Test11()
		{
			// Arrange
			MyList<Aircraft> aircraftList = new MyList<Aircraft>();

			// Act
			aircraftList.RemoveAllIndexedElements();

			// Assert
			Assert.AreEqual(0, aircraftList.Count);
		}

		[TestMethod]
		public void Test12()
		{
			// Arrange
			MyList<Aircraft> aircraftList = new MyList<Aircraft>();
			aircraftList.AddToEnd(new Aircraft());
			aircraftList.AddToEnd(new Aircraft());
			aircraftList.AddToEnd(new Aircraft());

			// Act
			aircraftList.RemoveAllIndexedElements();

			// Assert
			Assert.AreEqual(1, aircraftList.Count);

		}

		[TestMethod]
		public void Test13()
		{
			// Arrange
			MyList<Aircraft> aircraftList = new MyList<Aircraft>();
			Aircraft aircraft1 = new Aircraft();
			Aircraft aircraft2 = new Aircraft();

			// Act
			aircraftList.AddAtIndex(aircraft1, 0);
			aircraftList.AddAtIndex(aircraft2, 1);

			// Assert
			Assert.AreEqual(2, aircraftList.Count);
		}

		[TestMethod]
		public void Test14()
		{
			// Arrange
			MyList<Aircraft> aircraftList = new MyList<Aircraft>();
			Aircraft aircraft1 = new Aircraft();
			Aircraft aircraft2 = new Aircraft();
			aircraftList.AddToEnd(aircraft1);
			aircraftList.AddToEnd(aircraft2);

			// Act
			bool result = aircraftList.RemoveItem(aircraft1);

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual(1, aircraftList.Count);
		}

		[TestMethod]
		public void Test15()
		{
			// Arrange
			MyList<Aircraft> list = new MyList<Aircraft>();
			Aircraft aircraft = new Aircraft();
			list.AddToEnd(aircraft);

			// Act
			bool result = list.RemoveItem(aircraft);

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		public void Test16()
		{
			// Arrange
			MyList<Aircraft> list = new MyList<Aircraft>();
			Aircraft aircraft = new Aircraft("Plane1", 5, "Двигатель1", 7);

			// Act
			list.AddToBegin(aircraft);
			var foundPoint = list.FindItem(aircraft);
			var foundAircraft = foundPoint.Data;

			// Assert
			Assert.AreEqual(1, list.Count);
			Assert.AreEqual(aircraft, foundAircraft);
		}

		[TestMethod]
		public void Test17()
		{
			// Arrange
			MyList<Aircraft> list = new MyList<Aircraft>();

			// Act
			using (StringWriter sw = new StringWriter())
			{
				Console.SetOut(sw);
				list.PrintList();
				string expected = "The list is empty";
				string actual = sw.ToString();

				// Assert
				Assert.AreEqual(expected.Trim(), actual.Trim());
			}
		}

		[TestMethod]
		public void Test18()
		{
			// Arrange
			var list = new MyList<Aircraft>(); // Создание экземпляра вашего класса списка
			var item1 = new Aircraft(); // Создание элемента списка
			var item2 = new Aircraft(); // Создание второго элемента списка

			list.AddToBegin(item1); // Добавление первого элемента в список

			// Act
			list.AddToBegin(item2); // Добавление второго элемента в список

			// Assert
			Assert.AreEqual(item2, list.beg.Data); // Проверка, что новый элемент стал первым в списке
			Assert.AreEqual(item1, list.beg.Next.Data); // Проверка, что старый первый элемент стал вторым
			Assert.AreEqual(null, list.beg.Pred); // Проверка, что у нового первого элемента нет предыдущего элемента
			Assert.AreEqual(list.beg, list.beg.Next.Pred); // Проверка, что у второго элемента указатель на предыдущий элемент указывает на новый первый элемент

		}

		[TestMethod]
		public void Test19()
		{
			// Arrange
			var list = new MyList<Aircraft>(); // Создание экземпляра вашего класса списка
			var itemNotInList = new Aircraft(); // Создание элемента списка, которого нет в списке

			// Act
			var foundItem = list.FindItem(itemNotInList);

			// Assert
			Assert.IsNull(foundItem); // Проверка, что метод возвращает null при поиске элемента, которого нет в списке
		}

		[TestMethod]
		public void Test20()
		{
			// Arrange
			var myList = new MyList<Aircraft>();
			Aircraft aircraft = new Aircraft();
			Aircraft aircraft1 = new Aircraft();
			Aircraft aircraft2 = new Aircraft();
			myList.AddToBegin(aircraft);
			myList.AddToBegin(aircraft2);
			myList.AddToBegin(aircraft1);

			// Redirect Console output to a StringWriter
			using (var sw = new System.IO.StringWriter())
			{
				Console.SetOut(sw);

				// Act
				myList.PrintList();

				string expectedOutput = "Нет, 0, Нет, 0\r\n     Нет, 0, Нет, 0\r\n     Нет, 0, Нет, 0"; // Ожидаемый вывод

				// Assert
				// Assert
				Assert.AreEqual(expectedOutput.Trim(), sw.ToString().Trim());

			}


		}

		[TestMethod]
		public void Test21()
		{
			// Arrange
			var list = new MyList<Aircraft>(); // Создание экземпляра вашего класса списка
			var itemToFind = new Aircraft(); // Создание элемента списка для поиска
			list.AddToEnd(itemToFind); // Добавление элемента в список

			// Act
			var foundItem = list.FindItem(itemToFind);

			// Assert
			Assert.AreEqual(itemToFind, foundItem.Data); // Проверка, что найденный элемент соответствует искомому элементу

		}




	}
}

namespace Laba12_2
{
	[TestClass]
	public class TestLaba12_2
	{
		[TestMethod]
		public void Test1()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>();
			var aircraft = new Aircraft("Boeing 747", 500, "LLL", 8);

			// Act
			hashTable.AddItem(aircraft);

			// Assert
			Assert.IsTrue(hashTable.Contains(aircraft));
		}

		[TestMethod]
		public void Test2()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>();
			var aircraft = new Aircraft("Airbus A380", 600, "LLL", 0);
			hashTable.AddItem(aircraft);

			// Act
			hashTable.RemoveData(aircraft);

			// Assert
			Assert.IsFalse(hashTable.Contains(aircraft));

		}

		[TestMethod]
		public void Test3()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>(4);
			var aircraft1 = new Aircraft("Boeing 737", 300, "FFF", 8);
			var aircraft2 = new Aircraft("Airbus A320", 200, "ooo", 6);

			// Act
			hashTable.AddItem(aircraft1);
			hashTable.AddItem(aircraft2);

			// Assert
			Assert.AreEqual(4, hashTable.Capacity);
		}

		[TestMethod]
		public void Test4()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>();
			var aircraft1 = new Aircraft("Boeing 777", 400, "ghj", 89);
			var aircraft2 = new Aircraft("Embraer E190", 100, "jgh", 7);

			// Act
			hashTable.AddItem(aircraft1);
			hashTable.AddItem(aircraft2);

			// Assert
			Assert.AreEqual(2, hashTable.Count);
		}

		[TestMethod]
		public void Test5()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>(2); // Capacity set to 2
			var aircraft1 = new Aircraft("Boeing 777", 400, "ghj", 89);
			var aircraft2 = new Aircraft("Embraer E190", 100, "ghj", 89);

			// Act
			hashTable.AddItem(aircraft1);
			hashTable.AddItem(aircraft2);

			// Assert
			Assert.AreEqual(2, hashTable.Count);
		}

		[TestMethod]
		public void Test6()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>();
			var aircraft1 = new Aircraft("Boeing 777", 400, "bvc", 6);
			var aircraft2 = new Aircraft("Embraer E190", 100, "rvhk", 6);
			hashTable.AddItem(aircraft1);
			hashTable.AddItem(aircraft2);

			// Act
			bool result = hashTable.RemoveData(aircraft1);

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual(1, hashTable.Count);
		}

		[TestMethod]
		public void Test7()
		{
			// Arrange
			MyHashTable<Aircraft> hashTable = new MyHashTable<Aircraft>();
			Aircraft aircraft1 = new Aircraft("", 6, "gfd", 78);
			Aircraft aircraft2 = new Aircraft("", 789, "hgf", 765);
			hashTable.AddItem(aircraft1);

			// Act
			int index = hashTable.FindItem(aircraft2);

			// Assert
			Assert.AreEqual(0, index); // Проверяем, что возвращается 0, если элемент не найден
		}

		[TestMethod]
		public void Test8()
		{
			// Arrange
			MyHashTable<Aircraft> hashTable = new MyHashTable<Aircraft>(2); // Устанавливаем начальную емкость 2
			Aircraft aircraft1 = new Aircraft("Boeing 747", 67, "", 9);
			Aircraft aircraft2 = new Aircraft("Airbus A380", 8, "", 9);
			Aircraft aircraft3 = new Aircraft("Embraer E190", 8, "", 89);

			// Act
			hashTable.AddItem(aircraft1);
			hashTable.AddItem(aircraft2);
			hashTable.AddItem(aircraft3);

			// Assert
			Assert.AreEqual(3, hashTable.Count);
		}

		[TestMethod]
		public void Test9()
		{
			// Arrange
			var hashTable = new MyHashTable<Aircraft>();
			Aircraft key = new Aircraft();
			key.RandomInit();

			// Act
			bool containsKey = hashTable.Contains(key);

			// Assert
			Assert.IsFalse(containsKey); // Проверяем, что ключ не содержится в хэш-таблице

		}

		[TestMethod]
		public void RemoveByKey_RemovesElementFromTable()
		{
			// Arrange
			MyHashTable<Aircraft> hashTable = new MyHashTable<Aircraft>();
			Aircraft aircraftForAdd = new Aircraft();

			aircraftForAdd.RandomInit();
			hashTable.AddItem(aircraftForAdd);

			Aircraft aircraftNotInChain = new Aircraft();
			aircraftNotInChain.RandomInit();

			// Act
			bool result = hashTable.Contains(aircraftNotInChain);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestPrintMethod()
		{
			// Arrange
			MyHashTable<Aircraft> table = new MyHashTable<Aircraft>();
			table.AddItem(new Aircraft("Boeing 747", 8, "", 9));
			table.AddItem(new Aircraft("Airbus A380", 9, "", 9));
			table.AddItem(new Aircraft("Embraer E190", 8, "", 9));

			StringWriter sw = new StringWriter();
			Console.SetOut(sw);

			// Act
			table.Print();
			string expectedOutput = "Boeing 747, 8, , 9\r\nAirbus A380, 9, , 9\r\nEmbraer E190, 8, , 9\r\n";


			// Assert
			Assert.AreEqual(expectedOutput, sw.ToString());
		}
	}

	namespace Laba12_3
	{
		[TestClass]
		public class TestLaba12_3
		{
			[TestMethod]
			public void Test19()
			{
				MyTree<Aircraft> tree = new MyTree<Aircraft>(5);
				Assert.AreEqual(5, tree.Count);
			}

			[TestMethod]
			public void Test20()
			{
				var point = new PointTree<Aircraft>();

				Assert.AreEqual("", point.ToString());

			}

			[TestMethod]
			public void Test21()
			{
				var aircraft = new Aircraft(); // Создание объекта Aircraft
				var point = new PointTree<Aircraft>(aircraft);

				Assert.AreEqual(aircraft.ToString(), point.ToString());
			}


			[TestMethod]
			public void Test22()
			{
				MyTree<Aircraft> tree = new MyTree<Aircraft>(3);
				Aircraft plane = new Aircraft("Модель3", 5, "Двигатель1", 5);
				Aircraft helicopter = new Aircraft("Модель6", 6, "Двигатель6", 6);
				Aircraft fighter = new Aircraft("Модель7", 7, "Двигатель7", 7);

				tree.AddPoint(plane);
				tree.AddPoint(helicopter);
				tree.AddPoint(fighter);

				Assert.IsTrue(tree.Count == 3);
			}

			[TestMethod]
			public void Test23()
			{
				var aircraft1 = new Aircraft();
				var aircraft2 = new Aircraft();
				var point1 = new PointTree<Aircraft>(aircraft1);
				var point2 = new PointTree<Aircraft>(aircraft2);

				Assert.AreEqual(0, point1.CompareTo(point2));
			}

			[TestMethod]
			public void Test24()
			{// Arrange
				var point1 = new PointTree<int>(10);
				var point2 = new PointTree<int>(5);

				// Act
				int result = point1.CompareTo(point2);

				// Assert
				Assert.IsTrue(result > 0); // point1 > point2
			}


			[TestMethod]
			public void Test25()
			{
				// Arrange
				var point1 = new PointTree<int>(5);
				var point2 = new PointTree<int>(5);

				// Assert
				Assert.IsFalse(point1.Equals(point2));
			}

			[TestMethod]
			public void Test26()
			{
				// Arrange
				var tree = new MyTree<Aircraft>(3);

				// Act
				tree.DeleteTree();

				// Assert
				Assert.AreEqual(0, tree.Count);
			}

			[TestMethod]
			public void Test27()
			{

				MyTree<Aircraft> tree = new MyTree<Aircraft>(3);
				Aircraft data = new Aircraft();
				data.RandomInit();
				tree.AddPoint(data);

				Aircraft data1 = new Aircraft();
				data1.RandomInit();
				tree.AddPoint(data1);

				Aircraft minElement = tree.FindMin();

				Assert.AreEqual(data, data);
			}
		}

	}



	namespace Laba12_4
	{
		[TestClass]
		public class Testlaba12_4
		{
			[TestMethod]
			public void Test1()
			{
				// Arrange
				PointCollection<Aircraft> point = new PointCollection<Aircraft>(null);

				// Act
				var result = point.ToString();

				// Assert
				Assert.AreEqual("", result);
			}

			[TestMethod]
			public void Test2()
			{
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();

				using (StringWriter sw = new StringWriter())
				{
					Console.SetOut(sw);
					list.PrintList();
					string expected = "The list is empty" + Environment.NewLine;
					Assert.AreEqual(expected, sw.ToString());
				}
			}

			[TestMethod]
			public void Test3()
			{
				Aircraft aircraft = new Aircraft();
				Aircraft aircraft1 = new Aircraft();
				Aircraft[] collection = new Aircraft[] { aircraft, aircraft1 };
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>(collection);
				Assert.AreEqual(collection.Length, list.Count);
			}

			[TestMethod]
			public void Test4()
			{
				Assert.ThrowsException<Exception>(() => new MyListCollection<Aircraft>(new Aircraft[0]));
			}

			[TestMethod]
			public void Test5()
			{
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>(3);
				Assert.AreEqual(3, list.Count);
			}


			[TestMethod]
			public void Test6()
			{
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();
				Aircraft aircraft = new Aircraft();
				aircraft.RandomInit();
				list.AddToBegin(aircraft);
				Assert.AreEqual(1, list.Count);
			}

			[TestMethod]
			public void Test7()
			{
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();
				Aircraft aircraft = new Aircraft();
				aircraft.RandomInit();
				list.AddToEnd(aircraft);
				Assert.AreEqual(1, list.Count);
			}

			[TestMethod]
			public void Test8()
			{
				// Arrange
				PointCollection<Aircraft> point = new PointCollection<Aircraft>();
				point.Data = default(Aircraft);

				// Act
				int hashCode = point.GetHashCode();

				// Assert
				Assert.AreEqual(default(int).GetHashCode(), hashCode);
			}

			[TestMethod]
			public void Test9()
			{
				// Arrange
				PointCollection<Aircraft> point = new PointCollection<Aircraft>();

				// Act

				// Assert
				Assert.AreEqual(default(Aircraft), point.Data);
				Assert.IsNull(point.Pred);
				Assert.IsNull(point.Next);
			}

			[TestMethod]
			public void Test10()
			{

			}

			[TestMethod]
			public void Test11()
			{

			}

			[TestMethod]
			public void Test12()
			{


			}

			[TestMethod]
			public void Test13()
			{

			}

			[TestMethod]
			public void Test14()
			{
				// Arrange
				MyListCollection<Aircraft> aircraftList = new MyListCollection<Aircraft>();
				Aircraft aircraft1 = new Aircraft();
				Aircraft aircraft2 = new Aircraft();
				aircraftList.AddToEnd(aircraft1);
				aircraftList.AddToEnd(aircraft2);

				// Act
				bool result = aircraftList.RemoveItem(aircraft1);

				// Assert
				Assert.IsTrue(result);
				Assert.AreEqual(1, aircraftList.Count);
			}

			[TestMethod]
			public void Test15()
			{
				// Arrange
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();
				Aircraft aircraft = new Aircraft();
				list.AddToEnd(aircraft);

				// Act
				bool result = list.RemoveItem(aircraft);

				// Assert
				Assert.IsTrue(result);
				Assert.AreEqual(0, list.Count);
			}

			[TestMethod]
			public void Test16()
			{
				// Arrange
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();
				Aircraft aircraft = new Aircraft("Plane1", 5, "Двигатель1", 7);

				// Act
				list.AddToBegin(aircraft);
				var foundPoint = list.FindItem(aircraft);
				var foundAircraft = foundPoint.Data;

				// Assert
				Assert.AreEqual(1, list.Count);
				Assert.AreEqual(aircraft, foundAircraft);
			}

			[TestMethod]
			public void Test17()
			{
				// Arrange
				MyListCollection<Aircraft> list = new MyListCollection<Aircraft>();

				// Act
				using (StringWriter sw = new StringWriter())
				{
					Console.SetOut(sw);
					list.PrintList();
					string expected = "The list is empty";
					string actual = sw.ToString();

					// Assert
					Assert.AreEqual(expected.Trim(), actual.Trim());
				}
			}


			[TestMethod]
			public void Test18()
			{
				// Arrange
				var list = new MyListCollection<Aircraft>(); // Создание экземпляра вашего класса списка
				var item1 = new Aircraft(); // Создание элемента списка
				var item2 = new Aircraft(); // Создание второго элемента списка

				list.AddToBegin(item1); // Добавление первого элемента в список

				// Act
				list.AddToBegin(item2); // Добавление второго элемента в список

				// Assert
				Assert.AreEqual(item2, list.beg.Data); // Проверка, что новый элемент стал первым в списке
				Assert.AreEqual(item1, list.beg.Next.Data); // Проверка, что старый первый элемент стал вторым
				Assert.AreEqual(null, list.beg.Pred); // Проверка, что у нового первого элемента нет предыдущего элемента
				Assert.AreEqual(list.beg, list.beg.Next.Pred); // Проверка, что у второго элемента указатель на предыдущий элемент указывает на новый первый элемент

			}





			[TestMethod]
			public void Test19()
			{
				// Arrange
				var list = new MyListCollection<Aircraft>(); // Создание экземпляра вашего класса списка
				var itemNotInList = new Aircraft(); // Создание элемента списка, которого нет в списке

				// Act
				var foundItem = list.FindItem(itemNotInList);

				// Assert
				Assert.IsNull(foundItem); // Проверка, что метод возвращает null при поиске элемента, которого нет в списке
			}

			[TestMethod]
			public void Test20()
			{

			}

			[TestMethod]
			public void Test30()
			{
				// Arrange
				PointCollection<Aircraft> instance = new PointCollection<Aircraft>();
				Aircraft aircraft = new Aircraft();
				aircraft.RandomInit();
				instance.Data = aircraft;

				// Act
				int hashCode = instance.GetHashCode();

				// Assert
				Assert.AreEqual(instance.Data.GetHashCode(), hashCode);
			}
		}

	}

	namespace Bib10
	{
		[TestClass]
		public class TestAircraft
		{

			[TestMethod]
			public void Test17()
			{
				// Arrange
				Aircraft aircraft1 = new Aircraft { Year = 2000 };
				Aircraft aircraft2 = new Aircraft { Year = 2000 };

				// Act
				bool result = aircraft1.Equals(aircraft2);

				// Assert
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void Test18()
			{
				// Arrange
				Aircraft aircraft1 = new Aircraft { Year = 2000 };
				Aircraft aircraft2 = new Aircraft { Year = 1995 };

				// Act
				bool result = aircraft1.Equals(aircraft2);

				// Assert
				Assert.IsFalse(result);
			}
		}
	}
}
