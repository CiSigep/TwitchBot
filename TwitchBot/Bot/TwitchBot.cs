using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchBot.Forms;
using TwitchBot.Model;
using TwitchBot.Util;

namespace TwitchBot.Bot
{ 
    public class TwitchBot
    {
        private Dictionary<string, CommandDictionary> channels;
        private CommandDictionary globalCommands;
        private IRCUtil irc;
        private MainForm mainform;
        private TextBox console;
        string botUsername;
        public bool Live { get; set; }

        public TwitchBot(string username, string oAuth, MainForm form)
        {
            irc = new IRCUtil("irc.twitch.tv", 6667, username, oAuth);
            channels = new Dictionary<string, CommandDictionary>();
            mainform = form;
            console = mainform.Controls["LogBox"] as TextBox;
            Live = true;
            joinChannel(username);
            globalCommands = new CommandDictionary("#GLOBAL#", irc);
            globalCommands["shutdown"] = new ShutdownCommand(this);
            botUsername = username;
        }

        public bool joinChannel(string channelName)
        {
            // Twitch IRC channels are all lowercase
            channelName = channelName.ToLower();
            try
            {
                channels.Add(channelName, new CommandDictionary(channelName, irc));
                irc.join(channelName);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public bool leaveChannel(string channelName)
        {
            try
            {
                channels.Remove(channelName);
                irc.leave(channelName);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public void doWork()
        {
            while (Live)
            {
                IRCMessage msg = irc.receive();
                if (msg.Username != null && !msg.Username.Equals(""))
                {
                    ConsoleWrite(msg.Username + "@" + msg.Channel + ": " + msg.Message + "\r\n");

                    // Temporary if for testing purposes. Name is removed in GitHub Syncs
                    //TODO: remove all username references for git commits
                    if (msg.Username.Equals("") && msg.Message.StartsWith("!"))
                        handleCommand(msg);

                }
            }
            if (mainform.InvokeRequired)
                mainform.Invoke(new Action(mainform.Close));
            else
                mainform.Close();
        }

        private void handleCommand(IRCMessage msg)
        {
            string command = msg.Message.Split(null)[0].Remove(0, 1);

            // Check the global commands before going for channel commands
            ICommand cmd = globalCommands[command];
            if(cmd == null)
            {
                cmd = channels[msg.Channel][command];
            }

            if (cmd != null)
                cmd.execute(msg.Channel);
             
        }

        public void handleInput(string input)
        {
            IRCMessage i = new IRCMessage(botUsername, "", input);

            ConsoleWrite(i.Username + "@" + i.Channel + ": " + i.Message + "\r\n");

            irc.send("", input);
        }

        private void ConsoleWrite(string message) {
            // Can't write in doWork thread, must invoke the UI to write to itself.
            if (console.InvokeRequired)
            {
                console.Invoke(new Action<string>(ConsoleWrite), new object[] { message });
                return;
            }
            else
            {
                console.Text += message;
            }
        }
    }
}
