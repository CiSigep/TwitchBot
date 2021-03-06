﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Util;

namespace TwitchBot.Model
{
    class ShutdownCommand : ICommand
    {
        public Level AccessLevel { get; set; }

        private Bot.TwitchBot bot;
        public void execute(string channel)
        {
            // Make the doWork Thread end.
            bot.Live = false;
        }

        public ShutdownCommand(Bot.TwitchBot bot)
        {
            this.bot = bot;
            AccessLevel = Level.LEVEL_ADMIN;
        }
    }
}
