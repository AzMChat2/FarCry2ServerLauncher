using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSL
{
	public partial class ChatForm : Form
	{
		public static void Show(string playerName, ServerController server)
		{
			ChatForm form = new ChatForm(playerName, server);
			form.Show();
		}

		private ServerController _server;
		private string _playerName;
		private EventHandler<ItemEventArgs<ChatMessage>> ChatMessagesHandler;

		private ChatForm(string playerName, ServerController server)
		{
			InitializeComponent();
			_server = server;
			_playerName = playerName;
			InitConsole();
			ChatMessagesHandler = new EventHandler<ItemEventArgs<ChatMessage>>(ChatMessages_ItemAdded);
			_server.ChatMessages.ItemAdded += ChatMessagesHandler;
		}

		private void InitConsole()
		{
			List<ChatMessage> messages = _server.ChatMessages.FindAll(item => IsPlayer(item));
			if (messages.Count > 500)
			{
				messages.RemoveRange(0, messages.Count - 480);
			}

			StringBuilder sb = new StringBuilder();
			messages.ForEach(item => sb.AppendFormat("{0:hh:mm:ss} {1}:  {2}{3}", item.MessageTime, item.PlayerName, item.Message, Environment.NewLine));
			txtConsole.Text = sb.ToString();
			txtConsole.SelectionStart = txtConsole.Text.Length;
			txtConsole.ScrollToCaret();
		}

		private bool IsPlayer(ChatMessage item)
		{
			return (item.PlayerName.Equals(_playerName, StringComparison.OrdinalIgnoreCase));
		}

		private void ChatMessages_ItemAdded(object sender, ItemEventArgs<ChatMessage> e)
		{
			if (IsPlayer(e.Item))
			{
				lock (chatLocker)
				{
					currentMessage = e.Item;
					AddChatMessage();
					currentMessage = null;
				}
			}
		}

		private void CheckConsoleLength(TextBox textbox)
		{
			if (textbox.Lines.Length > 500)
			{
				List<string> lines = new List<string>(textbox.Lines);
				lines.RemoveRange(0, lines.Count - 400); // Chop off 100 lines at a time...
				textbox.Lines = lines.ToArray();
			}
		}

		private object chatLocker = new object();
		private ChatMessage currentMessage;
		private void AddChatMessage()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(AddChatMessage));
			}
			else
			{
				CheckConsoleLength(txtConsole);
				txtConsole.AppendText(string.Format("{0:hh:mm:ss} {1}:  {2}{3}", currentMessage.MessageTime, currentMessage.PlayerName, currentMessage.Message, Environment.NewLine));
				txtConsole.SelectionStart = txtConsole.Text.Length;
				txtConsole.ScrollToCaret();
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			SendMessage();
		}

		private void SendMessage()
		{
			if (!string.IsNullOrEmpty(txtMessage.Text))
			{
				txtConsole.AppendText(string.Format("{0:hh:mm:ss} {1}:  {2}{3}", DateTime.Now, "Anonymous", txtMessage.Text, Environment.NewLine));
				txtConsole.SelectionStart = txtConsole.Text.Length;
				txtConsole.ScrollToCaret();

				_server.Interface.Tell(_playerName, txtMessage.Text);
				txtMessage.Text = string.Empty;
				txtMessage.Focus();
			}
		}

		private void txtMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendMessage();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				_server.ChatMessages.ItemAdded -= ChatMessagesHandler;
			}
			catch { }
		}
	}
}
