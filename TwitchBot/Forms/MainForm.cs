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

namespace TwitchBot.Forms
{
    public partial class MainForm : Form
    {
        private Bot.TwitchBot bot;
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
                bot.handleInput(ChatBox.Text);
                ChatBox.Clear();
            }
        }
    }
}
