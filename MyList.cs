using Bib10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12_1
{
	 public class MyList<T> where T : IInit, ICloneable, new()
	 {
	    public Point<T>? beg = null;
		public Point<T>? end = null;

		int count = 0;
		public int Count => count;

		public Point<T> MakeRandomData()
		{
			T data = new T();
			data.RandomInit();
			return new Point<T>(data);
		}

		public T MakeRandomItem()
		{
			T data = new T();
			data.RandomInit();
			return data;
		}

		public void AddToBegin(T item)
		{
			T newData = (T)item.Clone();//глубокое копирование
			Point<T> newItem = new Point<T>(newData);
			count++;
			if (beg != null)
			{
				beg.Pred = newItem;
				newItem.Next = beg;
				beg = newItem;
			}
			else
			{
				beg = newItem;
				end = beg;
			}
		}

		//вспомогательный метод
		public void AddToEnd(T item)
		{
			T newData = (T)item.Clone();//глубокое копирование 
			Point<T> newItem = new Point<T>(newData); //создаем новый элемент 
			count++;  //увеличиваем счетчик 
			if (end != null)  //проверка
			{
				end.Next = newItem; //следующий элемент связываем 
				newItem.Pred = end; //связываем 
				end = newItem; //ставим end в последний элемент 
			}
			else
			{
				beg = newItem;
				end = beg;
			}
		}

		//конструктор без параметров
		public MyList() { }

		//конструктор с параметрами 
		public MyList(int size)
		{
			if (size <= 0) throw new Exception("size less zero");
			beg = MakeRandomData();
			end = beg;
			for (int i = 1; i < size; i++)
			{
				T newItem = MakeRandomItem();
				AddToEnd(newItem);
			}
			count = size;
		}

		//конструктор для создания списка 
		public MyList(T[] collection)
		{
			if (collection == null) throw new Exception("empty collection null");

			if (collection.Length == 0)
			{
				throw new Exception("empty collection");
			}

			T newData = (T)collection[0].Clone();
			beg = new Point<T>(newData);
			end = beg;
			for (int i = 0; i < collection.Length; i++)
			{
				AddToEnd(collection[i]);
			}
		}

		public void PrintList()
		{
			if (count == 0) Console.WriteLine("The list is empty");
			Point<T>? current = beg;
			for (int i = 0; current != null; i++)
			{
				Console.WriteLine(current);
				current = current.Next;
			}
		}


		public Point<T>? FindItem(T item) //возвращает ссылку на элемент, который ищем
		{
			Point<T>? current = beg;
			while (current != null)
			{
				if (item == null || item == null)
				{
					throw new Exception();
				}
				if (current.Data.Equals(item))
				{
					return current;
				}
				current = current.Next;
			}
			return null;
		}

		public bool RemoveItem(T item)
		{
			if (beg == null)
			{
				throw new Exception("the empty list");
			}
			Point<T> pos = FindItem(item);
			if (pos == null)
			{
				return false;
			}
			count--;
			//one element
			if (beg == end)
			{
				beg = end = null;
				return true;
			}
			//the first
			if (pos.Pred == null)
			{
				beg = beg?.Next;
				beg.Pred = null;
				return true;
			}
			// the last
			if (pos.Next == null)
			{
				end = end.Pred;
				end.Next = null;
				return true;
			}
			//other situations
			Point<T> next = pos.Next;
			Point<T> pred = pos.Pred;
			pos.Next.Pred = pred;
			pos.Pred.Next = next;
			return true;
		}

		public void AddAtIndex(T item, int index)
		{
			if (index < 0 || index > count)
			{
				throw new IndexOutOfRangeException("Index is out of range.");
			}

			
			if (index == 0)
			{
				AddToBegin(item);
			}
			else if (index == count)
			{
				AddToEnd(item);
			}
			else
			{
				T newData = (T)item.Clone();
				Point<T> newItem = new Point<T>(newData);
				count++;

				Point<T>? current = beg;
				for (int i = 0; i < index - 1; i++)
				{
					current = current?.Next;
				}

				Point<T> next = current?.Next;
				current.Next = newItem;
				newItem.Pred = current;
				newItem.Next = next;
				next.Pred = newItem;
			}
		}

		public void RemoveAllIndexedElements()
		{
			Point<T>? current = beg;
			int index = 1;

			while (current != null)
			{
				if (index % 2 != 0)
				{
					Point<T> next = current.Next;
					Point<T> pred = current.Pred;

					if (pred == null) // Удаляем первый элемент
					{
						beg = next;
						if (next != null)
						{
							next.Pred = null;
						}
					}
					else if (next == null) // Удаляем последний элемент
					{
						end = pred;
						if (pred != null)
						{
							pred.Next = null;
						}
					}
					else // Удаляем элемент из середины списка
					{
						pred.Next = next;
						next.Pred = pred;
					}

					count--;
				}

				current = current.Next;
				index++;
			}
		}

		
	}
}


