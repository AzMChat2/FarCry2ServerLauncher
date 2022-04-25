using System.Collections.Generic;

namespace GSL
{
	public class ListBuffer<T> : ListEx<T>
	{
		private const int DefaultCapacity = 500;

		public ListBuffer() : base(DefaultCapacity){}

		public ListBuffer(int capacity) : base(capacity) { }

		new public int Capacity
		{
			get { return base.Capacity; }
			set
			{
				base.Capacity = value;
				ResizeList();
			}
		}

		public override void Add(T item)
		{
			base.Add(item);
			ResizeList();
		}

		public override void AddRange(IEnumerable<T> collection)
		{
			base.AddRange(collection);
			ResizeList();
		}

		private void ResizeList()
		{
			if (Count > base.Capacity)
			{
				RemoveRange(0, (Count - base.Capacity));
			}
		}
	}
}
