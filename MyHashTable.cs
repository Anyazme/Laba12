using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib10;

namespace Laba12_2
{	
	public class MyHashTable<T> where T : IInit, ICloneable, new()
	{
		T[] table; //таблица 
		int count = 0; // кол-во записей
		double fillRatio; // к-т заполняемости таблицы 

		public int Capacity => table.Length; //емкость, кол-во выделенной памяти 
		public int Count => count; //текущее кол-во элементов 

		//конструктор
		public MyHashTable(int size = 10, double fillRatio = 0.72)
		{
			table = new T[size];
			this.fillRatio = fillRatio;//заполняем коэффицент 

		}

		public void Print()
		{
			int i = 0;
			foreach (T item in table)
			{
				Console.WriteLine($"{i} : {item}");
				i++;
			}
		}


		//private
		int GetIndex(T data)
		{
			return Math.Abs(data.GetHashCode() % Capacity);
		}

		//добавление элемента в таблицу 
		void AddData(T data)
		{
			if (data == null) return; // доб-ся пустой элемент 
									  //ищем место
			int index = GetIndex(data);
			int current = index; //запомнили индекс 
								 //уже занято 
			if (table[index] != null)
			{
				//идем до конца таблицы или до первого пустого места 
				while (current < table.Length && table[current] != null)
				{
					current++;
				}

				//если таблица закончилась 
				if (current == table.Length)
				{
					//идем от начала таблицы до индекса, который запомнили 
					current = 0;
					while (current < index && table[current] != null)
					{
						current++;
					}

					//места нет
					if (current == index)
					{
						throw new Exception("Нет места в таблице");
					}
				}
			}

			//Место найдено
			table[current] = data;
			count++;
		}


		public int FindItem(T data)
		{
			//находим индекс
			int index = GetIndex(data);
			//нет элемента
			if (table[index] == null) return -1;

			//есть элемент, совпадает
			if (table[index].Equals(data))
			{
				return index;
			}
			else //не совпадает 
			{
				int current = index; // идем вниз по таблице 
				while (current < table.Length)
				{
					if (table[current] != null && table[current].Equals(data))
					{
						return current;
					}
					current++;
				}
				current = 0; //идем с начала таблицы
				while (current < index)
				{
					if (table[current] != null && table[current].Equals(data))
					{
						return current;
					}
					current++;
				}
				return -1; //не нашли

			}

		}

		//поиск
		public bool Contains(T data) //возвращает true или false
		{
			return !(FindItem(data) < 0);// значит ничего не нашли 
		}

		//удаление 
		public bool RemoveData(T data) //лучше тем, что после удаленного элемента у элементов идет перехеширование
		{
			int index = FindItem(data);
			if (index < 0) return false;

			// Удаляем элемент из таблицы
			table[index] = default;
			count--;

			// новое хеширование для элементов, следующих за удаленным элементом
			int currentIndex = (index + 1) % Capacity;
			while (table[currentIndex] != null)
			{
				T temp = table[currentIndex];
				table[currentIndex] = default;
				count--;
				AddData(temp); // переставляем элемент на новое место
				currentIndex = (currentIndex + 1) % Capacity;
			}

			return true;
		}


		//добавление 
		public void AddItem(T item)
		{
			if (Count / Capacity > fillRatio)
			{
				T[] temp = (T[])table.Clone();//увеличиваем таблицу в 2 раза и переписываем всю информацию
				table = new T[temp.Length * 2];
				count = 0;
				for (int i = 0; i < temp.Length; i++)
					AddData(temp[i]);
			}

			//Добавляем новый элемент 
			AddData(item);
		}

	}
}
