using Bib10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12_3
{
	public class PointTree<T> where T : IComparable
	{
		public T? Data { get; set; }
		public PointTree<T>? Left { get; set; }
		public PointTree<T>? Right { get; set; }
		public PointTree()
		{
			this.Data = default(T);
			this.Left = null;
			this.Right = null;
		}

		public PointTree(T data)
		{
			this.Data = data;
			this.Left = null;
			this.Right = null;
		}

		public override string? ToString()
		{
			if (Data == null)
			{
				return "";
			}
			else
			{
				return Data.ToString();
			}
		}

		public int CompareTo(PointTree<T> other)
		{
			return Data.CompareTo(other.Data);
		}
	}
}
