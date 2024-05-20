using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib10;

namespace Laba12_3
{
	public class MyTree<T> where T : IInit, IComparable, new()
	{
		PointTree<T>? root = null;
		int count = 0;
		public PointTree<Aircraft> Root;

		public int Count => count;
		public MyTree(int length)
		{
			count = length;
			root = MakeTree(length, root);
		}

		public MyTree(object value)
		{
		}

		public void ShowTree()
		{
			Show(root);
		}

		//ИСД
		public PointTree<T>? MakeTree(int length, PointTree<T>? current)
		{
			if (length <= 0)
			{
				return null;
			}

			current = new PointTree<T>(new T());
			current.Left = MakeTree(length - 1, current.Left);
			current.Right = MakeTree(length - 1, current.Right);

			return current;
		}


		public void Show (PointTree<T>? point, int spaces = 5)
		{
			if (point != null)
			{
				Show(point.Left, spaces + 5);
	            for (int i = 0; i < spaces; i++)
				{
					Console.WriteLine(" ");
				}
				Console.WriteLine(point.Data);
				Show(point.Right, spaces + 5);
			}
		}

		//дерево поиска
		public void AddPoint(T data)
		{
			PointTree<T>? point = root;
			PointTree<T>? current = null;
			bool isExist = false;
			while (point != null && !isExist)
			{
				current = point;
				if (point.Data.CompareTo(data) == 0)
				{
					isExist = true;
				}
				else
				{
					if (point.Data.CompareTo(data) == 0)
					{
						point = point.Left;
					}
					else
					{
						point = point.Right;
					}
				}
			}
			if (isExist)
			{
				return;
			}
			PointTree<T> newPoint = new PointTree<T>(data);
			if (current.Data.CompareTo(data) < 0)
			{
				current.Left = newPoint;
			}
			else
			{
				current.Right = newPoint;
			}
			count++;
		}

		public void TransformToArray(PointTree<T> point, T[]array, ref int current)
		{
			if(point != null)
			{
				TransformToArray(point.Left, array, ref current);
				array[current] = point.Data;
				current++;
				TransformToArray(point.Right, array, ref current);
			}
		}

		public void TransformToFindTree()
		{
			T[] array = new T[count];
			int current = 0;
			TransformToArray(root, array, ref current);

			root = new PointTree<T>(array[0]);
			count = 0;
			for (int i = 1; i < array.Length; i++)
			{
				AddPoint(array[i]);
			}
		}


		public T FindMin()
		{
			PointTree<T>? current = root;
			while (current.Left != null)
			{
				current = current.Left;
			}
			return current.Data;
		}

		public void Delete(T key)
		{
			root = Delete(root, key);
		}

		public PointTree<T>? Delete(PointTree<T>? point, T key)
		{
			if (point == null)
			{
				return point;
			}

			if (key.CompareTo(point.Data) < 0)
			{
				point.Left = Delete(point.Left, key);
			}
			else if (key.CompareTo(point.Data) > 0)
			{
				point.Right = Delete(point.Right, key);
			}
			else
			{
				if (point.Left == null)
				{
					return point.Right;
				}
				else if (point.Right == null)
				{
					return point.Left;
				}

				point.Data = FindMin(point.Right);
				point.Right = Delete(point.Right, point.Data);
			}

			return point;
		}

		public T FindMin(PointTree<T> point)
		{
			while (point.Left != null)
			{
				point = point.Left;
			}
			return point.Data;
		}


		public void DeleteTree()
		{
			root = null;
			count = 0;
		}

	}
}
