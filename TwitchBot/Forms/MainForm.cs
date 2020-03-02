using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchBot.Bot;
using TwitchBot.Model;

namespace TwitchBot.Forms
{
    public partial class MainForm : Form
    {
        private Bot.TwitchBot bot;
        private string viewChannel;
        public MainForm(string user, string auth)
        {
            InitializeComponent();
            bot = new Bot.TwitchBot(user, auth, this);
            Shown += MainForm_Shown;
            FormClosed += MainForm_Closed;
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            // End bot thread if still active.
            bot.Live = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Run the bot in the background while the main form is visible.
            Thread t = new Thread(bot.doWork);
            t.IsBackground = true;
            t.Start();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(ChatBox.Text.Length > 0)
            {
                bot.handleInput(ChatBox.Text, channelBox.SelectedItem.ToString());
                ChatBox.Clear();
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (channelText.Text.Length > 0 && !channelBox.Items.Contains(channelText.Text) && bot.joinChannel(channelText.Text))
            {
                channelBox.Items.Add(channelText.Text);
                channelBox.SelectedItem = channelText.Text;
                
                channelBox.Enabled = true;
                disconnectButton.Enabled = true;
                viewChannel = channelBox.SelectedItem.ToString();
                channelText.Text = "";
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (bot.leaveChannel(channelBox.SelectedItem.ToString())) {
                channelBox.Items.Remove(channelBox.SelectedItem);

                if (channelBox.Items.Count < 1)
                {
                    channelBox.Enabled = false;
                    disconnectButton.Enabled = false;
                }
            }
        }

        private void channelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogBox.Clear();
            viewChannel = channelBox.SelectedIndex.ToString();
        }

        public void ConsoleWrite(IRCMessage message)
        {
            // Can't write in doWork thread, must invoke the UI to write to itself.
            if (message.Channel.ToLower().Equals(viewChannel.ToLower())) {
                if (LogBox.InvokeRequired)
                {
                    LogBox.Invoke(new Action<IRCMessage>(ConsoleWrite), new object[] { message });
                    return;
                }
                else
                {
                    LogBox.Text += message.Username + ": " + message.Message + "\r\n";
                } 
            }
        }
    }
}
