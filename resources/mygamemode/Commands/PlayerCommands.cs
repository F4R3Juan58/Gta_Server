using System;
using System.Collections.Generic;
using GTANetworkAPI;


namespace mygamemode.Commands
{
    internal class PlayerCommands : Script
    {
        [Command("me", "~o~Usage: /me [action]", GreedyArg = true)]
        public void CMD_me(Player player, string action)
        {
            action = action.Trim();

            List<Player> nearbyPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20, player);

            foreach (Player item in nearbyPlayers)
            {
                item.SendChatMessage($"{Utils.Colors.COLOR_AZUL}* {Utils.Utils.ReturnRPName(player)} {action}");
            }
        }

        [Command("do", "~o~Usage: /do [action]", GreedyArg = true)]
        public void CMD_do(Player player, string action)
        {
            action = action.Trim();

            List<Player> nearbyPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20, player);

            foreach (Player item in nearbyPlayers)
            {
                item.SendChatMessage($"{Utils.Colors.COLOR_AMARILLO}* {Utils.Utils.ReturnRPName(player)}{action}");
            }
        }


        [Command("hp", GreedyArg = true)]
        public void SetHealth(Player player, String healthString)
        {
            if (!int.TryParse(healthString, out int newHealth))
            {
                player.SendChatMessage("Por favor, ingresa un número válido para la vida.");
                return;
            }

            if (newHealth < 0 || newHealth > 100)
            {
                player.SendChatMessage("La vida debe estar entre 0 y 100.");
                return;
            }

            player.Health = newHealth;
            player.SendChatMessage($"¡Vida establecida en {newHealth}!");
            NAPI.Util.ConsoleOutput("UpdateVida lanzado.");
            NAPI.ClientEvent.TriggerClientEvent(player, "UpdateVida", newHealth);
            NAPI.Util.ConsoleOutput("UpdateVida lanzado 2.");
        }

        [Command("ar", GreedyArg = true)]
        public void SetArmor(Player player, String armorString)
        {
            if (!int.TryParse(armorString, out int newArmor))
            {
                player.SendChatMessage("Por favor, ingresa un número válido para la vida.");
                return;
            }

            if (newArmor < 0 || newArmor > 100)
            {
                player.SendChatMessage("La vida debe estar entre 0 y 100.");
                return;
            }

            player.Armor = newArmor;
            player.SendChatMessage($"¡Vida establecida en {newArmor}!");
            NAPI.Util.ConsoleOutput("UpdateArmadura lanzado.");
            NAPI.ClientEvent.TriggerClientEvent(player, "UpdateArmadura", newArmor);
            NAPI.Util.ConsoleOutput("UpdateArmadura lanzado 2.");

        }

        [Command("vh", "~o~Usage: /vh ", GreedyArg = true)]
        public void CMD_vh(Player player)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowVehicleCEF", true);
        }
    }
}
