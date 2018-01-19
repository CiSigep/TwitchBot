using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Util;

namespace TwitchBot.Model
{
    enum Level { LEVEL_ADMIN, LEVEL_BROADCASTER, LEVEL_MODERATOR, LEVEL_SUBSCRIBER, LEVEL_EVERYONE }
    interface ICommand
    {

        // Shows who can run the command.
        Level AccessLevel { get; set; }

        void execute(string channel);

    }
}
