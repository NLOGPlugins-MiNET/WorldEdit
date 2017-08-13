
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

using MiNET.Items;
using MiNET.Utils;
using MiNET.Worlds;
using MiNET.Plugins.Attributes;
using MiNET;

namespace WorldEdit.Commands
{
    public class Wand
    {
        private WorldEdit Plugin { get; set; }

        public Wand(WorldEdit plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "/wand", Description = "Gives an wand item that is able to select position.", Permission = "worldedit.command.wand")]
        public void Launch(Player sender)
        {
            if (sender.Level.GameMode.Equals(GameMode.Creative))
            {
                sender.SendMessage(ChatColors.DarkRed + "You are on Creative mode.");

                return;
            }

            if(sender.Inventory.HasItem(new ItemWoodenAxe()))
            {
                sender.SendMessage(ChatColors.DarkRed + "You already have the wand item.");

                return;
            }

            sender.Inventory.SetInventorySlot(0, new ItemWoodenAxe() { Count = 1 });

            sender.SendMessage(ChatColors.Gray + "Break a block to select the #1 position and touch for the #2 position.");
        }
    }
}
