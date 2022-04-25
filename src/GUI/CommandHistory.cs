using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSL
{
	public class CommandHistory : ListBuffer<string>
	{
		public override void Add(string item)
		{
			base.Add(item);
			_index = Count;
		}

		private int _index;
		public void MoveUp()
		{
			_index--;
			if (_index < 0) _index = 0;
		}

		public void MoveDown()
		{
			_index++;
			if (_index > Count) _index = Count;
		}

		public bool HasCommand
		{
			get { return (_index < Count); }
		}

		public string Command
		{
			get { return this[_index]; }
		}
	}
}
