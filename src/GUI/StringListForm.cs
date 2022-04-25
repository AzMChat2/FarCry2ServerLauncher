using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GSL
{
	public partial class StringListForm : Form
	{
		public static void Show(IWin32Window owner, List<string> source, string title, string valueName, string instructions)
		{
			StringListForm form = new StringListForm();
			BindingList<StringValue> dataSource = new BindingList<StringValue>();
			source.ForEach(item => dataSource.Add(new StringValue(item)));

			if (string.IsNullOrEmpty(instructions))
			{
				form.lblInstructions.Visible = false;
			}
			else
			{
				form.lblInstructions.Text = instructions;
			}

			form.Text = title;
			form.grdList.Columns[0].HeaderText = valueName;
			form.grdList.DataSource = dataSource;
			form.grdList.AutoGenerateColumns = false;

			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				source.Clear();
				dataSource.ForEach(item => source.Add(item.Value));
			}
		}

		private class StringValue
		{
			public StringValue() { }
			public StringValue(string value)
			{
				Value = value;
			}
			public string Value { get; set; }
		}

		private StringListForm()
		{
			InitializeComponent();
		}
	}
}
