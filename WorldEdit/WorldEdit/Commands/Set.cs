
/*
    ▓█████▄  ▄▄▄       ██▀███   ██ ▄█▀ ██▓     █    ██  ▄▄▄▄   
    ▒██▀ ██▌▒████▄    ▓██ ▒ ██▒ ██▄█▒ ▓██▒     ██  ▓██▒▓█████▄ 
    ░██   █▌▒██  ▀█▄  ▓██ ░▄█ ▒▓███▄░ ▒██░    ▓██  ▒██░▒██▒ ▄██
    ░▓█▄   ▌░██▄▄▄▄██ ▒██▀▀█▄  ▓██ █▄ ▒██░    ▓▓█  ░██░▒██░█▀  
    ░▒████▓  ▓█   ▓██▒░██▓ ▒██▒▒██▒ █▄░██████▒▒▒█████▓ ░▓█  ▀█▓
     ▒▒▓  ▒  ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒ ▒▒ ▓▒░ ▒░▓  ░░▒▓▒ ▒ ▒ ░▒▓███▀▒
     ░ ▒  ▒   ▒   ▒▒ ░  ░▒ ░ ▒░░ ░▒ ▒░░ ░ ▒  ░░░▒░ ░ ░ ▒░▒   ░ 
     ░ ░  ░   ░   ▒     ░░   ░ ░ ░░ ░   ░ ░    ░░░ ░ ░  ░    ░ 
       ░          ░  ░   ░     ░  ░       ░  ░   ░      ░      
     ░                                                       ░ 

     WorldEdit by Herb9. (pksxtm@gmail.com, Telegram @Herb9)
*/

using MiNET.Utils;
using MiNET.Plugins.Attributes;
using MiNET;

using System.Threading;
using System;

namespace WorldEdit.Commands
{
    public class Set
    {
        private WorldEdit Plugin { get; set; }

        public Set(WorldEdit plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "/set", Description = "Fills the current selection.", Permission = "worldedit.command.set")]
        public void Launch(Player sender, int blockId)
        {
            new Thread(() =>
            {
                if(blockId.CompareTo(0xff) > 0)
                {
                    sender.SendMessage(ChatColors.DarkRed + "Invalid id.");

                    return;
                }

                if(!Plugin.IsFirstPosition(sender) || !Plugin.IsSecondPosition(sender))
                {
                    sender.SendMessage(ChatColors.DarkRed + "Please select your position first.");

                    return;
                }

                int startX = Math.Min(Plugin.GetFirstPosition(sender).X, Plugin.GetSecondPosition(sender).X);
                int endX = Math.Max(Plugin.GetFirstPosition(sender).X, Plugin.GetSecondPosition(sender).X);

                int startY = Math.Min(Plugin.GetFirstPosition(sender).Y, Plugin.GetSecondPosition(sender).Y);
                int endY = Math.Max(Plugin.GetFirstPosition(sender).Y, Plugin.GetSecondPosition(sender).Y);

                int startZ = Math.Min(Plugin.GetFirstPosition(sender).Z, Plugin.GetSecondPosition(sender).Z);
                int endZ = Math.Max(Plugin.GetFirstPosition(sender).Z, Plugin.GetSecondPosition(sender).Z);

                int changed = 0;

                for (int x = startX; x <= endX; x++)
                {
                    for (int y = startY; y <= endY; y++)
                    {
                        for (int z = startZ; z <= endZ; z++)
                        {
                            sender.Level.SetBlock(x, y, z, blockId);

                            changed++;
                        }
                    }
                }

                sender.SendMessage(ChatColors.Gray + changed + " block(s) have been changed.");

                Plugin.RemoveFirstPosition(sender);
                Plugin.RemoveSecondPosition(sender);
            }).Start();
        }
    }
}