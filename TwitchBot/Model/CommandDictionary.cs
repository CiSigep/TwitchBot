using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Util;

namespace TwitchBot.Model
{
    
    class CommandDictionary
    {
        Dictionary<string, ICommand> commands;
        //Dictionary<string, TimedCommand> timedCommands;

        public CommandDictionary(string channelName, IRCUtil util)
        {
            loadCommands(channelName, util);
        }


        public void removeCommand(string key)
        {
            commands.Remove(key);
        }

        public ICommand this[string key]
        {
            get
            {
                return commands.ContainsKey(key) ? commands[key] : null;
            }
            set
            {
                commands[key] = value;
            }
        }

        private void loadCommands(string channelName, IRCUtil util)
        {
            //For now some dummy code
            commands = new Dictionary<string, ICommand>();
            if(channelName.Equals(""))
                commands.Add("testKappa", new BasicResponseCommand(util, "Kappa", Level.LEVEL_ADMIN));
        }

    }
}
