
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

namespace WorldEdit.Commands
{
    public class Pos2
    {
        private WorldEdit Plugin { get; set; }

        public Pos2(WorldEdit plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "/pos2", Description = "Selects your second position.", Permission = "worldedit.command.pos2")]
        public void Launch(Player sender)
        {
            Plugin.SetSecondPosition(sender);

            sender.SendMessage(ChatColors.Gray + "Second position selected to X: " + (int) sender.KnownPosition.X + " Y: " + (int) sender.KnownPosition.Y + " Z: " + (int) sender.KnownPosition.Z);
        }
    }
}